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

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Text.RegularExpressions;
using BusinessLogic.Utilities;
using ParPolicyAdmin.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucEmailConfiguration : UserControl
    {
        public List<EmailConfig> EmailConfigs;
        public EmailConfigRepo emailConfigRepo;

        public ucEmailConfiguration()
        {
            InitializeComponent();
            emailConfigRepo = new EmailConfigRepo();
        }

        private void ucEmailConfiguration_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void GridRefresh()
        {
            List<EmailConfig> sublist = new List<EmailConfig>();

            EmailConfigs = emailConfigRepo.GetAllEmailConfig();

            sublist = EmailConfigs.Where(e =>
                e.Name != "Email Body" && e.Name != "Email Subject" && e.Name != "Email To" && e.Name != "Email Cc").ToList();

            var bindingList = new BindingList<EmailConfig>(sublist);
            var source = new BindingSource(bindingList, null);
            dgvEmailConfig.DataSource = source;

            dgvEmailConfig.Columns["EmailConfigId"].Visible = false;
            dgvEmailConfig.Columns["Type"].Visible = false;

            dgvEmailConfig.Columns["Name"].Width = 135;
            dgvEmailConfig.Columns["Value"].Width = 280;

            EmailConfig emailBody = EmailConfigs.Where(e => e.Name == "Email Body").FirstOrDefault();
            if (emailBody != null)
            {
                tbEmailTemplate.Text = emailBody.Value;
            }

            EmailConfig emailSubject = EmailConfigs.Where(e => e.Name == "Email Subject").FirstOrDefault();
            if (emailSubject != null)
            {
                tbEmailSubject.Text = emailSubject.Value;
            }

            EmailConfig emailTo = EmailConfigs.Where(e => e.Name == "Email To").FirstOrDefault();
            if (emailTo != null)
            {
                tbEmailTo.Text = emailTo.Value;
            }

            EmailConfig emailCc = EmailConfigs.Where(e => e.Name == "Email Cc").FirstOrDefault();
            if (emailCc != null)
            {
                tbEmailCc.Text = emailCc.Value;
            }
        }

        private void dgvEmailConfig_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = dgvEmailConfig.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        string text = (string)
                               "<<" + dgvEmailConfig.Rows[info.RowIndex].Cells["Name"].Value + ">>";
                        if (text != null)
                            dgvEmailConfig.DoDragDrop(text, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void tbEmailTemplate_DragEnter(object sender, DragEventArgs e)
        {
            string tt = e.Data.GetData(DataFormats.Text).ToString();
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tbEmailTemplate_DragDrop(object sender, DragEventArgs e)
        {
            int i;
            string s;

            // Get start position to drop the text.
            i = tbEmailTemplate.SelectionStart;
            s = tbEmailTemplate.Text.Substring(i);
            tbEmailTemplate.Text = tbEmailTemplate.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.
            tbEmailTemplate.Text = tbEmailTemplate.Text + e.Data.GetData(DataFormats.Text).ToString();
            tbEmailTemplate.Text = tbEmailTemplate.Text + s;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = tbEmailSubject.Text;
            mailItem.To = tbEmailTo.Text;
            mailItem.CC = tbEmailCc.Text;
            mailItem.Body = emailConfigRepo.getActualEmailBody();
            mailItem.Display(true);
        }

        

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            string to = tbEmailTo.Text;
            string cc = tbEmailCc.Text;
            string subject = tbEmailSubject.Text;
            string body = tbEmailTemplate.Text;

            emailConfigRepo.SaveEmailTemplate(to, cc, subject, body);

            MessageBox.Show(
                    String.Format("Successfully updated the email template!"),
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newItemName = String.Empty;

            frmEmailConfigUpdate frm = new frmEmailConfigUpdate();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            newItemName = frm.NewItemName;

            if (!String.IsNullOrEmpty(newItemName)) 
            {
                MessageBox.Show("Configuration item [" + newItemName + "] added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GridRefresh();
            }

            frm.Close();
            frm.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmailConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvEmailConfig.SelectedRows[0];
            string name = selectedRow.Cells["Name"].Value.ToString();

            if (selectedRow.Cells["Type"].Value.ToString() == "Dynamic")
            {
                MessageBox.Show("Cannot modify a fixed value item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmEmailConfigUpdate frm = new frmEmailConfigUpdate(name);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            string newItemName = frm.NewItemName;
            if (!String.IsNullOrEmpty(newItemName))
            {
                MessageBox.Show("Configuration item [" + name + "] updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GridRefresh();
            }

            frm.Close();
            frm.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmailConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvEmailConfig.SelectedRows[0];
            if (selectedRow.Cells["Type"].Value.ToString() == "Dynamic")
            {
                MessageBox.Show("Cannot remove a fixed value item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = selectedRow.Cells["Name"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                String.Format("Are you sure you want to remove entry [{0}]?", name),
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel)
                return;

            emailConfigRepo.DeleteEmailTemplate(id);
            MessageBox.Show("Configuration item [" + name + "] removed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            GridRefresh();
        }
    }
}
