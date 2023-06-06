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

namespace ParPolicyAdmin.UserControls
{
    public partial class ucLateReturns : UserControl
    {
        int _activeProjectId = 0;
        private BarcodeRepo barcodeRepo;

        public ucLateReturns(int projectId)
        {
            InitializeComponent();
            barcodeRepo = new BarcodeRepo();

            _activeProjectId = projectId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            if (String.IsNullOrEmpty(search) || search.Length <= 3)
            {
                MessageBox.Show("Please input at least 3 characters in search bar.");
                return;
            }

            GridRefresh(search);
        }

        private void GridRefresh(string search = "")
        {
            List<VwBarcodePolicy> filtered = new List<VwBarcodePolicy>();

            if (!String.IsNullOrEmpty(search))
            {
                filtered = barcodeRepo.GetAllBarcodePolicy_ByProjectId(_activeProjectId, search);
            }
            else
            {
                filtered = barcodeRepo.GetAllBarcodePolicy_ByProjectId(_activeProjectId);
            }
            

            var bindingList = new BindingList<VwBarcodePolicy>(filtered);
            var src = new BindingSource(bindingList, null);

            dgvBarcodes.DataSource = src;

            if (src.Count > 0)
            {
                dgvBarcodes.Columns["BarcodeId"].Visible = false;

                dgvBarcodes.Columns["BarcodeNumber"].ReadOnly = true;
                dgvBarcodes.Columns["PolicyNumber"].ReadOnly = true;
                dgvBarcodes.Columns["HolderName"].ReadOnly = true;
                dgvBarcodes.Columns["BirthDate"].ReadOnly = true;
                dgvBarcodes.Columns["Address1"].ReadOnly = true;
                dgvBarcodes.Columns["Address2"].ReadOnly = true;
                dgvBarcodes.Columns["Address3"].ReadOnly = true;

                dgvBarcodes.Columns["BarcodeNumber"].Width = 85;
                dgvBarcodes.Columns["PolicyNumber"].Width = 85;
                dgvBarcodes.Columns["HolderName"].Width = 175;
                dgvBarcodes.Columns["BirthDate"].Width = 85;
                dgvBarcodes.Columns["Address1"].Width = 200;
                dgvBarcodes.Columns["Address2"].Width = 200;
                dgvBarcodes.Columns["Address3"].Width = 200;
            }

        }
    }
}
