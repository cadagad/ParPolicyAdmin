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
            string str = String.Empty;
            foreach (DataGridViewRow r in dgvSources.SelectedRows)
            {
                str = str + r.Cells["Code"].Value.ToString() + "\n";
            }

            try
            {
                if (!String.IsNullOrEmpty(str))
                {
                    DateTime startTime = DateTime.Now;

                    string fn = Staging + "\\MailingCodes.txt";

                    /* Delete if exist */
                    if (File.Exists(fn))
                        File.Delete(fn);

                    File.AppendAllText(fn, str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                dgvSources.Columns["Code"].Width = 210;
                dgvSources.Columns["Records"].Width = 75;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
