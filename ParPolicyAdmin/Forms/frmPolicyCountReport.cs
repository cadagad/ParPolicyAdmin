using BusinessLogic.Data;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.Forms
{
    public partial class frmPolicyCountReport : Form
    {
        PolicyRepo policyRepo = new PolicyRepo();
        List<VwPolicyCount> report = new List<VwPolicyCount>();

        public frmPolicyCountReport()
        {
            InitializeComponent();

            policyRepo = new PolicyRepo();
            report = policyRepo.GetPolicyReport_ActiveProject();
        }

        private void frmPolicyCountReport_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void GridRefresh()
        {
            var bindingList = new BindingList<VwPolicyCount>(report);
            var source = new BindingSource(bindingList, null);
            dgvReport.DataSource = source;

            if (source.Count > 0)
            {
                dgvReport.Columns["SortOrder"].Visible = false;
                
                dgvReport.Columns["Name"].Width = 300;
                dgvReport.Columns["Description"].Width = 100;
            }
        }

        private void btnExportText_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count < 2)
                return;

            int rowCount = 0;
            string text = String.Empty;
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                rowCount++;
                if (rowCount <= 2)
                {
                    text = text + row.Cells["Name"].Value.ToString() + "\n";
                }
                else
                {
                    text = text + 
                        row.Cells["Name"].Value.ToString().PadRight(40) + 
                        row.Cells["Description"].Value.ToString().PadRight(10) + 
                        "\n";
                }
            }

            /* User selects folder to save */
            string folder = String.Empty;
            string file = "Par Policy Count - " + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    folder = fbd.SelectedPath;
                else
                    return;
            }

            string path = Path.Combine(folder, file);
            File.WriteAllText(path, text);

            MessageBox.Show(String.Format("Export successful! See file:" +
                    "\n" + path),
                    "Success!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}
