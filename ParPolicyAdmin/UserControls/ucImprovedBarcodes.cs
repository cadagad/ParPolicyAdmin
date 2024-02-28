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

namespace ParPolicyAdmin.UserControls
{
    public partial class ucImprovedBarcodes : UserControl
    {
        int _activeProjectId = 0;

        public BarcodeRepo barcodeRepo;
        private List<VwBarcodeMailing> barcodeMailings;

        public ucImprovedBarcodes(int projectId)
        {
            InitializeComponent();
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
            tbSearch.Enabled = true;
            MessageBox.Show("Analyze data complete.\nPlease input barcodes you wish to search.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }

        private void ucImprovedBarcodes_Load(object sender, EventArgs e)
        {
            tbSearch.Enabled = false;
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

            List<VwBarcodeMailing> subList = new List<VwBarcodeMailing>();
            if (barcodeMailings.Count() > 0)
            {
                subList = barcodeMailings.Where(bm => barcodesToSearch.Contains(bm.BarcodeNumber)).ToList();
                GridRefresh(subList);
            }
        }

        private void GridRefresh(List<VwBarcodeMailing> filteredList)
        {
            var bindingList = new BindingList<VwBarcodeMailing>(filteredList);
            var src = new BindingSource(bindingList, null);

            dgvMailingList.DataSource = src;

            dgvMailingList.Columns["CountryCode"].Visible = false;
            dgvMailingList.Columns["LanguageCode"].Visible = false;
            dgvMailingList.Columns["PostalCode"].Visible = false;
            dgvMailingList.Columns["KeyName"].Visible = false;

            dgvMailingList.Columns["SystemCode"].ReadOnly = true;
            dgvMailingList.Columns["PolicyNumber"].ReadOnly = true;
            dgvMailingList.Columns["BarcodeNumber"].ReadOnly = true;
            dgvMailingList.Columns["HolderName"].ReadOnly = true;
            dgvMailingList.Columns["Address1"].ReadOnly = true;
            dgvMailingList.Columns["Address2"].ReadOnly = true;
            dgvMailingList.Columns["Address3"].ReadOnly = true;
            dgvMailingList.Columns["Address4"].ReadOnly = true;
            dgvMailingList.Columns["Address5"].ReadOnly = true;
            dgvMailingList.Columns["Address6"].ReadOnly = true;

            dgvMailingList.Columns["PolicyNumber"].Width = 90;
            dgvMailingList.Columns["BarcodeNumber"].Width = 75;
            dgvMailingList.Columns["HolderName"].Width = 175;
            dgvMailingList.Columns["SystemCode"].Width = 50;
            dgvMailingList.Columns["Address1"].Width = 225;
            dgvMailingList.Columns["Address2"].Width = 225;
            dgvMailingList.Columns["Address3"].Width = 175;
            dgvMailingList.Columns["Address4"].Width = 175;
            dgvMailingList.Columns["Address5"].Width = 175;
            dgvMailingList.Columns["Address6"].Width = 175;

            dgvMailingList.Columns["SystemCode"].HeaderText = "Code";
            dgvMailingList.Columns["PolicyNumber"].HeaderText = "Policy";
            dgvMailingList.Columns["BarcodeNumber"].HeaderText = "Barcode";
        }
    }
}
