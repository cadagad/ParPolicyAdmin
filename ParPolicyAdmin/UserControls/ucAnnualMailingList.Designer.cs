namespace ParPolicyAdmin.UserControls
{
    partial class ucAnnualMailingList
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
            this.dgvAnnualMailingList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDropoffPath = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cbSystemCode = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnReviewDeficient = new System.Windows.Forms.Button();
            this.btnReviewDuplicates = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnualMailingList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnnualMailingList
            // 
            this.dgvAnnualMailingList.AllowUserToAddRows = false;
            this.dgvAnnualMailingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnnualMailingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnnualMailingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAnnualMailingList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnnualMailingList.Location = new System.Drawing.Point(3, 59);
            this.dgvAnnualMailingList.Name = "dgvAnnualMailingList";
            this.dgvAnnualMailingList.RowHeadersWidth = 20;
            this.dgvAnnualMailingList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAnnualMailingList.RowTemplate.Height = 30;
            this.dgvAnnualMailingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnnualMailingList.Size = new System.Drawing.Size(894, 377);
            this.dgvAnnualMailingList.TabIndex = 11;
            this.dgvAnnualMailingList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnnualMailingList_CellContentDoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(3, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "To upload Annual Mailing List : Copy ANNUAL.TXT file on the folder below and clic" +
    "k \'Upload\'";
            // 
            // lblDropoffPath
            // 
            this.lblDropoffPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDropoffPath.AutoSize = true;
            this.lblDropoffPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropoffPath.ForeColor = System.Drawing.Color.Green;
            this.lblDropoffPath.Location = new System.Drawing.Point(3, 452);
            this.lblDropoffPath.Name = "lblDropoffPath";
            this.lblDropoffPath.Size = new System.Drawing.Size(75, 13);
            this.lblDropoffPath.TabIndex = 16;
            this.lblDropoffPath.Text = "<Placeholder>";
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(807, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(90, 30);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cbSystemCode
            // 
            this.cbSystemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSystemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSystemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSystemCode.FormattingEnabled = true;
            this.cbSystemCode.Location = new System.Drawing.Point(106, 30);
            this.cbSystemCode.Name = "cbSystemCode";
            this.cbSystemCode.Size = new System.Drawing.Size(65, 23);
            this.cbSystemCode.TabIndex = 18;
            this.cbSystemCode.SelectedIndexChanged += new System.EventHandler(this.cbSystemCode_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(106, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(150, 21);
            this.tbSearch.TabIndex = 19;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Code :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Policy / Holder :";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(177, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Green;
            this.lblRecordCount.Location = new System.Drawing.Point(737, 40);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(160, 13);
            this.lblRecordCount.TabIndex = 23;
            this.lblRecordCount.Text = "Record(s) : ";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReviewDeficient
            // 
            this.btnReviewDeficient.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReviewDeficient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviewDeficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewDeficient.Location = new System.Drawing.Point(363, 31);
            this.btnReviewDeficient.Name = "btnReviewDeficient";
            this.btnReviewDeficient.Size = new System.Drawing.Size(135, 23);
            this.btnReviewDeficient.TabIndex = 25;
            this.btnReviewDeficient.Text = "Review Deficient";
            this.btnReviewDeficient.UseVisualStyleBackColor = false;
            // 
            // btnReviewDuplicates
            // 
            this.btnReviewDuplicates.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReviewDuplicates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviewDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewDuplicates.Location = new System.Drawing.Point(363, 4);
            this.btnReviewDuplicates.Name = "btnReviewDuplicates";
            this.btnReviewDuplicates.Size = new System.Drawing.Size(135, 23);
            this.btnReviewDuplicates.TabIndex = 24;
            this.btnReviewDuplicates.Text = "Review Duplicates";
            this.btnReviewDuplicates.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(807, 439);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.Info;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(528, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(135, 23);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "Export (Outbound)";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.SystemColors.Info;
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCsv.Location = new System.Drawing.Point(528, 31);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(135, 23);
            this.btnExportCsv.TabIndex = 28;
            this.btnExportCsv.Text = "Export (Csv)";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            // 
            // ucAnnualMailingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReviewDeficient);
            this.Controls.Add(this.btnReviewDuplicates);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.cbSystemCode);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDropoffPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAnnualMailingList);
            this.Name = "ucAnnualMailingList";
            this.Size = new System.Drawing.Size(900, 475);
            this.Load += new System.EventHandler(this.ucAnnualMailingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnualMailingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnnualMailingList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDropoffPath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ComboBox cbSystemCode;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnReviewDeficient;
        private System.Windows.Forms.Button btnReviewDuplicates;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportCsv;
    }
}
