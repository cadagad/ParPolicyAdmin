using BusinessLogic.Data;
using BusinessLogic.Migrations;
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

using Md = BusinessLogic.Models;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucAnnualMailingList : UserControl
    {
        private string Dropoff = String.Empty;
        private string Staging = String.Empty;
        private string Archive = String.Empty;
        private string FeedName = String.Empty;

        private string TriggerPath = String.Empty;
        private string TriggerFile = String.Empty;

        private AnnualMailingListRepo AnnualMailingListRepo;
        private SourceRepo sourceRepo;

        private List<string> sources;

        public ucAnnualMailingList()
        {
            InitializeComponent();

            AnnualMailingListRepo = new AnnualMailingListRepo();
            sourceRepo = new SourceRepo();
            sources = sourceRepo.GetAllSourceCodes();

            BindingSource bs = new BindingSource();
            bs.DataSource = sources;
            cbSystemCode.DataSource = bs;
            cbSystemCode.SelectedIndex = 1;
        }

        private void ucAnnualMailingList_Load(object sender, EventArgs e)
        {
            Dropoff = ConfigurationManager.AppSettings["AnnualMailingFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["AnnualMailingFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["AnnualMailingFeed_Archive"];
            FeedName = ConfigurationManager.AppSettings["AnnualMailingFeed_Name"];

            TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            TriggerFile = ConfigurationManager.AppSettings["TriggerFile_AnnualMailingList"];

            lblDropoffPath.Text = Dropoff;

            GridRefresh();
        }

        private void GridRefresh(string sysCode = null, string searchText = null)
        {
            string code = String.Empty;

            if (sysCode == null)
                code = "C01";
            else
                code = sysCode;

            List<Md.AnnualMailingList> mailings = new List<Md.AnnualMailingList>();
            mailings = AnnualMailingListRepo.GetAnnualMailings_BySystemCode(code, searchText);

            lblRecordCount.Text = "Record(s) : " + mailings.Count().ToString();

            var bindingList = new BindingList<Md.AnnualMailingList>(mailings);
            var src = new BindingSource(bindingList, null);

            dgvAnnualMailingList.DataSource = src;

            if (src.Count > 0)
            {
                dgvAnnualMailingList.Columns["AnnualMailingListId"].Visible = false;
                dgvAnnualMailingList.Columns["LineNumber"].Visible = false;
                dgvAnnualMailingList.Columns["CountryCode"].Visible = false;
                dgvAnnualMailingList.Columns["LanguageCode"].Visible = false;
                dgvAnnualMailingList.Columns["PostalCode"].Visible = false;
                dgvAnnualMailingList.Columns["KeyName"].Visible = false;

                dgvAnnualMailingList.Columns["UserFlaggedDuplicate"].Visible = false;
                dgvAnnualMailingList.Columns["UserFlaggedDeficient"].Visible = false;
                dgvAnnualMailingList.Columns["UserFlaggedExclusion"].Visible = false;
                dgvAnnualMailingList.Columns["UserManualAdd"].Visible = false;

                dgvAnnualMailingList.Columns["Address5"].Visible = false;
                dgvAnnualMailingList.Columns["Address6"].Visible = false;

                dgvAnnualMailingList.Columns["PolicyNumber"].ReadOnly = true;
                dgvAnnualMailingList.Columns["SystemCode"].ReadOnly = true;
                dgvAnnualMailingList.Columns["HolderName"].ReadOnly = true;
                dgvAnnualMailingList.Columns["Address1"].ReadOnly = true;
                dgvAnnualMailingList.Columns["Address2"].ReadOnly = true;
                dgvAnnualMailingList.Columns["Address3"].ReadOnly = true;
                dgvAnnualMailingList.Columns["Address4"].ReadOnly = true;

                dgvAnnualMailingList.Columns["PolicyNumber"].Width = 90;
                dgvAnnualMailingList.Columns["HolderName"].Width = 175;
                dgvAnnualMailingList.Columns["SystemCode"].Width = 50;
                dgvAnnualMailingList.Columns["Address1"].Width = 225;
                dgvAnnualMailingList.Columns["Address2"].Width = 225;
                dgvAnnualMailingList.Columns["Address3"].Width = 175;
                dgvAnnualMailingList.Columns["Address4"].Width = 175;

                dgvAnnualMailingList.Columns["SystemCode"].HeaderText = "Code";
                dgvAnnualMailingList.Columns["PolicyNumber"].HeaderText = "Policy";
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string feed = Path.Combine(Dropoff, FeedName);

            /* Check if input feed exists */
            if (!File.Exists(feed))
            {
                MessageBox.Show(
                    String.Format("Annual.txt file not found on {0}.", Dropoff),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Uploading Annual.txt will overwrite the records. Continue?", 
                "Confirm", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel)
                return;


            /* Normal process - File exist and confirmation is provided */
            string trigger = Path.Combine(TriggerPath, TriggerFile);

            /* Create directory structure if not exist */
            if (!Directory.Exists(TriggerPath))
                Directory.CreateDirectory(Path.GetDirectoryName(trigger));

            /* Delete trigger file if exist */
            if (File.Exists(trigger))
                File.Delete(trigger);

            /* Create trigger file */
            File.Create(trigger).Dispose();
        }

        private void cbSystemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = cbSystemCode.Text;
            tbSearch.Text = String.Empty;

            GridRefresh(code);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string code = cbSystemCode.Text;
            string searchText = tbSearch.Text;

            if (searchText.Length > 0 && searchText.Length <= 3)
            {
                MessageBox.Show("Please input at least 3 characters in search bar.", 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            GridRefresh(code, searchText);
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
