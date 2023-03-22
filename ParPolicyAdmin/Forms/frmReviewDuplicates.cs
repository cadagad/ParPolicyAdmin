using BusinessLogic.Data;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.Forms
{
    public partial class frmReviewDuplicates : Form
    {
        private bool donePopulating = false;

        private PolicyRepo policyRepo;
        private string _source;

        private List<VwDuplicatePolicy> policies;

        /* For change tracking */
        private List<int> idChanged = new List<int>();

        public frmReviewDuplicates(string source)
        {
            InitializeComponent();
            policyRepo = new PolicyRepo();
            _source = source;
        }

        private void frmReviewDuplicates_Load(object sender, EventArgs e)
        {
            policies = policyRepo.GetDuplicates_BySourceCode(_source);

            GridRefresh();
            donePopulating = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VwDuplicatePolicy> changedPolicies = new List<VwDuplicatePolicy>();

            foreach (int i in idChanged)
            {
                VwDuplicatePolicy dp = policies.Where(p => p.PolicyId == i).FirstOrDefault();
                changedPolicies.Add(dp);
            }

            bool ret = policyRepo.SaveReviewDuplicate(changedPolicies);
            if (ret)
            {
                changedPolicies.Clear();
                idChanged.Clear();

                policies = policyRepo.GetDuplicates_BySourceCode(_source);
                donePopulating = false;

                GridRefresh();

                donePopulating = true;
            }
        }

        private void dgvDuplicates_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (donePopulating == false)
                return;

            int row = e.RowIndex;

            /* Add to change tracker - for use during save */
            int policyId = Int32.Parse(dgvDuplicates.Rows[row].Cells["PolicyId"].Value.ToString());
            if (!idChanged.Contains(policyId))
                idChanged.Add(policyId);
        }

        private void GridRefresh(string searchText = null)
        {
            List<VwDuplicatePolicy> filtered = new List<VwDuplicatePolicy>();

            if (searchText != null)
                filtered = policies.
                    Where(p => p.HolderName.
                    StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase)).
                    ToList();
            else
                filtered = policies;

            lblRecordCount.Text = "Record(s) : " + filtered.Count().ToString();

            var bindingList = new BindingList<VwDuplicatePolicy>(filtered);
            var src = new BindingSource(bindingList, null);

            dgvDuplicates.DataSource = src;

            if (src.Count > 0)
            {
                dgvDuplicates.Columns["PolicyId"].Visible = false;
                dgvDuplicates.Columns["PossibleDuplicate"].Visible = false;

                dgvDuplicates.Columns["PolicyNumber"].ReadOnly = true;
                dgvDuplicates.Columns["HolderName"].ReadOnly = true;
                dgvDuplicates.Columns["BirthDate"].ReadOnly = true;
                dgvDuplicates.Columns["Address1"].ReadOnly = true;
                dgvDuplicates.Columns["Address2"].ReadOnly = true;
                dgvDuplicates.Columns["PossibleDuplicate"].ReadOnly = true;

                dgvDuplicates.Columns["HolderName"].Width = 200;
                dgvDuplicates.Columns["Address1"].Width = 250;
                dgvDuplicates.Columns["Address2"].Width = 250;

                dgvDuplicates.Columns["UserFlaggedDuplicate"].HeaderText = "Duplicate?";
            }

            foreach (DataGridViewRow row in dgvDuplicates.Rows)
            {
                bool val = Convert.ToBoolean(row.Cells["PossibleDuplicate"].Value.ToString());
                if (!val)
                    row.DefaultCellStyle.BackColor = Color.Beige;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            GridRefresh(search);
        }
    }
}
