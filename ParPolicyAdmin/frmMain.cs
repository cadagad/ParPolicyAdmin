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
using System.DirectoryServices.AccountManagement;
using System.Configuration;

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
            /* Login */
            /* Split domain and user */
            string[] str = Program.CurrentUser.Split('\\');
            if (str.Length != 2)
            {
                MessageBox.Show("Invalid user : " + Program.CurrentUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            string domain = str[0];
            string user = str[1];

            PrincipalContext ctx = null;

            // Set up domain context
            try
            {
                ctx = new PrincipalContext(ContextType.Domain, domain);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to Manulife LDAP.\nError : " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ctx == null)
                Environment.Exit(0);

            // Find a user
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(ctx, user);

            // Find the group in question
            string config = ConfigurationManager.AppSettings["AdminGroup"];
            string[] adminGroups = config.Split(',');
            bool isLoggedIn = false;

            if (userPrincipal != null)
            {
                foreach (string grp in adminGroups.Where(s => s.Trim().ToLower().StartsWith(domain.ToLower())))
                {
                    GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, grp);
                    if (groupPrincipal != null && userPrincipal.IsMemberOf(groupPrincipal))
                    {
                        isLoggedIn = true;
                        break;
                    }
                }
            }

            if (isLoggedIn == false)
            {
                MessageBox.Show(String.Format(
                        "User does not to access Par Policy:\n" +
                        "[{0}]", Program.CurrentUser),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            
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

            currentUserControl = new ucImprovedBarcodes(CurrentProject.ProjectId);

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnLateReturns_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucEmailConfiguration();

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }

        private void btnAnnualMailingList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateLabels();

            if (currentUserControl != null)
                this.panelBody.Controls.Clear();

            currentUserControl = new ucAnnualMailingList();

            currentUserControl.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(currentUserControl);

            Cursor.Current = Cursors.Default;
        }
    }
}
