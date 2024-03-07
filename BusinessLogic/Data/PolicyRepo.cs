using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Utilities;
using BusinessLogic.Models;
using System.IO;
using System.Globalization;

using System.Data.Entity;

namespace BusinessLogic.Data
{
    public class PolicyRepo
    {
        private int UnacceptableAddressLen = 5;

        private readonly AppDbContext _appDbContext;
        List<string> sourceList;

        public PolicyRepo()
        {
            _appDbContext = new AppDbContext();
            sourceList = _appDbContext.Sources.Select(s => s.Code).ToList();
        }
        
        public List<Policy> GetPolicies_ByProjectId(int projectId)
        {
            List<Policy> policyList = _appDbContext.Policy
                .Where(p => p.PolicyFeed.ProjectId == projectId)
                .ToList();
            return policyList;
        }

        public List<Policy> GetPolicies_BySourceCode(List<string> sourceCode)
        {
            List<Policy> policyList = _appDbContext.Policy
                .Where(p => sourceCode.Contains(p.SystemCode) && 
                       p.UserFlaggedDuplicate == false && 
                       p.UserFlaggedDeficient == false &&
                       p.UserFlaggedExclusion == false &&
                       p.ExactDuplicate == false &&
                       p.PolicyFeed.Project.IsActive == true)
                .ToList();
            return policyList;
        }

        public List<VwPolicySummary> GetDeficients_BySourceCode(string sourceCode)
        {
            if (sourceCode.Length <= 0 || sourceCode.Length > 3)
                throw new Exception("Error : Source invalid format : " + sourceCode);

            List<Policy> policyList = _appDbContext.Policy
                .Where(p => p.SystemCode == sourceCode &&
                       p.PolicyHolderId != null &&
                       p.ExactDuplicate == false &&
                       p.PolicyFeed.Project.IsActive == true)
                .ToList();

            List<VwPolicySummary> view = new List<VwPolicySummary>();
            foreach (Policy p in policyList)
            {
                string bd = _COM.ConvertDate_yyyyMMdd(p.BirthDate);

                VwPolicySummary v = new VwPolicySummary()
                {
                    PolicyId = p.PolicyId,
                    HolderName = p.HolderName,
                    BirthDate = bd,
                    PolicyNumber = p.PolicyNumber,
                    Address1 = p.Address1,
                    Address2 = p.Address2,
                    Address3 = p.Address3,
                    Address4 = p.Address4,
                    Address5 = p.Address5,
                    PossibleDuplicate = p.PossibleDuplicate ?? false,
                    UserFlaggedDuplicate = p.UserFlaggedDuplicate ?? false,
                    UserFlaggedDeficient = p.UserFlaggedDeficient ?? false
                };

                view.Add(v);
            }

            var ret = view.OrderBy(p => p.HolderName).ThenBy(p => p.BirthDate).ThenBy(p => p.PossibleDuplicate).ToList();

            return ret;
        }

        public List<VwPolicySummary> GetDuplicates_BySourceCode(string sourceCode)
        {
            if (sourceCode.Length <= 0 || sourceCode.Length > 3)
                throw new Exception("Error : Source invalid format : " + sourceCode);

            List<int?> duplicateList = _appDbContext.Policy
                .Where(p => p.PossibleDuplicate == true && 
                       p.SystemCode == sourceCode && 
                       p.PolicyHolderId != null &&
                       p.ExactDuplicate == false &&
                       p.PolicyFeed.Project.IsActive == true)
                .Select(p => p.PolicyHolderId)
                .ToList();

            List<Policy> policyList = _appDbContext.Policy
                .Where(p => duplicateList
                .Contains(p.PolicyHolderId) &&
                       p.SystemCode == sourceCode &&
                       p.PolicyHolderId != null &&
                       p.ExactDuplicate == false &&
                       p.PolicyFeed.Project.IsActive == true)
                .ToList();

            List<VwPolicySummary> view = new List<VwPolicySummary>();
            foreach (Policy p in policyList)
            {
                string bd = _COM.ConvertDate_yyyyMMdd(p.BirthDate);

                VwPolicySummary v = new VwPolicySummary()
                {
                    PolicyId = p.PolicyId,
                    HolderName = p.HolderName,
                    BirthDate = bd,
                    PolicyNumber = p.PolicyNumber,
                    Address1 = p.Address1,
                    Address2 = p.Address2,
                    Address3 = p.Address3,
                    Address4 = p.Address4,
                    Address5 = p.Address5,
                    PossibleDuplicate = p.PossibleDuplicate ?? false,
                    UserFlaggedDuplicate = p.UserFlaggedDuplicate ?? false
                };

                view.Add(v);
            }

            var ret = view.OrderBy(p => p.HolderName).ThenBy(p => p.BirthDate).ThenBy(p => p.PossibleDuplicate).ToList();

            return ret;
        }

        public void BulkInsertPolicy(List<Policy> policies)
        {
            _appDbContext.Policy.AddRange(policies);
            _appDbContext.SaveChanges();
        }

        public bool SaveReviewDuplicate(List<VwPolicySummary> changes)
        {
            foreach (var c in changes)
            {
                Policy result = _appDbContext.Policy.SingleOrDefault(p => p.PolicyId == c.PolicyId);
                if (result != null && 
                    result.UserFlaggedDuplicate != c.UserFlaggedDuplicate)
                {
                    result.UserFlaggedDuplicate = c.UserFlaggedDuplicate;
                }
            }

            _appDbContext.SaveChanges();

            return true;
        }

        public bool SaveReviewDeficient(List<VwPolicySummary> changes)
        {
            foreach (var c in changes)
            {
                Policy result = _appDbContext.Policy.SingleOrDefault(p => p.PolicyId == c.PolicyId);
                if (result != null &&
                    result.UserFlaggedDeficient != c.UserFlaggedDeficient)
                {
                    result.UserFlaggedDeficient = c.UserFlaggedDeficient;
                }
            }

            _appDbContext.SaveChanges();

            return true;
        }

        public bool DeletePolicies_ByPolicyFeedId(int policyFeedId)
        {
            try
            {
                string sql = String.Format("DELETE FROM dbo.Policies where PolicyFeedId = {0}", policyFeedId.ToString());
                _appDbContext.Database.ExecuteSqlCommand(sql) ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }

            return true;
        }

        public int GetFeedId_ByFeedNameInActiveProject(string feedName)
        {
            /* Default of -1 is error */
            int ret = -1;

            PolicyFeed policyFeed = _appDbContext.PolicyFeeds
                .Where(pf => pf.FileName == feedName && pf.IsValid == true && pf.Project.IsActive == true)
                .FirstOrDefault();

            if (policyFeed == null)
                return ret;

            ret = policyFeed.PolicyFeedId;
            return ret;
        }

        public List<Policy> PolicyFeed_ToList(int policyFeedId, string stagingPath)
        {

            PolicyFeed policyFeed = _appDbContext.PolicyFeeds
                .Where(pf => pf.PolicyFeedId == policyFeedId && pf.IsValid)
                .FirstOrDefault();

            #region LoadPolicyFeed - Exception Handling
            if (policyFeedId == 0)
                throw new Exception(String.Format("Error : Invalid policyFeedId", policyFeedId));

            if (policyFeed == null)
                throw new Exception(String.Format("Error : Invalid policyFeedId", policyFeedId));

            /* Get filename from db */
            string file = Path.Combine(stagingPath, policyFeed.FileName);

            if (!Directory.Exists(stagingPath))
                throw new Exception(String.Format("Error : Staging {0} does not exist", stagingPath));

            if (!File.Exists(file))
                throw new Exception(String.Format("Error : File does not exist", file));

            /* Check if text file */
            if (Path.GetExtension(file).ToLower() != ".txt")
                throw new Exception(String.Format("Error : Invalid File Extension", file));
            #endregion

            /* Check if has Policy has existing records - Delete if exist */
            var PolicyCheck = _appDbContext.Policy.Where(p => p.PolicyFeedId == policyFeedId).FirstOrDefault();
            if (PolicyCheck != null)
            {
                this.DeletePolicies_ByPolicyFeedId(policyFeedId);
            }

            List<Policy> policies = new List<Policy>();

            string[] lines = File.ReadAllLines(file);
            int ln = 0;

            using (var context = new AppDbContext())
            {
                foreach (string line in lines)
                {
                    ln++;
                    Policy policy = new Policy();

                    /* Check if syscode is valid */
                    string sysCode = line.Substring(_COM.START_POS_SYSCODE, _COM.LEN_SYSCODE).Trim();
                    if (String.IsNullOrEmpty(sysCode) || !sourceList.Contains(sysCode))
                        continue;

                    /* Check if line length is valid */
                    if (line.Length < _COM.LEN_MINLINE)
                        continue;

                    /* Check if Policy Number is valid */
                    string policyNum = line.Substring(_COM.START_POS_POLICYNUM, _COM.LEN_POLICYNUM).Trim();
                    if (String.IsNullOrEmpty(policyNum))
                        continue;

                    /* Check if address 1 and address2 are both empty */
                    string address1 = line.Substring(_COM.START_POS_ADDRESS_1, _COM.LEN_ADDRESS).Trim();
                    string address2 = line.Substring(_COM.START_POS_ADDRESS_2, _COM.LEN_ADDRESS).Trim();
                    string address3 = line.Substring(_COM.START_POS_ADDRESS_3, _COM.LEN_ADDRESS).Trim();
                    string address4 = line.Substring(_COM.START_POS_ADDRESS_4, _COM.LEN_ADDRESS).Trim();
                    string address5 = line.Substring(_COM.START_POS_ADDRESS_5, _COM.LEN_ADDRESS).Trim();
                    if (String.Concat(address1, address2, address3, address4, address5).Length <= UnacceptableAddressLen)
                        continue;

                    /* Pad zero to policyNum */
                    policyNum = policyNum.PadLeft(10, '0');

                    policy.SystemCode = sysCode;
                    policy.PolicyNumber = policyNum;
                    policy.CertificateNumber = line.Substring(_COM.START_POS_CERTNUM, _COM.LEN_CERTNUM).Trim();
                    policy.HolderName = line.Substring(_COM.START_POS_HOLDERNAME, _COM.LEN_HOLDERNAME).Trim();
                    policy.Address1 = address1;
                    policy.Address2 = address2;
                    policy.Address3 = address3;
                    policy.Address4 = address4;
                    policy.Address5 = address5;
                    policy.Address6 = line.Substring(_COM.START_POS_ADDRESS_6, _COM.LEN_ADDRESS).Trim();
                    policy.Address7 = line.Substring(_COM.START_POS_ADDRESS_7, _COM.LEN_ADDRESS).Trim();
                    policy.PostalCode = line.Substring(_COM.START_POS_POSTAL, _COM.LEN_POSTAL).Trim();
                    policy.CountryCode = line.Substring(_COM.START_POS_COUNTRY, _COM.LEN_COUNTRY).Trim();
                    policy.ProvinceStateCode = line.Substring(_COM.START_POS_PROVINCE, _COM.LEN_PROVINCE).Trim();
                    policy.LanguageCode = line.Substring(_COM.START_POS_LANGUAGE, _COM.LEN_LANGUAGE).Trim();
                    policy.ShareVotes = line.Substring(_COM.START_POS_VOTES, _COM.LEN_VOTES).Trim();
                    policy.BirthDate = line.Substring(_COM.START_POS_BIRTHDATE, _COM.LEN_BIRTHDATE).Trim();
                    policy.KeyName = line.Substring(_COM.START_POS_KEYNAME, _COM.LEN_KEYNAME).Trim();
                    policy.PolicyFeedId = policyFeedId;
                    policy.LineNumber = ln;

                    policy.UserFlaggedDuplicate = false;
                    policy.UserFlaggedDeficient = false;
                    policy.UserFlaggedExclusion = false;

                    policies.Add(policy);
                }
            }

            /* Sort the list for faster duplicate processing */
            List<Policy> sorted_policies = policies.
                OrderBy(p => p.HolderName).
                ThenBy(p => p.BirthDate).
                ThenBy(p => p.Address1).
                ToList();

            /* Clean for better memory usage */
            policies.Clear();

            /* For generating unique ID - Assume max rows of 1M */
            int fileId = policyFeedId * 1000000;
            int cntId = 0;

            /* Excluding spaces - 
             * If first [acceptableLength] characters of address are equal AND
             * If HolderNames are equal AND
             * If BirthDates are equal
             * This is an EXACT DUPLICATE */
            Policy previous_policy = null;
            foreach (Policy p in sorted_policies)
            {
                /* If not equal to previous record - assign new ID */
                if (previous_policy == null ||
                    p.HolderName != previous_policy.HolderName || 
                    p.BirthDate != previous_policy.BirthDate)
                {
                    int holderId = ((fileId) + (++cntId));

                    p.PossibleDuplicate = false;
                    p.ExactDuplicate = false;
                    p.PolicyHolderId = holderId;
                }
                else
                {
                    p.PossibleDuplicate = true;
                    p.PolicyHolderId = previous_policy.PolicyHolderId;

                    string prev_addr = String.Concat(
                            previous_policy.Address1, 
                            previous_policy.Address2,
                            previous_policy.Address3,
                            previous_policy.Address4,
                            previous_policy.Address5).
                        Replace("NO ", "").
                        Replace(" ", "").
                        Replace(".", "").
                        Replace("'", "").
                        Replace("#", "").
                        Replace("-", "");
                    string curr_addr = String.Concat(
                            p.Address1, 
                            p.Address2,
                            p.Address3,
                            p.Address4,
                            p.Address5).
                        Replace("NO ", "").
                        Replace(" ", "").
                        Replace(".", "").
                        Replace("'", "").
                        Replace("#", "").
                        Replace("-", "");

                    if (prev_addr.Length >= UnacceptableAddressLen && curr_addr.Length >= UnacceptableAddressLen)
                    {
                        if (prev_addr.Substring(0, UnacceptableAddressLen) == curr_addr.Substring(0, UnacceptableAddressLen))
                            p.ExactDuplicate = true;
                        else
                            p.ExactDuplicate = false;
                    }
                    else
                    {
                        /* If does not meet criteria - just mark as not duplicate */
                        p.ExactDuplicate = false;
                    }
                }

                previous_policy = p;
            }

            /* Normal exit */
            return sorted_policies;
        }
    }
}
