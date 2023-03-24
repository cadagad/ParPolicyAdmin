
namespace ParPolicyAdmin.UserControls
{
    partial class ucReviewData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReviewData));
            this.dgvSources = new System.Windows.Forms.DataGridView();
            this.btnReviewDuplicates = new System.Windows.Forms.Button();
            this.btnReviewDeficient = new System.Windows.Forms.Button();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLabel2 = new System.Windows.Forms.TextBox();
            this.tbLabel1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).BeginInit();
            this.pnlDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSources
            // 
            this.dgvSources.AllowUserToAddRows = false;
            this.dgvSources.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSources.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSources.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSources.Location = new System.Drawing.Point(15, 12);
            this.dgvSources.MultiSelect = false;
            this.dgvSources.Name = "dgvSources";
            this.dgvSources.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSources.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSources.RowHeadersVisible = false;
            this.dgvSources.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSources.Size = new System.Drawing.Size(282, 371);
            this.dgvSources.TabIndex = 5;
            // 
            // btnReviewDuplicates
            // 
            this.btnReviewDuplicates.BackColor = System.Drawing.SystemColors.Control;
            this.btnReviewDuplicates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviewDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewDuplicates.Location = new System.Drawing.Point(15, 389);
            this.btnReviewDuplicates.Name = "btnReviewDuplicates";
            this.btnReviewDuplicates.Size = new System.Drawing.Size(135, 30);
            this.btnReviewDuplicates.TabIndex = 7;
            this.btnReviewDuplicates.Text = "Review Duplicates";
            this.btnReviewDuplicates.UseVisualStyleBackColor = false;
            this.btnReviewDuplicates.Click += new System.EventHandler(this.btnReviewDuplicates_Click);
            // 
            // btnReviewDeficient
            // 
            this.btnReviewDeficient.BackColor = System.Drawing.SystemColors.Control;
            this.btnReviewDeficient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviewDeficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewDeficient.Location = new System.Drawing.Point(162, 389);
            this.btnReviewDeficient.Name = "btnReviewDeficient";
            this.btnReviewDeficient.Size = new System.Drawing.Size(135, 30);
            this.btnReviewDeficient.TabIndex = 8;
            this.btnReviewDeficient.Text = "Review Deficient";
            this.btnReviewDeficient.UseVisualStyleBackColor = false;
            this.btnReviewDeficient.Click += new System.EventHandler(this.btnReviewDeficient_Click);
            // 
            // pnlDescription
            // 
            this.pnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDescription.Controls.Add(this.textBox3);
            this.pnlDescription.Controls.Add(this.textBox2);
            this.pnlDescription.Controls.Add(this.label3);
            this.pnlDescription.Controls.Add(this.textBox1);
            this.pnlDescription.Controls.Add(this.label2);
            this.pnlDescription.Controls.Add(this.label1);
            this.pnlDescription.Controls.Add(this.tbLabel2);
            this.pnlDescription.Controls.Add(this.tbLabel1);
            this.pnlDescription.Location = new System.Drawing.Point(303, 12);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(369, 406);
            this.pnlDescription.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(6, 288);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(358, 71);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 220);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 43);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Review Deficient:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(19, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(345, 81);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Review Duplicates:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Sources:";
            // 
            // tbLabel2
            // 
            this.tbLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel2.Enabled = false;
            this.tbLabel2.Location = new System.Drawing.Point(6, 100);
            this.tbLabel2.Multiline = true;
            this.tbLabel2.Name = "tbLabel2";
            this.tbLabel2.Size = new System.Drawing.Size(358, 31);
            this.tbLabel2.TabIndex = 6;
            this.tbLabel2.Text = "After loading data, the system has identified any records that appear to be dupli" +
    "cates.  Duplicates are identified by:\r\n";
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
            this.tbLabel1.Size = new System.Drawing.Size(358, 41);
            this.tbLabel1.TabIndex = 4;
            this.tbLabel1.Text = "Select one or more sources to submit to CSTC  (hold down the CTRL key to select m" +
    "ultiple sources).   Alternatively, you can click on “Select All” to submit all r" +
    "ecords to CSTC";
            // 
            // ucReviewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.btnReviewDeficient);
            this.Controls.Add(this.btnReviewDuplicates);
            this.Controls.Add(this.dgvSources);
            this.Name = "ucReviewData";
            this.Size = new System.Drawing.Size(700, 475);
            this.Load += new System.EventHandler(this.ucReviewData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).EndInit();
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSources;
        private System.Windows.Forms.Button btnReviewDuplicates;
        private System.Windows.Forms.Button btnReviewDeficient;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLabel2;
        private System.Windows.Forms.TextBox tbLabel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}
