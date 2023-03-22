using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Data;
using BusinessLogic.Models;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucProjects : UserControl
    {
        public List<Project> Projects;
        public ProjectRepo projectRepo;
        public ucProjects()
        {
            InitializeComponent();
            projectRepo = new ProjectRepo();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            pnlNewProject.Visible = true;
            pnlDescription.Visible = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            pnlNewProject.Visible = false;
            pnlDescription.Visible = true;

            int projectId = (int) dgvProjects.CurrentRow.Cells["ProjectId"].Value;
            bool ret = projectRepo.SetActive(projectId);

            lblMessage.Visible = true;
            if (ret)
            {
                lblMessage.Text = "Open successful!";
            }
            else
            {
                lblMessage.Text = "Error : Another project is active";
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to archive this project?",
                "Confirm?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Cancel)
                return;

            pnlNewProject.Visible = false;
            pnlDescription.Visible = true;

            int projectId = (int)dgvProjects.CurrentRow.Cells["ProjectId"].Value;
            bool ret = projectRepo.SetArchived(projectId);

            lblMessage.Visible = true;
            if (ret)
            {
                lblMessage.Text = "Archiving successful";
            }
            else
            {
                lblMessage.Text = "Error : Project is inactive";
            }
        }
        private void ucProjects_Load(object sender, EventArgs e)
        {
            cbType.Items.Add("Annual");
            cbType.Items.Add("Triennial");
            cbType.SelectedIndex = 0;
            tbYear.Value = DateTime.Now.Year;

            pnlNewProject.Visible = false;
            pnlDescription.Visible = true;

            this.GridRefresh();
            btnArchive.Enabled = false;
            btnOpen.Enabled = false;

            dtpDueDate.Value = DateTime.Now.Date;
        }

        private void pnlNewProject_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            tbName.Text = String.Empty;
            tbYear.Value = DateTime.Now.Year;
            dtpDueDate.Value = DateTime.Now;

            lblNameMsg.Visible = false;
            lblYearMsg.Visible = false;
            lblDueDateMsg.Visible = false;
            lblTypeMsg.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool errorFlag = false;
            

            if (tbName.Text.Length == 0 || tbName.Text.Length > 50)
            {
                errorFlag = true;
                lblNameMsg.Text = "Name must be 1-50 characters.";
                lblNameMsg.Visible = true;
            }

            if (errorFlag == true)
                return;

            /* If no errors - add to db */
            Project project = new Project()
            {
                Name = tbName.Text,
                Type = cbType.Text,
                Year = Decimal.ToInt32(tbYear.Value),
                DueDate = dtpDueDate.Value.Date,
                IsActive = false,
                IsArchived = false,
                CreatedBy = Program.CurrentUser,
                CreatedDate = DateTime.Now
            };

            bool ret = projectRepo.AddProject(project);

            if (ret)
            {
                this.GridRefresh();

                btnReset.PerformClick();
                lblSubmitMsg.Visible = true;
                lblSubmitMsg.Text = "Project successfully added!";
            }
        }


        private void GridRefresh()
        {
            if (cbShowArchived.Checked)
                Projects = projectRepo.GetAllProjects();
            else
                Projects = projectRepo.GetAllProjects().Where(p => p.IsArchived == false).ToList();

            var bindingList = new BindingList<Project>(Projects);
            var source = new BindingSource(bindingList, null);
            dgvProjects.DataSource = source;

            dgvProjects.Columns["ProjectId"].Visible = false;
            dgvProjects.Columns["Type"].Visible = false;
            dgvProjects.Columns["Year"].Visible = false;
            dgvProjects.Columns["DueDate"].Visible = false;
            dgvProjects.Columns["CreatedBy"].Visible = false;
            dgvProjects.Columns["CreatedDate"].Visible = false;
            dgvProjects.Columns["IsActive"].Visible = false;
            dgvProjects.Columns["IsArchived"].Visible = false;

            dgvProjects.Columns["Name"].Width = 285;
        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProjects.CurrentRow == null)
                return;

            if ((bool)dgvProjects.CurrentRow.Cells["IsActive"].Value == false)
                btnArchive.Enabled = false;
            else
                btnArchive.Enabled = true;

            if ((bool)dgvProjects.CurrentRow.Cells["IsActive"].Value == true ||
                (bool)dgvProjects.CurrentRow.Cells["IsArchived"].Value == true)
                btnOpen.Enabled = false;
            else
                btnOpen.Enabled = true;
        }

        private void cbShowArchived_CheckedChanged(object sender, EventArgs e)
        {
            GridRefresh();
        }
    }
}
