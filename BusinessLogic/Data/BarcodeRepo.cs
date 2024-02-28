using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class BarcodeRepo
    {
        private readonly AppDbContext _appDbContext;

        public BarcodeRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public List<Barcode> GetBarcodes_ByProjectId(int projectId)
        {
            List<Barcode> barcodeList = _appDbContext.Barcodes
                .Where(b => b.BarcodeFeed.ProjectId == projectId)
                .ToList();
            return barcodeList;
        }

        public bool DeleteBarcodes_ByBarcodeFeedId(int barcodeFeedId)
        {
            try
            {
                string sql = String.Format("DELETE FROM dbo.Barcodes where BarcodeFeedId = {0}", barcodeFeedId.ToString());
                _appDbContext.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }

            return true;
        }

        public void BulkInsertPolicy(List<Barcode> barcodes)
        {
            _appDbContext.Barcodes.AddRange(barcodes);
            _appDbContext.SaveChanges();
        }

        public List<VwBarcodeMailing> Process_AllRecords_ToList(string file)
        {
            if (!File.Exists(file))
                throw new Exception(String.Format("Error : File {0} does not exist", file));

            /* Check if correct file */
            if (Path.GetFileName(file).ToUpper() != "ALL_RECORDS.TXT")
                throw new Exception(String.Format("Error : Invalid File : {0}", file));

            List<VwBarcodeMailing> annualMailings = new List<VwBarcodeMailing>();
            string[] lines = File.ReadAllLines(file);
            int ln = 0;
            int invalidLineCount = 0;

            foreach (string line in lines)
            {
                ln++;
                VwBarcodeMailing bm = new VwBarcodeMailing();

                /* Check if line length is valid */
                if (line.Length < _COM.BCODE_LEN_MINLINE)
                {
                    invalidLineCount++;
                    continue;
                }

                /* if first 3 lines does not meet length criteria - consider an invalid file */
                if (ln == 3 && invalidLineCount == 3)
                {
                    throw new Exception(String.Format("Error : Invalid file format : {0}", file));
                }

                /* Check if Policy Number is valid */
                string policyNum = line.Substring(_COM.START_POS_ANNUAL_POLICYNUM, _COM.LEN_POLICYNUM).Trim();
                if (String.IsNullOrEmpty(policyNum))
                    continue;

                /* Check if Barcode Number is valid */
                string barcodeNum = line.Substring(_COM.BCODE_START_POS_BARCODENUM, _COM.BCODE_LEN_BARCODENUM).Trim();
                if (String.IsNullOrEmpty(barcodeNum))
                    continue;

                /* Pad zero to policyNum */
                policyNum = policyNum.PadLeft(_COM.LEN_POLICYNUM, '0');

                /* Pad zero to policyNum */
                barcodeNum = barcodeNum.PadLeft(_COM.BCODE_LEN_BARCODENUM, '0');

                bm.SystemCode = line.Substring(_COM.START_POS_ANNUAL_SYSCODE, _COM.LEN_SYSCODE).Trim();
                bm.PolicyNumber = policyNum;
                bm.PostalCode = line.Substring(_COM.START_POS_ANNUAL_POSTAL, _COM.LEN_POSTAL).Trim();
                bm.CountryCode = line.Substring(_COM.START_POS_ANNUAL_COUNTRY, _COM.LEN_COUNTRY).Trim();
                bm.LanguageCode = line.Substring(_COM.START_POS_ANNUAL_LANGUAGE, _COM.LEN_LANGUAGE).Trim();
                bm.HolderName = line.Substring(_COM.START_POS_ANNUAL_HOLDERNAME, _COM.LEN_HOLDERNAME).Trim();
                bm.Address1 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_1, _COM.LEN_ADDRESS).Trim();
                bm.Address2 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_2, _COM.LEN_ADDRESS).Trim();
                bm.Address3 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_3, _COM.LEN_ADDRESS).Trim();
                bm.Address4 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_4, _COM.LEN_ADDRESS).Trim();
                bm.Address5 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_5, _COM.LEN_ADDRESS).Trim();
                bm.Address6 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_6, _COM.LEN_ADDRESS).Trim();
                bm.KeyName = line.Substring(_COM.START_POS_ANNUAL_KEYNAME, _COM.LEN_KEYNAME).Trim();
                bm.BarcodeNumber = barcodeNum;

                annualMailings.Add(bm);
            }

            return annualMailings;
        }

        public List<Barcode> Process_AllRecords_ToList(int barcodeFeedId, string stagingPath)
        {
            BarcodeFeed barcodeFeed = _appDbContext.BarcodeFeeds
                .Where(bf => bf.BarcodeFeedId == barcodeFeedId && bf.IsValid)
                .FirstOrDefault();

            #region LoadPolicyFeed - Exception Handling
            if (barcodeFeedId == 0)
                throw new Exception(String.Format("Error : Invalid barcodeFeedId", barcodeFeedId));

            if (barcodeFeed == null)
                throw new Exception(String.Format("Error : Invalid barcodeFeedId", barcodeFeedId));

            /* Get filename from db */
            string file = Path.Combine(stagingPath, barcodeFeed.FileName);

            if (!Directory.Exists(stagingPath))
                throw new Exception(String.Format("Error : Staging {0} does not exist", stagingPath));

            if (!File.Exists(file))
                throw new Exception(String.Format("Error : File does not exist", file));

            /* Check if correct file */
            if (barcodeFeed.FileName != "ALL_RECORDS.TXT")
                throw new Exception(String.Format("Error : Invalid File : ", file));
            #endregion

            /* Check if has Policy has existing records - Delete if exist */
            var BarcodeCheck = _appDbContext.Barcodes.Where(bc => bc.BarcodeFeedId == barcodeFeedId).FirstOrDefault();
            if (BarcodeCheck != null)
            {
                this.DeleteBarcodes_ByBarcodeFeedId(barcodeFeedId);
            }

            List<Barcode> barcodes = new List<Barcode>();

            string[] lines = File.ReadAllLines(file);
            int ln = 0;

            using (var context = new AppDbContext())
            {
                foreach (string line in lines)
                {
                    ln++;
                    Barcode barcode = new Barcode();

                    /* Check if line length is valid */
                    if (line.Length < _COM.BCODE_LEN_MINLINE)
                        continue;

                    /* Check if Policy Number is valid */
                    string policyNum = line.Substring(_COM.BCODE_START_POS_POLICYNUM, _COM.BCODE_LEN_POLICYNUM).Trim();
                    if (String.IsNullOrEmpty(policyNum))
                        continue;

                    /* Check if Barcode Number is valid */
                    string barcodeNum = line.Substring(_COM.BCODE_START_POS_BARCODENUM, _COM.BCODE_LEN_BARCODENUM).Trim();
                    if (String.IsNullOrEmpty(barcodeNum))
                        continue;

                    /* Pad zero to policyNum */
                    policyNum = policyNum.PadLeft(_COM.BCODE_LEN_POLICYNUM, '0');

                    /* Pad zero to barcode */
                    barcodeNum = barcodeNum.PadLeft(_COM.BCODE_LEN_BARCODENUM, '0');

                    barcode.BarcodeFeedId = barcodeFeedId;
                    barcode.LineNumber = ln;
                    barcode.BarcodeNumber = barcodeNum;
                    barcode.PolicyNumber = policyNum;

                    barcodes.Add(barcode);
                }
            }


            return barcodes;
        }

        public List<VwBarcodePolicy> GetAllBarcodePolicy_ByProjectId(int projectId, string filter = null)
        {
            List<VwBarcodePolicy> barcodePolicies = new List<VwBarcodePolicy>();

            List<Barcode> barcodes = new List<Barcode>();

            if (String.IsNullOrEmpty(filter))
            {
                barcodes = _appDbContext.Barcodes
                    .Where(b => b.BarcodeFeed.Project.IsActive == true)
                    .ToList();
            }
            else
            {
                barcodes = _appDbContext.Barcodes
                    .Where(b => b.BarcodeFeed.Project.IsActive == true && b.BarcodeNumber.Contains(filter ?? String.Empty))
                    .ToList();
            }

            List<Policy> policies = _appDbContext.Policy
                .Where(p => p.PolicyFeed.Project.IsActive == true)
                .ToList();

            barcodePolicies = barcodes.Join(
                policies, 
                b => b.PolicyNumber, 
                p => p.PolicyNumber, 
                (b, p) => new VwBarcodePolicy 
                {
                    BarcodeId = b.BarcodeId,
                    BarcodeNumber = b.BarcodeNumber,
                    PolicyNumber = b.PolicyNumber,
                    HolderName = p.HolderName,
                    BirthDate = p.BirthDate,
                    Address1 = p.Address1,
                    Address2 = p.Address2,
                    Address3 = p.Address3
                }).ToList();

            return barcodePolicies;
        }
    }
}