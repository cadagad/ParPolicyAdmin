using BusinessLogic.Data;
using BusinessLogic.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Md = BusinessLogic.Models;

namespace ParPolicyAdmin.Forms
{
    public partial class frmAnnualMailing : Form
    {

        private SourceRepo sourceRepo;

        private List<string> sources;

        private int MailingId;

        public bool IsSaved;

        public frmAnnualMailing()
        {
            IsSaved = false;
            InitializeComponent();
            MailingId = 0;
        }

        /* For Edit form */
        public frmAnnualMailing(int mailingId)
        {
            InitializeComponent();
            MailingId = mailingId;
        }

        private void frmAnnualMailing_Load(object sender, EventArgs e)
        {
            sourceRepo = new SourceRepo();
            sources = sourceRepo.GetAllSourceCodes().Where(s => !s.Equals("Undefined")).ToList();

            BindingSource bs = new BindingSource();
            bs.DataSource = sources;
            cbSystemCode.DataSource = bs;
           
            /* If MailingId is zero then ADD */
            if (MailingId == 0)
            {
                lblMailingHeader.Text = "Add Records";
                cbSystemCode.SelectedIndex = 0;
            }
            /* If MailingId is non-zero then EDIT */
            else 
            {
                lblMailingHeader.Text = "Update Records";

                AnnualMailingListRepo aml_repo = new AnnualMailingListRepo();
                Md.AnnualMailingList aml = aml_repo.GetAnnualMailings_ById(MailingId);

                int index = cbSystemCode.Items.IndexOf(aml.SystemCode);

                cbSystemCode.SelectedIndex = index;
                tbHolderName.Text = aml.HolderName;
                tbPolicyNumber.Text = aml.PolicyNumber;

                tbLanguageCode.Text = aml.LanguageCode;
                tbCountryCode.Text = aml.CountryCode;
                tbPostalCode.Text = aml.PostalCode;
                tbKeyName.Text = aml.KeyName;

                tbAddress1.Text = aml.Address1;
                tbAddress2.Text = aml.Address2;
                tbAddress3.Text = aml.Address3;
                tbAddress4.Text = aml.Address4;
                tbAddress5.Text = aml.Address5;
                tbAddress6.Text = aml.Address6;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* Nullity check - Mandatory fields */
            string code = cbSystemCode.Text;
            string holderName = tbHolderName.Text;
            string policyNumber = tbPolicyNumber.Text; 
            string address1 = tbAddress1.Text;

            if (String.IsNullOrEmpty(code) ||
                String.IsNullOrEmpty(holderName) ||
                String.IsNullOrEmpty(policyNumber) ||
                String.IsNullOrEmpty(address1))
            {
                MessageBox.Show("Please fill all mandatory (*) fields.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            /* If All mandatory fields are filled up */
            string address2 = tbAddress2.Text;
            string address3 = tbAddress3.Text;
            string address4 = tbAddress4.Text;
            string address5 = tbAddress5.Text;
            string address6 = tbAddress6.Text;
            string languageCode = tbLanguageCode.Text;
            string countryCode = tbCountryCode.Text;
            string postalCode = tbPostalCode.Text;
            string keyName = tbKeyName.Text;

            try
            {
                Md.AnnualMailingList aml = new Md.AnnualMailingList();
                aml.SystemCode = code;
                aml.HolderName = holderName.ToUpper();
                aml.PolicyNumber = policyNumber.PadLeft(10, '0'); ;
                aml.Address1 = address1.ToUpper();
                aml.Address2 = address2.ToUpper();
                aml.Address3 = address3.ToUpper();
                aml.Address4 = address4.ToUpper();
                aml.Address5 = address5.ToUpper();
                aml.Address6 = address6.ToUpper();
                aml.LanguageCode = languageCode.ToUpper();
                aml.CountryCode = countryCode.ToUpper();
                aml.PostalCode = postalCode.ToUpper();
                aml.KeyName = keyName.ToUpper();

                aml.LineNumber = -1;
                aml.UserFlaggedDuplicate = false;
                aml.UserFlaggedDeficient = false;
                aml.UserFlaggedExclusion = false;
                aml.UserManualAdd = true;

                AnnualMailingListRepo aml_repo = new AnnualMailingListRepo();

                if (MailingId == 0)
                {
                    bool ret = aml_repo.Insert_AnnualMailings(aml);

                    if (ret)
                    {
                        MessageBox.Show(String.Format("Mailing for {0} successfully added.", holderName),
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Error : Policy number [{0}] already exist.", aml.PolicyNumber),
                        "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    aml_repo.UpdateMailing_ById(MailingId, aml);

                    MessageBox.Show(String.Format("Mailing for {0} successfully updated.", holderName),
                    "Success!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

                IsSaved = true;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}
