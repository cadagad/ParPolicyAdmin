using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucBarcodes : UserControl
    {
        int _activeProjectId = 0;

        public List<BarcodeFeed> BarcodeFeeds;
        public BarcodeFeedRepo barcodeFeedRepo;
        public BarcodeRepo barcodeRepo;

        private string Dropoff = String.Empty;
        private string Staging = String.Empty;
        private string Archive = String.Empty;

        public ucBarcodes(int projectId)
        {
            InitializeComponent();
            barcodeFeedRepo = new BarcodeFeedRepo();
            barcodeRepo = new BarcodeRepo();

            _activeProjectId = projectId;

            Dropoff = ConfigurationManager.AppSettings["BarcodeFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["BarcodeFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["BarcodeFeed_Archive"];
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
                bool ret = barcodeFeedRepo.AddBarcodeFeeds(_activeProjectId, Dropoff, Staging, Archive);
                GridRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void GridRefresh()
        {
            BarcodeFeeds = barcodeFeedRepo.GetBarcodeFeeds_ByProjectId(_activeProjectId);

            var bindingList = new BindingList<BarcodeFeed>(BarcodeFeeds);
            var source = new BindingSource(bindingList, null);
            dgvBarcodes.DataSource = source;

            if (source.Count > 0)
            {
                dgvBarcodes.Columns["BarcodeFeedId"].Visible = false;
                dgvBarcodes.Columns["IsValid"].Visible = false;
                dgvBarcodes.Columns["ProcessedBy"].Visible = false;
                dgvBarcodes.Columns["ProcessedDate"].Visible = false;
                dgvBarcodes.Columns["ExceptionReason"].Visible = false;
                dgvBarcodes.Columns["ProjectId"].Visible = false;
                dgvBarcodes.Columns["Project"].Visible = false;

                /* Column width */
                dgvBarcodes.Columns["FileName"].Width = 300;

                /* Display order */
                dgvBarcodes.Columns["FileName"].DisplayIndex = 0;
                dgvBarcodes.Columns["RowCount"].DisplayIndex = 1;
                dgvBarcodes.Columns["IsProcessed"].DisplayIndex = 2;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
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

                foreach (DataGridViewRow r in dgvBarcodes.SelectedRows)
                {
                    int feedId = (int)r.Cells["BarcodeFeedId"].Value;

                    List<Barcode> barcodes = barcodeRepo.Process_AllRecords_ToList(feedId, Staging);
                    //policyRepo.ReviewDuplicates(ref policies, feedId);

                    int PAGE_SIZE = 5000;
                    List<List<Barcode>> chunks = ListExtensions.SplitList(barcodes, PAGE_SIZE);

                    // int iteration = 0;
                    foreach (List<Barcode> b in chunks)
                    {
                        //lblMessage.Text = String.Format("Processing {0} : Records {1} of {2}",
                        //    r.Cells["FileName"].Value.ToString(),
                        //    (iteration * PAGE_SIZE),
                        //    policies.Count());

                        //lblMessage.Refresh();
                        //iteration++;

                        barcodeRepo.BulkInsertPolicy(b);
                    }

                    barcodeFeedRepo.SetFeedIsProcessed(feedId);
                }

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

        private void ucBarcodes_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }
    }
}
