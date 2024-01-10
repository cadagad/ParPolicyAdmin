using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucAnnualMailingList : UserControl
    {
        private string Dropoff = String.Empty;
        private string Staging = String.Empty;
        private string Archive = String.Empty;
        private string FeedName = String.Empty;

        private string TriggerPath = String.Empty;
        private string TriggerFile = String.Empty;

        public ucAnnualMailingList()
        {
            InitializeComponent();
        }

        private void ucAnnualMailingList_Load(object sender, EventArgs e)
        {
            Dropoff = ConfigurationManager.AppSettings["AnnualMailingFeed_Dropoff"];
            Staging = ConfigurationManager.AppSettings["AnnualMailingFeed_Staging"];
            Archive = ConfigurationManager.AppSettings["AnnualMailingFeed_Archive"];
            FeedName = ConfigurationManager.AppSettings["AnnualMailingFeed_Name"];

            TriggerPath = ConfigurationManager.AppSettings["TriggerPath"];
            TriggerFile = ConfigurationManager.AppSettings["TriggerFile_AnnualMailingList"];

            lblDropoffPath.Text = Dropoff;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string feed = Path.Combine(Dropoff, FeedName);

            /* Check if input feed exists */
            if (!File.Exists(feed))
            {
                MessageBox.Show(
                    String.Format("Annual.txt file not found on {0}.", Dropoff),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Uploading Annual.txt will overwrite the records. Continue?", 
                "Confirm", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel)
                return;


            /* Normal process - File exist and confirmation is provided */
            string trigger = Path.Combine(TriggerPath, TriggerFile);

            /* Create directory structure if not exist */
            if (!Directory.Exists(TriggerPath))
                Directory.CreateDirectory(Path.GetDirectoryName(trigger));

            /* Delete trigger file if exist */
            if (File.Exists(trigger))
                File.Delete(trigger);

            /* Create trigger file */
            File.Create(trigger).Dispose();
        }
    }
}
