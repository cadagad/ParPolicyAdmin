using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ParPolicyAdmin.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucReviewData : UserControl
    {
        private int _activeProjectId = 0;

        private SourceRepo sourceRepo;
        private PolicyRepo policyRepo;

        private List<VwSourceSummaryByProject> SourceSummary;

        public ucReviewData(int projectId)
        {
            InitializeComponent();

            sourceRepo = new SourceRepo();
            policyRepo = new PolicyRepo();

            _activeProjectId = projectId;
        }

        private void ucReviewData_Load(object sender, EventArgs e)
        {
            this.GridRefresh();
        }

        private void GridRefresh()
        {
            SourceSummary = sourceRepo.GetAllSources_WithCount(_activeProjectId);

            var bindingList = new BindingList<VwSourceSummaryByProject>(SourceSummary);
            var source = new BindingSource(bindingList, null);
            dgvSources.DataSource = source;

            if (source.Count > 0)
            {
                dgvSources.Columns["Records"].Visible = false;
                dgvSources.Columns["Code"].Width = 150;
                dgvSources.Columns["Code"].HeaderText = "Source";
                dgvSources.Columns["HasRecords"].Width = 75;
                dgvSources.Columns["HasRecords"].HeaderText = "DataLoaded";
                //dgvSources.Columns["Records"].Width = 75;
            }
        }

        private void btnReviewDuplicates_Click(object sender, EventArgs e)
        {
            if (dgvSources.SelectedRows.Count == 0)
                return;

            string code = dgvSources.SelectedRows[0].Cells["Code"].Value.ToString();

            frmReviewDuplicates frm = new frmReviewDuplicates(code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            frm.Close();
            frm.Dispose();
        }

        private void btnReviewDeficient_Click(object sender, EventArgs e)
        {
            if (dgvSources.SelectedRows.Count == 0)
                return;

            string code = dgvSources.SelectedRows[0].Cells["Code"].Value.ToString();

            frmReviewDeficient frm = new frmReviewDeficient(code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            frm.Close();
            frm.Dispose();
        }
    }
}
