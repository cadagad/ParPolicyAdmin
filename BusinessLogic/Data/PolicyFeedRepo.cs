using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class PolicyFeedRepo
    {
        private readonly AppDbContext _appDbContext;
        List<string> sourceList;
        
        public PolicyFeedRepo()
        {
            _appDbContext = new AppDbContext();
            sourceList = _appDbContext.Sources.Select(s => s.Code).ToList();
        }

        public List<PolicyFeed> GetPolicyFeeds_ByProjectId(int projectId)
        {
            List<PolicyFeed> PolicyFeedList = _appDbContext.PolicyFeeds
                .Where(pf => pf.ProjectId == projectId && 
                             pf.IsValid == true)
                .ToList();
            return PolicyFeedList;
        }

        public bool AddPolicyFeeds(
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

                /* Check first 3 rows if valid */
                int cnt = 0;
                int errorLineCounter = 0;
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    cnt++;
                    if (cnt > 3)
                        break;

                    /* Expected length is 360 - Check if valid format */
                    if (line.Length < 350)
                    {
                        errorLineCounter++;
                        continue;
                    }

                    /* Source is position 15 with 3 length [ex: C01, C06, PH1] */
                    string source = line.Substring(14, 3);
                    if (!sourceList.Contains(source))
                    {
                        errorLineCounter++;
                        continue;
                    }
                }

                /* If first 3 lines does not match criteria - it is considered an invalid file */
                
                if (errorLineCounter >= 3)
                {
                    isValid = false;
                    invalidFileMessage = "Invalid feed format";
                }
                    

                /* Valid file if it reaches here */
                string fileName = Path.GetFileName(file);

                PolicyFeed forUpdate = _appDbContext.PolicyFeeds
                    .Where(upd => upd.FileName == fileName && upd.ProjectId == projectId).FirstOrDefault();
                if (forUpdate != null)
                {
                    forUpdate.IsProcessed = false;
                    forUpdate.Status = "Pending";
                    forUpdate.RowCount = rowCount;
                    forUpdate.IsValid = isValid;
                    forUpdate.ExceptionReason = 
                        !String.IsNullOrEmpty(invalidFileMessage) ? invalidFileMessage : null;
                }
                else
                {
                    PolicyFeed pf = new PolicyFeed()
                    {
                        FileName = fileName,
                        IsProcessed = false,
                        ProjectId = projectId,
                        RowCount = rowCount,
                        IsValid = isValid,
                        Status = "Pending",
                        ExceptionReason = !String.IsNullOrEmpty(invalidFileMessage) ? invalidFileMessage : null
                    };

                    _appDbContext.PolicyFeeds.Add(pf);
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

        public void SetFeedIsProcessed(int policyFeedId)
        {
            PolicyFeed pf = _appDbContext.PolicyFeeds.Where(p => p.PolicyFeedId == policyFeedId).FirstOrDefault();
            pf.IsProcessed = true;
            pf.Status = "Complete";

            _appDbContext.SaveChanges();
        }

        public void SetFeedIsRunning(int policyFeedId)
        {
            PolicyFeed pf = _appDbContext.PolicyFeeds.Where(p => p.PolicyFeedId == policyFeedId).FirstOrDefault();
            pf.Status = "Running";

            _appDbContext.SaveChanges();
        }
    }
}
