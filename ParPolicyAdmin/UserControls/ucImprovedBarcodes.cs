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

        public ucImprovedBarcodes(int projectId)
        {
            InitializeComponent();

            _activeProjectId = projectId;
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

        }
    }
}
