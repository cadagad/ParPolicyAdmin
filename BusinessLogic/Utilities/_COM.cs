using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public static class _COM
    {
        /* Barcode constants */
        public const int BCODE_LEN_MINLINE = 470;

        public const int BCODE_START_POS_POLICYNUM = 18;
        public const int BCODE_LEN_POLICYNUM = 10;

        public const int BCODE_START_POS_BARCODENUM = 461;
        public const int BCODE_LEN_BARCODENUM = 7;

        /* Barcode constants - END */

        public const int LEN_MINLINE = 359;
        public const int LEN_SYSCODE = 3;
        public const int LEN_POLICYNUM = 10;
        public const int LEN_CERTNUM = 9;
        public const int LEN_HOLDERNAME = 32;
        public const int LEN_ADDRESS = 32;
        public const int LEN_POSTAL = 9;
        public const int LEN_COUNTRY = 1;
        public const int LEN_PROVINCE = 2;
        public const int LEN_LANGUAGE = 1;
        public const int LEN_BIRTHDATE = 8;
        public const int LEN_VOTES = 9;
        public const int LEN_KEYNAME = 32;

        /* Start Positions from input feed - 0 base index */
        public const int START_POS_SYSCODE = 14;
        public const int START_POS_POLICYNUM = 20;
        public const int START_POS_CERTNUM = 30;
        public const int START_POS_HOLDERNAME = 40;
        public const int START_POS_ADDRESS_1 = 72;
        public const int START_POS_ADDRESS_2 = 104;
        public const int START_POS_ADDRESS_3 = 136;
        public const int START_POS_ADDRESS_4 = 168;
        public const int START_POS_ADDRESS_5 = 200;
        public const int START_POS_ADDRESS_6 = 232;
        public const int START_POS_ADDRESS_7 = 264;
        public const int START_POS_POSTAL = 296;
        public const int START_POS_COUNTRY = 305;
        public const int START_POS_PROVINCE = 306;
        public const int START_POS_LANGUAGE = 308;
        public const int START_POS_VOTES = 309;
        public const int START_POS_BIRTHDATE = 318;
        public const int START_POS_KEYNAME = 327;

        /* Start Positions from Annual.txt 0 base index */
        public const int LEN_ANNUAL_MINLINE = 461;

        public const int START_POS_ANNUAL_SYSCODE = 15;
        public const int START_POS_ANNUAL_POLICYNUM = 18;
        public const int START_POS_ANNUAL_POSTAL = 57;
        public const int START_POS_ANNUAL_COUNTRY = 66;
        public const int START_POS_ANNUAL_LANGUAGE = 84;
        public const int START_POS_ANNUAL_HOLDERNAME = 87;
        public const int START_POS_ANNUAL_ADDRESS_1 = 121;
        public const int START_POS_ANNUAL_ADDRESS_2 = 155;
        public const int START_POS_ANNUAL_ADDRESS_3 = 189;
        public const int START_POS_ANNUAL_ADDRESS_4 = 223;
        public const int START_POS_ANNUAL_ADDRESS_5 = 257;
        public const int START_POS_ANNUAL_ADDRESS_6 = 291;
        public const int START_POS_ANNUAL_KEYNAME = 416;

        public static string ConvertDate_yyyyMMdd(string dt)
        {
            string bd = String.Empty;
            try
            {
                if (!String.IsNullOrWhiteSpace(dt))
                    bd = DateTime.ParseExact(dt, "yyyyMMdd", CultureInfo.InvariantCulture).ToShortDateString();
            }
            catch
            {
                bd = String.Empty;
            }

            return bd;
        }

        /* Excel Utilities */
        [DllImport("User32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);
        internal static void KillExcel(Microsoft.Office.Interop.Excel.Application theApp)
        {
            int id = 0;
            IntPtr intptr = new IntPtr(theApp.Hwnd);
            System.Diagnostics.Process p = null;
            try
            {
                GetWindowThreadProcessId(intptr, out id);
                p = System.Diagnostics.Process.GetProcessById(id);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("KillExcel:" + ex.Message);
            }
        }
    }
}
