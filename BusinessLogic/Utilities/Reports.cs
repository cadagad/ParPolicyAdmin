using BusinessLogic.Data;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;

namespace BusinessLogic.Utilities
{
    public class Reports
    {
        public PolicyRepo policyRepo;

        public Reports()
        {
            policyRepo = new PolicyRepo();
        }



        public void GenerateCstcFeed(List<string> codes)
        {
            List<Policy> policies = policyRepo.GetPolicies_BySourceCode(codes);

            string fn = ConfigurationManager.AppSettings["CstcFeed"];
            string outputFolder = ConfigurationManager.AppSettings["Output_Staging"];
            string path = Path.Combine(outputFolder, fn);

            /* Delete if exist */
            if (File.Exists(path))
                File.Delete(path);

            /* Process limited rows for better efficiency */
            int limiter = 100;
            int last_row = policies.Count();

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
                    string p = policies[index].ToCstcFormat() + "\n";
                text = text + p;
                }

                /* Append data to out_file */
                File.AppendAllText(path, text);
            }
        }

        //public void GenerateDuplicateFeed(string code)
        //{
        //    List<Policy> policies = policyRepo.GetDuplicates_BySourceCode(code);

        //    /* Output folder */
        //    string outputFile = "Duplicates_" + code;
        //    string outputFolder = ConfigurationManager.AppSettings["Output_Staging"];
        //    string outputPath = Path.Combine(outputFolder, outputFile);

        //    /* Delete if exist */
        //    if (File.Exists(outputPath))
        //        File.Delete(outputPath);

        //    /* Process limited rows for better efficiency */
        //    int limiter = 100;
        //    int last_row = policies.Count();

        //    for (int i = 0; i <= (last_row / limiter); i++)
        //    {
        //        string text = String.Empty;

        //        #region Header
        //        /* If first - add header row */
        //        if (i == 0)
        //            text = String.Format(
        //                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|" +
        //                "{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|" +
        //                "{20}|{21}|{22}\n",
        //                "PolicyId",
        //                "SystemCode",
        //                "PolicyNumber",
        //                "Cert",
        //                "HolderName",
        //                "Address1",
        //                "Address2",
        //                "Address3",
        //                "Address4",
        //                "Address5",
        //                "Address6",
        //                "Address7",
        //                "PostalCode",
        //                "CountryCode",
        //                "ProvinceStateCode",
        //                "LanguageCode",
        //                "BirthDate",
        //                "ShareVotes",
        //                "KeyName",
        //                "FileName",
        //                "LineNumber",
        //                "PolicyHolderId",
        //                "MultiplePolicyFlag");
        //        #endregion

        //        for (int j = 0; j < limiter; j++)
        //        {
        //            int index = (limiter * i) + j;

        //            /* Exit if last row */
        //            if (index == last_row)
        //                break;

        //            /* Party */
        //            string p = policies[index].ToPipeDelimited() + "\n";
        //            text = text + p;
        //        }

        //        /* Append data to out_file */
        //        File.AppendAllText(outputPath, text);
        //    }
        //}

        //public void GenerateDuplicateFeed(string code)
        //{
        //    List<Policy> policies = policyRepo.GetDuplicates_BySourceCode(code);

        //    /* Output folder */
        //    string outputFile = "Duplicates_" + code;
        //    string outputFolder = ConfigurationManager.AppSettings["Output_Staging"];
        //    string outputPath = Path.Combine(outputFolder, outputFile);

        //    /* Delete if exist */
        //    if (File.Exists(outputPath))
        //        File.Delete(outputPath);

        //    /* Template folder */
        //    string templateFolder = ConfigurationManager.AppSettings["Path_Template"];
        //    string templateFile = ConfigurationManager.AppSettings["File_Template_Duplicate"];
        //    string template = Path.Combine(templateFolder, templateFile);

        //    string clipboard = String.Empty;
        //    foreach (Policy sp in policies)
        //    {
        //        clipboard = clipboard + sp.ToTabDelimited() + "\n";
        //    }

        //    /* Declare excel file */
        //    Excel.Application app = null;
        //    Excel.Workbook wb = null;
        //    Excel.Worksheet ws = null;

        //    try
        //    {
        //        app = new Excel.Application();
        //        wb = app.Workbooks.Open(template);
        //        ws = (Excel.Worksheet)wb.Worksheets["Sheet1"];

        //        int currRow = 2;

        //        /* Save to output */
        //        app.DisplayAlerts = false;
        //        wb.SaveAs(outputPath,
        //            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
        //            Type.Missing,
        //            Type.Missing,
        //            false,
        //            false,
        //            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        wb.Close();
        //        _COM.KillExcel(app);
        //        System.Threading.Thread.Sleep(100);
        //    }
        //}
    }
}
