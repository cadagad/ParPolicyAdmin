using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class AnnualMailingListRepo
    {

        private readonly AppDbContext _appDbContext;
        List<string> sourceList;

        private int UnacceptableAddressLen = 5;

        private string Dropoff = String.Empty;
        private string Staging = String.Empty;
        private string Archive = String.Empty;
        private string FeedName = String.Empty;

        private string TriggerPath = String.Empty;
        private string TriggerFile = String.Empty;

        public AnnualMailingListRepo()
        {
            _appDbContext = new AppDbContext();
            sourceList = _appDbContext.Sources.Select(s => s.Code).ToList();

            Dropoff = ConfigurationManager.AppSettings["AnnualMailingFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["AnnualMailingFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["AnnualMailingFeed_Archive"];
            FeedName = ConfigurationManager.AppSettings["AnnualMailingFeed_Name"];

            TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            TriggerFile = ConfigurationManager.AppSettings["TriggerFile_AnnualMailingList"];
        }

        public List<AnnualMailingList> GetAnnualMailings_BySystemCode(string code, string search = null)
        {
            List<AnnualMailingList> mailingList = new List<AnnualMailingList>();

            if (String.IsNullOrWhiteSpace(search))
            {
                mailingList = _appDbContext.AnnualMailingList
                .Where(aml => aml.SystemCode == code)
                .ToList();
            }
            else
            {
                mailingList = _appDbContext.AnnualMailingList
                .Where(aml => aml.SystemCode == code && 
                             (aml.PolicyNumber.Contains(search) || aml.HolderName.Contains(search)))
                .ToList();
            }
            
            return mailingList;
        }

        public List<AnnualMailingList> GetAnnualMailings_NoTracking_BySystemCode(string code, string search = null)
        {
            List<AnnualMailingList> mailingList = new List<AnnualMailingList>();

            if (String.IsNullOrWhiteSpace(search))
            {
                mailingList = _appDbContext.AnnualMailingList
                    .AsNoTracking()
                    .Where(aml => aml.SystemCode == code)
                    .ToList();
            }
            else
            {
                mailingList = _appDbContext.AnnualMailingList
                    .AsNoTracking()
                    .Where(aml => aml.SystemCode == code &&
                                 (aml.PolicyNumber.Contains(search) || aml.HolderName.Contains(search)))
                    .ToList();
            }

            return mailingList;
        }

        public AnnualMailingList GetAnnualMailings_ById(int id)
        {
            AnnualMailingList mailing = new AnnualMailingList();
            
            mailing = _appDbContext.AnnualMailingList
                .Where(aml => aml.AnnualMailingListId == id)
                .FirstOrDefault();

            return mailing;
        }

        public void UpdateMailing_ById(int mailingId, AnnualMailingList mailing)
        {
            AnnualMailingList aml = _appDbContext.AnnualMailingList
                .Where(m => m.AnnualMailingListId == mailingId).FirstOrDefault();

            if (aml != null) 
            {
                aml.SystemCode = mailing.SystemCode.ToUpper();
                aml.HolderName = mailing.HolderName.ToUpper();
                aml.PolicyNumber = mailing.PolicyNumber.ToUpper();
                aml.Address1 = mailing.Address1.ToUpper();
                aml.Address2 = mailing.Address2.ToUpper();
                aml.Address3 = mailing.Address3.ToUpper();
                aml.Address4 = mailing.Address4.ToUpper();
                aml.Address5 = mailing.Address5.ToUpper();
                aml.Address6 = mailing.Address6.ToUpper();
                aml.LanguageCode = mailing.LanguageCode.ToUpper();
                aml.CountryCode = mailing.CountryCode.ToUpper();
                aml.PostalCode = mailing.PostalCode.ToUpper();
                aml.KeyName = mailing.KeyName.ToUpper();

                _appDbContext.SaveChanges();
            }
        }

        public List<AnnualMailingList> Process_AnnualMailing_ToList()
        {
            #region Exception Handling
            Console.WriteLine("Checking folder structure.");

            /* Get filename from db */
            string file = Path.Combine(Dropoff, FeedName);

            if (!Directory.Exists(Dropoff))
                throw new Exception(String.Format("Error : Dropoff {0} does not exist", Dropoff));

            if (!Directory.Exists(Staging))
                throw new Exception(String.Format("Error : Staging {0} does not exist", Staging));

            if (!Directory.Exists(Archive))
                throw new Exception(String.Format("Error : Archive {0} does not exist", Archive));

            if (!File.Exists(file))
                throw new Exception(String.Format("Error : File does not exist", file));
            #endregion

            Console.WriteLine("Checking feed on Dropoff : " + file + ".");
            /* Move file from Dropoff to Staging */
            string staging_file = Path.Combine(Staging, FeedName);

            if (File.Exists(staging_file))
                File.Delete(staging_file);

            File.Copy(file, staging_file);

            if (!File.Exists(staging_file))
                throw new Exception(String.Format("Error : File {0} does not exist on path {1}", FeedName, Staging));

            /* Check if has Policy has existing records - Delete if exist */
            Console.WriteLine("Deleting current mailing list (if exist).");
            int MailingListCheck = _appDbContext.AnnualMailingList.Count();
            if (MailingListCheck > 0)
            {
                this.DeleteCurrentMailingList();
            }

            /* Holder for all AnnualMailingList */
            List<AnnualMailingList> currentPolicies = new List<AnnualMailingList>();

            /* Process the Annual.txt file */
            Console.WriteLine("Reading all lines from Staging : " + staging_file + ".");
            string[] lines = File.ReadAllLines(staging_file);
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

                /* Check if Policy Number is not empty */
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
                policy.UserManualAdd = false;

                currentPolicies.Add(policy);
            }

            return currentPolicies;
        }

        public void Insert_AnnualMailings_ByBulk(List<AnnualMailingList> mailing)
        {
            _appDbContext.AnnualMailingList.AddRange(mailing);
            _appDbContext.SaveChanges();
        }

        public void Insert_AnnualMailings(AnnualMailingList mailing)
        {
            _appDbContext.AnnualMailingList.Add(mailing);
            _appDbContext.SaveChanges();
        }

        public bool DeleteCurrentMailingList()
        {
            try
            {
                string sql = String.Format("DELETE FROM dbo.AnnualMailingLists)");
                _appDbContext.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }

            return true;
        }

        public bool Delete_AnnualMailings_ById(int id)
        {
            AnnualMailingList aml = _appDbContext.AnnualMailingList
                .Where(m => m.AnnualMailingListId == id).FirstOrDefault();

            if (aml == null)
                return false;

            aml.UserFlaggedExclusion = true;
            _appDbContext.SaveChanges();

            return true;
        }

        public void GenerateOutboundFeed(string path)
        {
            List<AnnualMailingList> aml = _appDbContext.AnnualMailingList
                .Where(a => a.UserFlaggedDuplicate == false &&
                            a.UserFlaggedDeficient == false &&
                            a.UserFlaggedExclusion == false).ToList();

            /* Delete if exist */
            if (File.Exists(path))
                File.Delete(path);

            /* Process limited rows for better efficiency */
            int limiter = 1000;
            int last_row = aml.Count();

            for (int i = 0; i <= (last_row / limiter); i++)
            {
                string text = String.Empty;
                for (int j = 0; j < limiter; j++)
                {
                    int index = (limiter * i) + j;

                    /* Exit if last row */
                    if (index == last_row)
                        break;

                    /* Party */
                    string p = aml[index].ToOutboundFormat() + "\n";
                    text = text + p;
                }

                /* Append data to out_file */
                File.AppendAllText(path, text);
            }
        }

        public void UpdateMailingList_FromPolicies()
        {
            try
            {
                string sql =
                    @"update dbo.AnnualMailingLists 
                      set Address1 = b.Address1,
	                      Address2 = b.Address2,
	                      Address3 = b.Address3,
	                      Address4 = b.Address4,
	                      Address5 = b.Address5,
	                      Address6 = b.Address6,
	                      PostalCode = b.PostalCode
                      from dbo.AnnualMailingLists a
                      inner join dbo.Policies b on a.PolicyNumber = b.PolicyNumber and a.SystemCode = b.SystemCode
                      inner join dbo.PolicyFeeds c on b.PolicyFeedId = c.PolicyFeedId
                      inner join dbo.Projects d on c.ProjectId = d.ProjectId
                      where 
	                      d.IsActive = 1 and
	                      a.Address1 <> b.Address1 and
	                      b.Address1 is not null";
                _appDbContext.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public int UpdateMailingList_Count()
        {
            int cnt = (from a in _appDbContext.AnnualMailingList
                       from b in _appDbContext.Policy.Where(x => a.PolicyNumber == x.PolicyNumber && a.SystemCode == x.SystemCode) 
                       join c in _appDbContext.PolicyFeeds on b.PolicyFeedId equals c.PolicyFeedId
                       join d in _appDbContext.Projects on c.ProjectId equals d.ProjectId
                       where d.IsActive == true && a.Address1 != b.Address1
                       select a).Count();

            return cnt;
        }
    }
}
