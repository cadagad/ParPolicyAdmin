using BusinessLogic.Models;
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

        public List<Barcode> BarcodeFeed_ToList(int barcodeFeedId, string stagingPath)
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

            /* Check if text file */
            if (Path.GetExtension(file).ToLower() != ".txt")
                throw new Exception(String.Format("Error : Invalid File Extension", file));
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

            return barcodes;
        }
    }
