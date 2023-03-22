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

        public ucLoadFiles(int projectId)
        {
            InitializeComponent();
            policyFeedRepo = new PolicyFeedRepo();
            policyRepo = new PolicyRepo();

            _activeProjectId = projectId;

            Dropoff = ConfigurationManager.AppSettings["PolicyFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["PolicyFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["PolicyFeed_Archive"];
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

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                DateTime startTime = DateTime.Now;

                lblMessage.Visible = true;
                lblMessage.Text = "Begin Processing...";

                foreach (DataGridViewRow r in dgvFeeds.SelectedRows)
                {
                    int feedId = (int)r.Cells["PolicyFeedId"].Value;
                    
                    List<Policy> policies = policyRepo.PolicyFeed_ToList(feedId, Staging);
                    //policyRepo.ReviewDuplicates(ref policies, feedId);
                    
                    int PAGE_SIZE = 5000;
                    List<List<Policy>> chunks = ListExtensions.SplitList(policies, PAGE_SIZE);

                    // int iteration = 0;
                    foreach (List<Policy> p in chunks)
                    {
                        //lblMessage.Text = String.Format("Processing {0} : Records {1} of {2}",
                        //    r.Cells["FileName"].Value.ToString(),
                        //    (iteration * PAGE_SIZE),
                        //    policies.Count());

                        //lblMessage.Refresh();
                        //iteration++;

                        policyRepo.BulkInsertPolicy(p);
                    }

                    policyFeedRepo.SetFeedIsProcessed(feedId);
                }

                DateTime endTime = DateTime.Now;
                lblMessage.Text = String.Format("Processing Successful... {0}m : {1}s", 
                    (endTime - startTime).Minutes.ToString(),  
                    (endTime - startTime).Seconds.ToString());

                MessageBox.Show("Processing is complete!",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

                /* Column width */
                dgvFeeds.Columns["FileName"].Width = 300;

                /* Display order */
                dgvFeeds.Columns["FileName"].DisplayIndex = 0;
                dgvFeeds.Columns["RowCount"].DisplayIndex = 1;
                dgvFeeds.Columns["IsProcessed"].DisplayIndex = 2;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }
    }
}
