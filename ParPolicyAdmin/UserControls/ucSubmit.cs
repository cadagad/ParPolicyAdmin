using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucSubmit : UserControl
    {
        int _activeProjectId = 0;

        private string Staging = String.Empty;

        public SourceRepo sourceFeedRepo;
        public PolicyFeedRepo policyFeedRepo;

        private List<VwSourceSummaryByProject> SourceSummary;

        public ucSubmit(int projectId)
        {
            InitializeComponent();

            Staging = ConfigurationManager.AppSettings["PolicyFeed_Staging"];

            sourceFeedRepo = new SourceRepo();
            policyFeedRepo = new PolicyFeedRepo();

            _activeProjectId = projectId;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string folder = String.Empty;
            string fn = ConfigurationManager.AppSettings["CstcFeed"];

            /* User selects folder to save */
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    folder = fbd.SelectedPath;
                else
                    return;
            }

            /* Delete if exist */
            if (!Directory.Exists(folder))
                return;

            List<string> codes = new List<string>();
            foreach (DataGridViewRow r in dgvSources.SelectedRows)
            {
                codes.Add(r.Cells["Code"].Value.ToString());
            }

            Reports report = new Reports();
            report.GenerateCstcFeed(codes, folder);

            MessageBox.Show(String.Format("Vendor feed successfully generated. Please check:\n {0}", folder + "\\" + fn),
                    "Success!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void ucSubmit_Load(object sender, EventArgs e)
        {
            this.GridRefresh();
        }


        private void GridRefresh()
        {
            SourceSummary = sourceFeedRepo.GetAllSources_WithCount(_activeProjectId);

            var bindingList = new BindingList<VwSourceSummaryByProject>(SourceSummary);
            var source = new BindingSource(bindingList, null);
            dgvSources.DataSource = source;

            if (source.Count > 0)
            {
                dgvSources.Columns["Records"].Visible = false;
                dgvSources.Columns["Code"].Width = 150;
                dgvSources.Columns["Code"].HeaderText = "Source";
                //dgvSources.Columns["Records"].Width = 75;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string feedName = ConfigurationManager.AppSettings["CstcFeed"];
            string MftFolder = ConfigurationManager.AppSettings["MFT_Dropoff"];

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Search for " + feedName;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            string srcFile = String.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                srcFile = openFileDialog.FileName;
            }
            else
            {
                return;
            }

            try
            {
                string check = Path.GetFullPath(MftFolder);

                if (!Directory.Exists(MftFolder))
                    Directory.CreateDirectory(MftFolder);

                string mftFile = String.Empty;
                if (MftFolder.EndsWith("\\"))
                {
                    mftFile = MftFolder + feedName;
                }
                else
                {
                    mftFile = MftFolder + "\\" + feedName;
                }

                File.Copy(srcFile, mftFile, true);

                MessageBox.Show(String.Format("File successfully uploaded to MFT. " +
                    "\nPlease wait for email confirmation."),
                    "Success!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Invalid configuration path for MFT_Dropoff : " + MftFolder);
            }
        }
    }
}
