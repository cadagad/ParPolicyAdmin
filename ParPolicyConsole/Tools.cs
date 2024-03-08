using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ParPolicyConsole
{
    internal class Tools
    {
        private const string FILENAME = "";

        public bool UploadPolicy()
        {
            List<PolicyFeed> PolicyFeeds = new List<PolicyFeed>();
            PolicyFeedRepo policyFeedRepo = new PolicyFeedRepo();
            PolicyRepo policyRepo = new PolicyRepo();

            string TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            string TriggerFile = ConfigurationManager.AppSettings["TriggerFile_LoadFiles"];

            string path = String.Empty;
            if (TriggerPath.EndsWith("\\"))
            {
                path = TriggerPath + TriggerFile;
            }
            else
            {
                path = TriggerPath + "\\" + TriggerFile;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("Error : Feeds.txt is expected on " + TriggerPath);
                return false;
            }

            string staging_folder = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            string[] feedIds = File.ReadAllLines(path);

            try
            {
                DateTime startTime = DateTime.Now;

                foreach (string feed in feedIds)
                {
                    int feedId = policyRepo.GetFeedId_ByFeedNameInActiveProject(feed);
                    if (feedId == -1)
                    {
                        Console.WriteLine(String.Format("Feed ID for requested file does not exist : {0}", feed));
                        continue;
                    }

                    List<Policy> policies = policyRepo.PolicyFeed_ToList(feedId, staging_folder);

                    Console.WriteLine(String.Format("File {0} is being processed.", feed));
                    Console.WriteLine(String.Format("Processing {0} records. Please wait.", policies.Count().ToString()));

                    int PAGE_SIZE = 5000;
                    List<List<Policy>> chunks = ListExtensions.SplitList(policies, PAGE_SIZE);

                    int iteration = 0;
                    foreach (List<Policy> p in chunks)
                    {
                        Console.WriteLine(String.Format("Inserting to database : {0} of {1}",
                            (PAGE_SIZE * iteration), policies.Count()));
                        policyRepo.BulkInsertPolicy(p);
                        iteration++;
                    }

                    policyFeedRepo.SetFeedIsProcessed(feedId);
                    Console.WriteLine(String.Format("File {0} successfully processed!" +
                        "\n--------------------------------------------------\n\n", feed));
                }

                DateTime endTime = DateTime.Now;

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public bool ExtractMailingList()
        {
            //string staging_folder = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            //string path = staging_folder + "\\" + "MailingCodes.txt";
            //if (!File.Exists(path))
            //{
            //    Console.WriteLine("Error : MailingCodes.txt is expected on " + staging_folder);
            //    return false;
            //}

            //string[] mailingCodes = File.ReadAllLines(path);
            //List<string> codes = mailingCodes.ToList();

            //Reports report = new Reports();
            //report.GenerateCstcFeed(codes);

            //File.Delete(path);

            return true;
        }

        public void UploadAnnualMailingList()
        {         
            Console.WriteLine("Uploading - AnnualMailingList - Start...");

            AnnualMailingListRepo annualMailingListRepo = new AnnualMailingListRepo();
            List<AnnualMailingList> annualMailings = annualMailingListRepo.Process_AnnualMailing_ToList();

            Console.WriteLine("Inserting records by chunk.");
            Console.WriteLine(String.Format("Total number of records : {0}.", annualMailings.Count()));

            int PAGE_SIZE = 2000;
            List<List<AnnualMailingList>> chunks = ListExtensions.SplitList(annualMailings, PAGE_SIZE);

            int iteration = 0;
            foreach (List<AnnualMailingList> b in chunks)
            {
                Console.WriteLine(String.Format("Processing records {0} of {1}",
                    (iteration * PAGE_SIZE),
                    annualMailings.Count()));

                iteration++;

                annualMailingListRepo.Insert_AnnualMailings_ByBulk(b);
            }

            Console.WriteLine("Uploading - AnnualMailingList - End...");
        }

        public bool UploadBarcodes()
        {
            string staging_folder = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            string path = staging_folder + "\\" + "Trigger_Barcodes.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error : Trigger_Barcodes.txt is expected on " + staging_folder);
                return false;
            }

            string[] feedIds = File.ReadAllLines(path);

            foreach (string f in feedIds)
            {
                int feedId = 0;
                if (!Int32.TryParse(f, out feedId))
                {
                    Console.WriteLine("Invalid Barcode FeedId : " + f);
                    continue;
                }

                BarcodeFeedRepo barcodeFeedRepo = new BarcodeFeedRepo();
                BarcodeRepo barcodeRepo = new BarcodeRepo();

                List<Barcode> barcodes = barcodeRepo.Process_AllRecords_ToList(feedId, staging_folder);

                int PAGE_SIZE = 5000;
                List<List<Barcode>> chunks = ListExtensions.SplitList(barcodes, PAGE_SIZE);

                int iteration = 0;
                foreach (List<Barcode> b in chunks)
                {
                    Console.WriteLine(String.Format("Processing records {1} of {2}",
                        (iteration * PAGE_SIZE),
                        barcodes.Count()));

                    iteration++;

                    barcodeRepo.BulkInsertPolicy(b);
                }

                barcodeFeedRepo.SetFeedIsProcessed(feedId);
            }

            File.Delete(path);

            return true;
        }
    }
}
