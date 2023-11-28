
namespace ParPolicyAdmin.UserControls
{
    partial class ucLoadFiles
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoadFiles));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLabel4 = new System.Windows.Forms.TextBox();
            this.tbLabel2 = new System.Windows.Forms.TextBox();
            this.tbLabel1 = new System.Windows.Forms.TextBox();
            this.tbLabel3 = new System.Windows.Forms.TextBox();
            this.dgvFeeds = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeds)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.label5);
            this.pnlDescription.Controls.Add(this.textBox1);
            this.pnlDescription.Controls.Add(this.label4);
            this.pnlDescription.Controls.Add(this.label3);
            this.pnlDescription.Controls.Add(this.label2);
            this.pnlDescription.Controls.Add(this.label1);
            this.pnlDescription.Controls.Add(this.tbLabel4);
            this.pnlDescription.Controls.Add(this.tbLabel2);
            this.pnlDescription.Controls.Add(this.tbLabel1);
            this.pnlDescription.Controls.Add(this.tbLabel3);
            this.pnlDescription.Location = new System.Drawing.Point(515, 12);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(369, 406);
            this.pnlDescription.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(3, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Progress Bars:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 289);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 31);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "The progress bar displays the overall progress of the entire operation.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(3, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Activities:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cancel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refresh";
            // 
            // tbLabel4
            // 
            this.tbLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel4.Enabled = false;
            this.tbLabel4.Location = new System.Drawing.Point(6, 234);
            this.tbLabel4.Multiline = true;
            this.tbLabel4.Name = "tbLabel4";
            this.tbLabel4.Size = new System.Drawing.Size(360, 31);
            this.tbLabel4.TabIndex = 10;
            this.tbLabel4.Text = "A log of the processes is displayed here.  The information can be copied by right" +
    " clicking on the box and selecting copy.";
            // 
            // tbLabel2
            // 
            this.tbLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel2.Enabled = false;
            this.tbLabel2.Location = new System.Drawing.Point(6, 82);
            this.tbLabel2.Multiline = true;
            this.tbLabel2.Name = "tbLabel2";
            this.tbLabel2.Size = new System.Drawing.Size(360, 54);
            this.tbLabel2.TabIndex = 6;
            this.tbLabel2.Text = resources.GetString("tbLabel2.Text");
            // 
            // tbLabel1
            // 
            this.tbLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel1.Enabled = false;
            this.tbLabel1.Location = new System.Drawing.Point(6, 27);
            this.tbLabel1.Multiline = true;
            this.tbLabel1.Name = "tbLabel1";
            this.tbLabel1.Size = new System.Drawing.Size(360, 29);
            this.tbLabel1.TabIndex = 4;
            this.tbLabel1.Text = "The Refresh button repopulates the window above to display any newly arrived Sour" +
    "ce files to be processed.";
            // 
            // tbLabel3
            // 
            this.tbLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel3.Enabled = false;
            this.tbLabel3.Location = new System.Drawing.Point(6, 164);
            this.tbLabel3.Multiline = true;
            this.tbLabel3.Name = "tbLabel3";
            this.tbLabel3.Size = new System.Drawing.Size(360, 42);
            this.tbLabel3.TabIndex = 8;
            this.tbLabel3.Text = "Cancelling the load will not only stop the processes from proceeding, it will als" +
    "o roll back any information that was already loaded to the database.  Cancelled " +
    "loads can be rerun at a later time.";
            // 
            // dgvFeeds
            // 
            this.dgvFeeds.AllowUserToAddRows = false;
            this.dgvFeeds.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeeds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeeds.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFeeds.Location = new System.Drawing.Point(15, 12);
            this.dgvFeeds.Name = "dgvFeeds";
            this.dgvFeeds.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeeds.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFeeds.RowHeadersVisible = false;
            this.dgvFeeds.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeeds.Size = new System.Drawing.Size(482, 371);
            this.dgvFeeds.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(111, 389);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 30);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(15, 389);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblMessage.Location = new System.Drawing.Point(18, 427);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(43, 13);
            this.lblMessage.TabIndex = 20;
            this.lblMessage.Text = "Status";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(207, 389);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 30);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 30000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // ucLoadFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvFeeds);
            this.Controls.Add(this.pnlDescription);
            this.Name = "ucLoadFiles";
            this.Size = new System.Drawing.Size(900, 475);
            this.Load += new System.EventHandler(this.ucLoadFiles_Load);
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLabel4;
        private System.Windows.Forms.TextBox tbLabel2;
        private System.Windows.Forms.TextBox tbLabel1;
        private System.Windows.Forms.TextBox tbLabel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvFeeds;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
