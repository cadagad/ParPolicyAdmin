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
        List<string> sourceList;

        private int UnacceptableAddressLen = 5;

        public BarcodeRepo()
        {
            _appDbContext = new AppDbContext();
            sourceList = _appDbContext.Sources.Select(s => s.Code).ToList();
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

        public bool DeleteCurrentMailingList()
        {
            try
            {
                string sql = String.Format("DELETE FROM dbo.CurrentPolicy)");
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

        public List<AnnualMailingList> Process_Annual_ToList(int barcodeFeedId, string stagingPath)
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
            if (barcodeFeed.FileName != "ANNUAL.TXT")
                throw new Exception(String.Format("Error : Invalid File : ", file));
            #endregion

            /* Check if has Policy has existing records - Delete if exist */
            int MailingListCheck = _appDbContext.AnnualMailingList.Count();
            if (MailingListCheck > 0)
            {
                this.DeleteCurrentMailingList();
            }

            List<AnnualMailingList> currentPolicies = new List<AnnualMailingList>();

            /* Process the Annual.txt file */
            string[] lines = File.ReadAllLines(file);
            int ln = 0;

            foreach (string line in lines)
            {
                ln++;
                AnnualMailingList policy = new AnnualMailingList();

                /* Check if syscode is valid */
                string sysCode = line.Substring(_COM.START_POS_ANNUAL_SYSCODE, _COM.LEN_SYSCODE).Trim();
                if (String.IsNullOrEmpty(sysCode) || !sourceList.Contains(sysCode))
                    continue;

                /* Check if line length is valid */
                if (line.Length < _COM.LEN_ANNUAL_MINLINE)
                    continue;

                /* Check if Policy Number is valid */
                string policyNum = line.Substring(_COM.START_POS_ANNUAL_POLICYNUM, _COM.LEN_POLICYNUM).Trim();
                if (String.IsNullOrEmpty(policyNum))
                    continue;

                /* Check if address 1 and address2 are both empty */
                string address1 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_1, _COM.LEN_ADDRESS).Trim();
                string address2 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_2, _COM.LEN_ADDRESS).Trim();
                string address3 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_3, _COM.LEN_ADDRESS).Trim();
                string address4 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_4, _COM.LEN_ADDRESS).Trim();
                string address5 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_5, _COM.LEN_ADDRESS).Trim();
                if (String.Concat(address1, address2, address3, address4, address5).Length <= UnacceptableAddressLen)
                    continue;

                /* Pad zero to policyNum */
                policyNum = policyNum.PadLeft(10, '0');

                policy.SystemCode = sysCode;
                policy.PolicyNumber = policyNum;
                policy.HolderName = line.Substring(_COM.START_POS_ANNUAL_HOLDERNAME, _COM.LEN_HOLDERNAME).Trim();
                policy.Address1 = address1;
                policy.Address2 = address2;
                policy.Address3 = address3;
                policy.Address4 = address4;
                policy.Address5 = address5;
                policy.Address6 = line.Substring(_COM.START_POS_ANNUAL_ADDRESS_6, _COM.LEN_ADDRESS).Trim();
                policy.PostalCode = line.Substring(_COM.START_POS_ANNUAL_POSTAL, _COM.LEN_POSTAL).Trim();
                policy.CountryCode = line.Substring(_COM.START_POS_ANNUAL_COUNTRY, _COM.LEN_COUNTRY).Trim();
                policy.LanguageCode = line.Substring(_COM.START_POS_ANNUAL_LANGUAGE, _COM.LEN_LANGUAGE).Trim();
                policy.KeyName = line.Substring(_COM.START_POS_ANNUAL_KEYNAME, _COM.LEN_KEYNAME).Trim();
                policy.LineNumber = ln;

                policy.UserFlaggedDuplicate = false;
                policy.UserFlaggedDeficient = false;
                policy.UserFlaggedExclusion = false;

                currentPolicies.Add(policy);
            }

            return currentPolicies;
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

                    /* Pad zero to policyNum */
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