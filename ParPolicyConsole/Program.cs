﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParPolicyConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                Tools tools = new Tools();
                tools.UploadPolicy();
            }
            else if (args.Length > 0 && args[0].ToLower() == "extract-mailing-list")
            {
                Tools tools = new Tools();
                tools.UploadPolicy();
            }
            else
            {
                /* Temporary for testing */
                Tools tools = new Tools();
                //tools.UploadPolicy();
                tools.ExtractMailingList();

            }
        }
    }
}
