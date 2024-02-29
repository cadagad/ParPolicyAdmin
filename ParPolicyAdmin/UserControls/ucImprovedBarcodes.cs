using BusinessLogic.Data;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Md = BusinessLogic.Models;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucImprovedBarcodes : UserControl
    {
        int _activeProjectId = 0;

        public BarcodeRepo barcodeRepo;
        private List<VwBarcodeMailing> barcodeMailings;

        List<VwBarcodeMailing> SubList;
        AnnualMailingListRepo AMLR;

        public ucImprovedBarcodes(int projectId)
        {
            InitializeComponent();

            SubList = new List<VwBarcodeMailing>();
            AMLR = new AnnualMailingListRepo();

            _activeProjectId = projectId;
            barcodeRepo = new BarcodeRepo();
            barcodeMailings = new List<VwBarcodeMailing>();
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Search for ALL_RECORDS.TXT";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text (*.txt)|*.txt";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            string srcFile = String.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                srcFile = openFileDialog.FileName;
                if (Path.GetFileName(srcFile).ToUpper() != "ALL_RECORDS.TXT")
                {
                    MessageBox.Show("The file selected is not ALL_RECORDS.TXT",
                        "Invalid File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tbAllRecordsPath.Text = String.Empty;
                    return;
                }

                tbAllRecordsPath.Text = srcFile;
            }
            else
            {
                return;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbAllRecordsPath.Text))
            {
                MessageBox.Show("Please select ALL_RECORDS.TXT file.",
                        "Invalid Operation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }

            barcodeMailings = barcodeRepo.Process_AllRecords_ToList(tbAllRecordsPath.Text);

            if (barcodeMailings.Count > 0)
            {
                tbSearch.Enabled = true;
                btnSearch.Enabled = true;

                MessageBox.Show("Analyze data complete.\nPlease input barcodes you wish to search.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else
            {
                tbSearch.Enabled = false;
                btnSearch.Enabled = false;
                btnCheckAll.Enabled = false;
                btnUncheckAll.Enabled = false;
                btnSearch.Enabled = false;
                btnAdd.Enabled = false;

                MessageBox.Show(
                    "Either no records were found or format is incorrect.\n" +
                    "Please select another file.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void ucImprovedBarcodes_Load(object sender, EventArgs e)
        {
            tbSearch.Enabled = false;
            btnCheckAll.Enabled = false;
            btnUncheckAll.Enabled = false;
            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> barcodesToSearch = new List<string>();

            var textLines = tbSearch.Text.Split('\n');
            foreach(string line in textLines)
            {
                if (line.Length == 0)
                    continue;

                /* Barcode length is 7 */
                if (line.Trim().Length > 7)
                    continue;

                barcodesToSearch.Add(line.Trim());
            }

            
            if (barcodeMailings.Count() > 0)
            {
                SubList = barcodeMailings.Where(bm => barcodesToSearch.Contains(bm.BarcodeNumber)).ToList();
                GridRefresh();
            }
        }

        private void GridRefresh()
        {
            if (SubList == null || SubList.Count == 0)
                return;
            
            var bindingList = new BindingList<VwBarcodeMailing>(SubList);
            var src = new BindingSource(bindingList, null);

            dgvMailingList.DataSource = src;

            dgvMailingList.Columns["CountryCode"].Visible = false;
            dgvMailingList.Columns["LanguageCode"].Visible = false;
            dgvMailingList.Columns["PostalCode"].Visible = false;
            dgvMailingList.Columns["KeyName"].Visible = false;
            dgvMailingList.Columns["Address5"].Visible = false;
            dgvMailingList.Columns["Address6"].Visible = false;

            dgvMailingList.Columns["SystemCode"].ReadOnly = true;
            dgvMailingList.Columns["PolicyNumber"].ReadOnly = true;
            dgvMailingList.Columns["BarcodeNumber"].ReadOnly = true;
            dgvMailingList.Columns["HolderName"].ReadOnly = true;
            dgvMailingList.Columns["Address1"].ReadOnly = true;
            dgvMailingList.Columns["Address2"].ReadOnly = true;
            dgvMailingList.Columns["Address3"].ReadOnly = true;
            dgvMailingList.Columns["Address4"].ReadOnly = true;

            dgvMailingList.Columns["PolicyNumber"].Width = 90;
            dgvMailingList.Columns["BarcodeNumber"].Width = 75;
            dgvMailingList.Columns["HolderName"].Width = 175;
            dgvMailingList.Columns["SystemCode"].Width = 50;
            dgvMailingList.Columns["Address1"].Width = 225;
            dgvMailingList.Columns["Address2"].Width = 225;
            dgvMailingList.Columns["Address3"].Width = 175;
            dgvMailingList.Columns["Address4"].Width = 175;
            dgvMailingList.Columns["AddFlag"].Width = 50;

            dgvMailingList.Columns["SystemCode"].HeaderText = "Code";
            dgvMailingList.Columns["PolicyNumber"].HeaderText = "Policy";
            dgvMailingList.Columns["BarcodeNumber"].HeaderText = "Barcode";
            dgvMailingList.Columns["AddFlag"].HeaderText = "Add?";

            btnCheckAll.Enabled = true;
            btnUncheckAll.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMailingList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["AddFlag"];
                chk.Value = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMailingList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["AddFlag"];
                chk.Value = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> allPolicyNumbers = SubList.Where(s => s.AddFlag == true).Select(s => s.PolicyNumber).ToList();

            List<string> duplicateMailing = AMLR.FindDuplicateMailing(allPolicyNumbers);

            /* Prepare error message for duplicates */
            string warningMessage = "The following policy holders are already in Mailing:\n";
            foreach (VwBarcodeMailing mailing in SubList
                .Where(s => s.AddFlag == true && duplicateMailing.Contains(s.PolicyNumber))
                .ToList())
            {
                warningMessage = warningMessage + " * " + mailing.SystemCode + " " + mailing.PolicyNumber + " : " + mailing.HolderName + "\n";
            }

            if (duplicateMailing.Count > 0) 
            {
                MessageBox.Show(warningMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /* Disregard duplicate entries */
            string successMessage = "The following policy holders is added to Mailing:\n";

            List<Md.AnnualMailingList> annualMailingToAdd =  new List<Md.AnnualMailingList>();
            foreach (VwBarcodeMailing mailing in SubList
                .Where(s => s.AddFlag == true && !duplicateMailing.Contains(s.PolicyNumber))
                .ToList())
            {
                successMessage = successMessage + " * " + mailing.SystemCode + " " + mailing.PolicyNumber + " : " + mailing.HolderName + "\n";

                Md.AnnualMailingList aml = new Md.AnnualMailingList();
                aml.SystemCode = mailing.SystemCode;
                aml.HolderName = mailing.HolderName.ToUpper();
                aml.PolicyNumber = mailing.PolicyNumber.PadLeft(10, '0');
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

                aml.LineNumber = -1;
                aml.UserFlaggedDuplicate = false;
                aml.UserFlaggedDeficient = false;
                aml.UserFlaggedExclusion = false;
                aml.UserManualAdd = true;

                annualMailingToAdd.Add(aml);
            }

            AMLR.Insert_AnnualMailings_ByBulk(annualMailingToAdd);
            if (annualMailingToAdd.Count > 0)
            {
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
