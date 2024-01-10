﻿using BusinessLogic.Models;
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
            string Dropoff = ConfigurationManager.AppSettings["AnnualMailingFeed_Dropoff"];
            string Staging = ConfigurationManager.AppSettings["AnnualMailingFeed_Staging"];
            string Archive = ConfigurationManager.AppSettings["AnnualMailingFeed_Archive"];
            string FeedName = ConfigurationManager.AppSettings["AnnualMailingFeed_Name"];

            string TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            string TriggerFile = ConfigurationManager.AppSettings["TriggerFile_AnnualMailingList"];

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
                Tools tools = new Tools();
                tools.UploadPolicy();
            }
            else if (args.Length > 0 && args[0].ToLower() == "extract-mailing-list")
            {
                Console.WriteLine("Processing Extract-Mailing-List");
                Tools tools = new Tools();
                tools.ExtractMailingList();
            }
            else if (args.Length > 0 && args[0].ToLower() == "upload-barcodes")
            {
                Console.WriteLine("Processing Upload-Barcodes");
                Tools tools = new Tools();
                tools.UploadBarcodes();
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
                Tools tools = new Tools();

                Console.WriteLine("Processing Upload-Policy...");
                //tools.UploadPolicy();

                Console.WriteLine("Processing Extract-Mailing-List");
                //tools.ExtractMailingList();

                Console.WriteLine("Processing Upload-Annual-Mailing-List");
                tools.UploadAnnualMailingList();
            }

            /* Crude temporary solution */
            var waitTime = TimeSpan.FromSeconds(30);

            while (true)
            {
                bool fileFound = false;
                if (File.Exists(@"C:\temp\Feeds.txt"))
                {
                    Console.WriteLine("Feeds.txt found....");
                    fileFound = true;
                }

                if (fileFound == false)
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + " : No files found...");

                Thread.Sleep(waitTime);
            }
        }

    }
}
