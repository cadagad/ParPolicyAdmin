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
    public partial class frmReviewDeficient : Form
    {
        private bool donePopulating = false;

        private PolicyRepo policyRepo;
        private string _source;

        private List<VwPolicySummary> policies;

        /* For change tracking */
        private List<int> idChanged = new List<int>();

        public frmReviewDeficient(string source)
        {
            InitializeComponent();

            policyRepo = new PolicyRepo();
            _source = source;
        }

        private void frmReviewDeficient_Load(object sender, EventArgs e)
        {
            policies = policyRepo.GetDeficients_BySourceCode(_source);

            GridRefresh();

            donePopulating = true;
        }

        private void GridRefresh(string sortBy = null)
        {
            try
            {
                List<VwPolicySummary> filtered = new List<VwPolicySummary>();

                int addr1 = Int32.Parse(tbAddr1.Value.ToString());
                int addr2 = Int32.Parse(tbAddr2.Value.ToString());
                int addr3 = Int32.Parse(tbAddr3.Value.ToString());
                int addr4 = Int32.Parse(tbAddr4.Value.ToString());
                int addr5 = Int32.Parse(tbAddr5.Value.ToString());
                if (sortBy == "PolicyNumber")
                {
                    filtered = policies.Where(p =>
                        (p.Address1.Length <= addr1) &&
                        (p.Address2.Length <= addr2) &&
                        (p.Address3.Length <= addr3) &&
                        (p.Address4.Length <= addr4) &&
                        (p.Address5.Length <= addr5))
                        .OrderBy(p => p.PolicyNumber).ToList();
                }
                else if (sortBy == "HolderName")
                {
                    filtered = policies.Where(p =>
                        (p.Address1.Length <= addr1) &&
                        (p.Address2.Length <= addr2) &&
                        (p.Address3.Length <= addr3) &&
                        (p.Address4.Length <= addr4) &&
                        (p.Address5.Length <= addr5))
                        .OrderBy(p => p.HolderName).ToList();
                }
                else if (sortBy == "BirthDate")
                {
                    filtered = policies.Where(p =>
                        (p.Address1.Length <= addr1) &&
                        (p.Address2.Length <= addr2) &&
                        (p.Address3.Length <= addr3) &&
                        (p.Address4.Length <= addr4) &&
                        (p.Address5.Length <= addr5))
                        .OrderBy(p => p.BirthDate).ToList();
                }
                else if (sortBy == "Address1")
                {
                    filtered = policies.Where(p =>
                        (p.Address1.Length <= addr1) &&
                        (p.Address2.Length <= addr2) &&
                        (p.Address3.Length <= addr3) &&
                        (p.Address4.Length <= addr4) &&
                        (p.Address5.Length <= addr5))
                        .OrderBy(p => p.Address1).ToList();
                }
                else
                {
                    filtered = policies.Where(p =>
                        (p.Address1.Length <= addr1) &&
                        (p.Address2.Length <= addr2) &&
                        (p.Address3.Length <= addr3) &&
                        (p.Address4.Length <= addr4) &&
                        (p.Address5.Length <= addr5)).ToList();
                }

                lblRecordCount.Text = "Record(s) : " + filtered.Count().ToString();

                var bindingList = new BindingList<VwPolicySummary>(filtered);
                var src = new BindingSource(bindingList, null);

                dgvPolicyList.DataSource = src;

                if (src.Count > 0)
                {
                    dgvPolicyList.Columns["PolicyId"].Visible = false;
                    dgvPolicyList.Columns["PossibleDuplicate"].Visible = false;
                    dgvPolicyList.Columns["UserFlaggedDuplicate"].Visible = false;

                    dgvPolicyList.Columns["PolicyNumber"].ReadOnly = true;
                    dgvPolicyList.Columns["HolderName"].ReadOnly = true;
                    dgvPolicyList.Columns["BirthDate"].ReadOnly = true;
                    dgvPolicyList.Columns["Address1"].ReadOnly = true;
                    dgvPolicyList.Columns["Address2"].ReadOnly = true;
                    dgvPolicyList.Columns["Address3"].ReadOnly = true;
                    dgvPolicyList.Columns["Address4"].ReadOnly = true;
                    dgvPolicyList.Columns["Address5"].ReadOnly = true;
                    dgvPolicyList.Columns["PossibleDuplicate"].ReadOnly = true;
                    dgvPolicyList.Columns["UserFlaggedDuplicate"].ReadOnly = true;

                    dgvPolicyList.Columns["HolderName"].Width = 175;
                    dgvPolicyList.Columns["BirthDate"].Width = 85;
                    dgvPolicyList.Columns["Address1"].Width = 200;
                    dgvPolicyList.Columns["Address2"].Width = 200;
                    dgvPolicyList.Columns["Address3"].Width = 140;
                    dgvPolicyList.Columns["Address4"].Width = 140;
                    dgvPolicyList.Columns["Address5"].Width = 140;
                    dgvPolicyList.Columns["UserFlaggedDuplicate"].Width = 85;
                    dgvPolicyList.Columns["UserFlaggedDeficient"].Width = 85;

                    dgvPolicyList.Columns["UserFlaggedDeficient"].HeaderText = "Deficient?";

                    foreach (DataGridViewColumn column in dgvPolicyList.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tbAddr1_ValueChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void tbAddr2_ValueChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void tbAddr3_ValueChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void tbAddr4_ValueChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void tbAddr5_ValueChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPolicyList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell) row.Cells["UserFlaggedDeficient"];
                chk.Value = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPolicyList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["UserFlaggedDeficient"];
                chk.Value = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VwPolicySummary> changedPolicies = new List<VwPolicySummary>();

            foreach (int i in idChanged)
            {
                VwPolicySummary dp = policies.Where(p => p.PolicyId == i).FirstOrDefault();
                changedPolicies.Add(dp);
            }

            bool ret = policyRepo.SaveReviewDeficient(changedPolicies);
            if (ret)
            {
                MessageBox.Show("Successfully saved " + idChanged.Count() + " records!",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                changedPolicies.Clear();
                idChanged.Clear();

                policies = policyRepo.GetDeficients_BySourceCode(_source);
                donePopulating = false;

                GridRefresh();

                donePopulating = true;
            }
        }

        private void dgvPolicyList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (donePopulating == false)
                return;

            int row = e.RowIndex;

            /* Add to change tracker - for use during save */
            int policyId = Int32.Parse(dgvPolicyList.Rows[row].Cells["PolicyId"].Value.ToString());
            if (!idChanged.Contains(policyId))
                idChanged.Add(policyId);
        }

        private void dgvPolicyList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sortByString = dgvPolicyList.Columns[e.ColumnIndex].DataPropertyName;
            GridRefresh(sortByString);
        }
    }
}
