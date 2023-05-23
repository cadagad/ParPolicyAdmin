using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;

namespace BusinessLogic.Data
{
    public class BarcodeFeedRepo
    {
        private readonly AppDbContext _appDbContext;

        public BarcodeFeedRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public List<BarcodeFeed> GetBarcodeFeeds_ByProjectId(int projectId)
        {
            List<BarcodeFeed> barcodeFeeds = _appDbContext.BarcodeFeeds
                .Where(pf => pf.ProjectId == projectId &&
                             pf.IsValid == true)
                .ToList();
            return barcodeFeeds;
        }

        public bool AddBarcodeFeeds(
            int projectId,
            string dropoffPath,
            string stagingPath,
            string archivePath)
        {
            /* Check if folder(s) exist */
            if (!Directory.Exists(dropoffPath))
                throw new Exception(String.Format("Error : Dropoff {0} does not exist", dropoffPath));

            if (!Directory.Exists(stagingPath))
                throw new Exception(String.Format("Error : Staging {0} does not exist", stagingPath));

            if (!Directory.Exists(archivePath))
                throw new Exception(String.Format("Error : Archive {0} does not exist", archivePath));

            /* Check if zero files */
            int fileCount = Directory.GetFiles(dropoffPath).Length;
            if (fileCount == 0)
                throw new Exception(String.Format("No files on {0}", dropoffPath));

            /* Get all text files */
            string[] files = Directory.GetFiles(dropoffPath, "*.txt");
            foreach (string file in files)
            {
                bool isValid = true;
                string invalidFileMessage = String.Empty;

                /* Check if file is empty - move to exceptions */
                int rowCount = File.ReadLines(file).Count();
                if (rowCount == 0)
                {
                    isValid = false;
                    invalidFileMessage = "Empty feed";
                }

                /* Valid file if it reaches here */
                string fileName = Path.GetFileName(file);

                /* Check if file is either ANNUAL.TXT or ALL_RECORDS.TXT */
                if (fileName.ToUpper() != "ANNUAL.TXT" &&
                    fileName.ToUpper() != "ALL_RECORDS.TXT")
                {
                    isValid = false;
                    invalidFileMessage = String.Format("Unexpected feed name : {0}", fileName);
                }

                BarcodeFeed forUpdate = _appDbContext.BarcodeFeeds
                    .Where(upd => upd.FileName == fileName && upd.ProjectId == projectId).FirstOrDefault();
                if (forUpdate != null)
                {
                    forUpdate.IsProcessed = false;
                    forUpdate.RowCount = rowCount;
                    forUpdate.IsValid = isValid;
                    forUpdate.ExceptionReason =
                        !String.IsNullOrEmpty(invalidFileMessage) ? invalidFileMessage : null;
                }
                else
                {
                    BarcodeFeed bf = new BarcodeFeed()
                    {
                        FileName = fileName,
                        IsProcessed = false,
                        ProjectId = projectId,
                        RowCount = rowCount,
                        IsValid = isValid,
                        ExceptionReason = !String.IsNullOrEmpty(invalidFileMessage) ? invalidFileMessage : null
                    };

                    _appDbContext.BarcodeFeeds.Add(bf);
                }

                /* Copy the valid file to staging */
                if (isValid)
                {
                    string stagingWFile;
                    if (stagingPath.EndsWith("\\"))
                        stagingWFile = stagingPath + fileName;
                    else
                        stagingWFile = stagingPath + "\\" + fileName;

                    File.Copy(file, stagingWFile, true);
                }
            }

            /* Move all to archive */
            string archiveWDate;
            if (archivePath.EndsWith("\\"))
                archiveWDate = archivePath + DateTime.Now.ToString("yyyyMMdd-hhmmss");
            else
                archiveWDate = archivePath + "\\" + DateTime.Now.ToString("yyyyMMdd-hhmmss");
            Directory.CreateDirectory(archiveWDate);

            foreach (string file in files)
            {
                /* If file exist - delete */
                string archived_file = archiveWDate + "\\" + Path.GetFileName(file);
                File.Copy(file, archived_file, true);
                File.Delete(file);
            }

            /* If there are valid files - insert to db */
            _appDbContext.SaveChanges();

            return true;
        }

        public void SetFeedIsProcessed(int barcodeFeedId)
        {
            BarcodeFeed bf = _appDbContext.BarcodeFeeds.Where(p => p.BarcodeFeedId == barcodeFeedId).FirstOrDefault();
            bf.IsProcessed = true;

            _appDbContext.SaveChanges();
        }
    }
}
