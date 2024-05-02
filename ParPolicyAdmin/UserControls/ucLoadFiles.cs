using BusinessLogic.Data;
using BusinessLogic.Models;
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

using BusinessLogic.Utilities;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucLoadFiles : UserControl
    {
        int _activeProjectId = 0;
        
        public List<PolicyFeed> PolicyFeeds;
        public PolicyFeedRepo policyFeedRepo;
        public PolicyRepo policyRepo;

        private string Dropoff = String.Empty;
        private string Staging = String.Empty;
        private string Archive = String.Empty;
        private string TriggerPath = String.Empty;
        private string TriggerFile = String.Empty;

        public ucLoadFiles(int projectId)
        {
            InitializeComponent();
            policyFeedRepo = new PolicyFeedRepo();
            policyRepo = new PolicyRepo();

            _activeProjectId = projectId;

            Dropoff = ConfigurationManager.AppSettings["PolicyFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["PolicyFeed_Archive"];
            TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            TriggerFile = ConfigurationManager.AppSettings["TriggerFile_LoadFiles"];
        }

        private void ucLoadFiles_Load(object sender, EventArgs e)
        {
            if (_activeProjectId > 0)
            {
                GridRefresh();
            }

            lblMessage.Text = "Select operation...";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_activeProjectId <= 0)
            {
                MessageBox.Show("No active project selected.");
                return;
            }

            try
            {
                bool ret = policyFeedRepo.AddPolicyFeeds(_activeProjectId, Dropoff, Staging, Archive);
                GridRefresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_activeProjectId <= 0)
            {
                MessageBox.Show("No active project selected.");
                return;
            }

            PolicyFeeds = policyFeedRepo.GetPolicyFeeds_ByProjectId(_activeProjectId);
            int activeStatusCount = PolicyFeeds.Where(pf => pf.Status != "Not processed" && pf.Status != "Complete").Count();
            if (activeStatusCount > 0)
            {
                MessageBox.Show("Please wait for the current process to complete.\n" +
                    "For assistance, please contact IT support.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            tmrRefresh.Enabled = true;

            try
            {
                DateTime startTime = DateTime.Now;

                string fn = String.Empty;
                if (TriggerPath.EndsWith("\\"))
                {
                    fn = TriggerPath + TriggerFile;
                }
                else
                {
                    fn = TriggerPath + "\\" + TriggerFile;
                }

                /* Delete if exist */
                if (File.Exists(fn))
                    File.Delete(fn);

                policyFeedRepo = new PolicyFeedRepo();
                foreach (DataGridViewRow r in dgvFeeds.SelectedRows)
                {
                    int feedId = (int)r.Cells["PolicyFeedId"].Value;
                    policyFeedRepo.SetFeedIsRequesting(feedId);

                    string feedName = r.Cells["FileName"].Value.ToString();
                    File.AppendAllText(fn, (feedName + "\n"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            GridRefresh();
            Cursor.Current = Cursors.Default;
        }

        private void GridRefresh()
        {
            PolicyFeeds = policyFeedRepo.GetPolicyFeeds_ByProjectId(_activeProjectId);

            var bindingList = new BindingList<PolicyFeed>(PolicyFeeds);
            var source = new BindingSource(bindingList, null);
            dgvFeeds.DataSource = source;

            if (source.Count > 0)
            {
                dgvFeeds.Columns["PolicyFeedId"].Visible = false;
                dgvFeeds.Columns["IsValid"].Visible = false;
                dgvFeeds.Columns["ProcessedBy"].Visible = false;
                dgvFeeds.Columns["ProcessedDate"].Visible = false;
                dgvFeeds.Columns["UniqueRecordCount"].Visible = false;
                dgvFeeds.Columns["ExceptionReason"].Visible = false;
                dgvFeeds.Columns["ProjectId"].Visible = false;
                dgvFeeds.Columns["Project"].Visible = false;
                dgvFeeds.Columns["IsProcessed"].Visible = false;

                /* Column width */
                dgvFeeds.Columns["FileName"].Width = 280;

                /* Display order */
                dgvFeeds.Columns["FileName"].DisplayIndex = 0;
                dgvFeeds.Columns["RowCount"].DisplayIndex = 1;
                dgvFeeds.Columns["Status"].DisplayIndex = 2;
            }

            int activeStatusCount = PolicyFeeds.Where(pf => pf.Status != "Not processed" && pf.Status != "Complete").Count();
            if (activeStatusCount > 0)
            {
                tmrRefresh.Enabled = true;
                tmrRefresh.Stop();
                tmrRefresh.Start();
            }
            else
            {
                tmrRefresh.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            GridRefresh();
        }
    }
}
