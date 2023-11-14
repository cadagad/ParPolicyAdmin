﻿using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

            string staging_folder = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            string[] feedIds = File.ReadAllLines(staging_folder + "\\" + "feedIds.txt");

            try
            {
                DateTime startTime = DateTime.Now;

                foreach (string feed in feedIds)
                {
                    int feedId = 0;
                    if (!Int32.TryParse(feed, out feedId))
                        continue;

                    List<Policy> policies = policyRepo.PolicyFeed_ToList(feedId, staging_folder);

                    int PAGE_SIZE = 5000;
                    List<List<Policy>> chunks = ListExtensions.SplitList(policies, PAGE_SIZE);

                    // int iteration = 0;
                    foreach (List<Policy> p in chunks)
                    {
                        policyRepo.BulkInsertPolicy(p);
                    }

                    policyFeedRepo.SetFeedIsProcessed(feedId);
                }

                DateTime endTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
    }
}
