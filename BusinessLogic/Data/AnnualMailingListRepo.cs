using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}
