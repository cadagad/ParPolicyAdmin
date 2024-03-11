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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ParPolicyAdmin.Forms
{
    public partial class frmEmailConfigUpdate : Form
    {
        public List<EmailConfig> EmailConfigs;
        public EmailConfigRepo emailConfigRepo;

        public string NewItemName = String.Empty;
        bool IsAdd;

        public frmEmailConfigUpdate()
        {
            InitializeComponent();
            emailConfigRepo = new EmailConfigRepo();
            IsAdd = true;
        }

        public frmEmailConfigUpdate(string name)
        {
            InitializeComponent();
            emailConfigRepo = new EmailConfigRepo();

            EmailConfig emailConfig = emailConfigRepo.GetAllEmailConfig().Where(ec => ec.Name == name.Trim()).FirstOrDefault();
            if (emailConfig == null)
            {
                MessageBox.Show("Configuration item [" + name + "] does not exist",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            tbName.Text = name.Trim();
            tbName.ReadOnly = true;

            tbValue.Text = emailConfig.Value;
            IsAdd = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<EmailConfig> emailConfigs = emailConfigRepo.GetAllEmailConfig();

            string name = tbName.Text.Trim();
            string value = tbValue.Text.Trim();

            /* Check if config name already exist */
            EmailConfig check = emailConfigs.Where(ec => ec.Name.Equals(name)).FirstOrDefault();
            if (check != null && IsAdd) 
            {
                MessageBox.Show("Configuration item [" + name + "] already exists",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(name))
            {
                MessageBox.Show("[Name] and [Value] fields are mandatory",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            NewItemName = name;
            if (IsAdd)
            {
                emailConfigRepo.AddEmailTemplate(name, value);
            }
            else
            {
                emailConfigRepo.UpdateEmailTemplate(name, value);
            }
            this.Close();
        }
    }
}
