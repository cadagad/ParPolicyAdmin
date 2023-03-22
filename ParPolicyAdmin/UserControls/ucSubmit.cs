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

namespace ParPolicyAdmin.UserControls
{
    public partial class ucSubmit : UserControl
    {
        int _activeProjectId = 0;

        public SourceRepo sourceFeedRepo;
        public PolicyFeedRepo policyFeedRepo;

        private List<VwSourceSummaryByProject> SourceSummary;

        public ucSubmit(int projectId)
        {
            InitializeComponent();

            sourceFeedRepo = new SourceRepo();
            policyFeedRepo = new PolicyFeedRepo();

            _activeProjectId = projectId;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();

            foreach (DataGridViewRow r in dgvSources.SelectedRows)
            {
                codes.Add(r.Cells["Code"].Value.ToString());
            }

            if (codes.Count > 0)
            {
                Reports report = new Reports();
                report.GenerateCstcFeed(codes);
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
    }
}
