using BusinessLogic.Data;
using BusinessLogic.Models;
using ParPolicyAdmin.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin
{
    public partial class frmMain : Form
    {
        UserControl currentUserControl = null;

        public ProjectRepo projectRepo;
        public Project CurrentProject;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucProjects();
            
            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            if (CurrentProject != null)
            {
                currentUserControl = new ucLoadFiles(CurrentProject.ProjectId);

                currentUserControl.Dock = DockStyle.Fill;
                this.panelBody.Controls.Add(currentUserControl);
            }
            else
            {
                MessageBox.Show("Please activate a project first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateLabels();
            lblLoggedAs.Text = Program.CurrentUser;
        }

        private void UpdateLabels()
        {
            projectRepo = new ProjectRepo();
            CurrentProject = projectRepo.GetAllProjects().Where(p => p.IsActive == true).FirstOrDefault();
            if (CurrentProject != null)
                lblFeature.Text = "Project : (" + CurrentProject.Name + ")";
            else
                lblFeature.Text = "Project : (N/A)";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucSubmit(CurrentProject.ProjectId);

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnReviewData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();
            
            currentUserControl = new ucReviewData(CurrentProject.ProjectId);

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnLoadBarcodes_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucBarcodes(CurrentProject.ProjectId);

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnLateReturns_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucLateReturns(CurrentProject.ProjectId);

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }
    }
}
