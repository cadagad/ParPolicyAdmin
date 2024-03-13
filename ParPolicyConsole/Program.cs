using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParPolicyConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Annual_Dropoff = ConfigurationManager.AppSettings["AnnualMailingFeed_Dropoff"];
            string Annual_Staging = ConfigurationManager.AppSettings["AnnualMailingFeed_Staging"];
            string Annual_Archive = ConfigurationManager.AppSettings["AnnualMailingFeed_Archive"];
            string Annual_FeedName = ConfigurationManager.AppSettings["AnnualMailingFeed_Name"];

            string Policy_Staging = ConfigurationManager.AppSettings["PolicyFeed_Staging"];

            string TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            string TriggerFile = ConfigurationManager.AppSettings["TriggerFile_AnnualMailingList"];
            string TriggerFile_LoadFiles = ConfigurationManager.AppSettings["TriggerFile_LoadFiles"];

            string TriggerFile_Policies = "Feeds.txt";

            if (args.Length == 2)
            {
                Console.WriteLine("Usage\n" +
                                  "-----\n");
                Console.WriteLine("upload-policy\n" +
                                  "Command : ParPolicyConsole.exe upload-policy\n" +
                                  "Purpose : No supplied parameter uploads all available files.\n");
                Console.WriteLine("upload-policy <FileName>\n" +
                                  "Command : ParPolicyConsole.exe upload-policy Par_Listing_20230217.txt\n" +
                                  "Purpose : Supplying file name paramter uploads a single file.\n");
                return;

            }

            if (args.Length > 0 && args[0].ToLower() == "upload-policy")
            {
                Console.WriteLine("Processing Upload-Policy...");
                string trigger_policies = Path.Combine(TriggerPath, TriggerFile_LoadFiles);
                Tools tools = new Tools();
                if (File.Exists(trigger_policies))
                {
                    tools.UploadPolicy();
                }
                else
                {
                    Console.WriteLine("No trigger file found for Policy processing\n" +
                        trigger_policies);
                }
            }
            else if (args.Length > 0 && args[0].ToLower() == "upload-barcodes")
            {
                // Console.WriteLine("Processing Upload-Barcodes");
                // Tools tools = new Tools();
                // tools.UploadBarcodes();
            }
            else if (args.Length > 0 && args[0].ToLower() == "upload-annual-mailing-list")
            {
                string trigger = Path.Combine(TriggerPath, TriggerFile);

                /* Check if input feed exists */
                if (File.Exists(trigger))
                {
                    Console.WriteLine("Processing Upload-Annual-Mailing-List");
                    Tools tools = new Tools();
                    tools.UploadAnnualMailingList();

                    File.Delete(trigger);
                }
                else
                {
                    Console.WriteLine("No trigger found for Upload-Annual-Mailing-List.");
                    Console.WriteLine(String.Format("Reference : {0}.", trigger));
                }
            }
            else
            {
                /* If no parameter - process all */
                string trigger_policies = Path.Combine(TriggerPath, TriggerFile_LoadFiles);
                string trigger_annual = Path.Combine(TriggerPath, TriggerFile);
                var waitTime = TimeSpan.FromSeconds(10);

                if (!File.Exists(trigger_policies) && !File.Exists(trigger_annual))
                {
                    Console.WriteLine("No trigger file found for Policy or Annual Mailing\n" +
                        "--------------------------------------------------\n\n" +
                        "Expected trigger files\n" +
                        "Policy         : " + trigger_policies + "\n" +
                        "Annual Mailing : " + trigger_annual + "\n\n" +
                        "--------------------------------------------------\n\n" +
                        "No action required. Closing app...");
                    
                    Thread.Sleep(waitTime);
                    return;
                }

                Tools tools = new Tools();
                if (File.Exists(trigger_policies))
                {
                    Console.WriteLine("Processing Upload-Policy...");
                    tools.UploadPolicy();
                }
                else
                {
                    Console.WriteLine("No trigger file found for Policy processing\n" +
                        trigger_policies);
                }
                
                if (File.Exists(trigger_annual))
                {
                    Console.WriteLine("Processing Upload-Annual-Mailing-List");
                    tools.UploadAnnualMailingList();
                    File.Delete(trigger_annual);
                }

                Thread.Sleep(waitTime);
                return;
            }
        }
    }
}
