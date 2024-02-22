
namespace ParPolicyAdmin.Forms
{
    partial class frmReviewDeficient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAddr1 = new System.Windows.Forms.NumericUpDown();
            this.tbAddr2 = new System.Windows.Forms.NumericUpDown();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPolicyList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAddr4 = new System.Windows.Forms.NumericUpDown();
            this.tbAddr3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAddr5 = new System.Windows.Forms.NumericUpDown();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolicyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr5)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(404, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Show all addresses with length having equal to OR less than <value>:";
            // 
            // tbAddr1
            // 
            this.tbAddr1.Location = new System.Drawing.Point(62, 30);
            this.tbAddr1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tbAddr1.Name = "tbAddr1";
            this.tbAddr1.Size = new System.Drawing.Size(35, 20);
            this.tbAddr1.TabIndex = 1;
            this.tbAddr1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbAddr1.ValueChanged += new System.EventHandler(this.tbAddr1_ValueChanged);
            // 
            // tbAddr2
            // 
            this.tbAddr2.Location = new System.Drawing.Point(158, 30);
            this.tbAddr2.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tbAddr2.Name = "tbAddr2";
            this.tbAddr2.Size = new System.Drawing.Size(35, 20);
            this.tbAddr2.TabIndex = 2;
            this.tbAddr2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbAddr2.ValueChanged += new System.EventHandler(this.tbAddr2_ValueChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(307, 56);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(174, 20);
            this.tbSearch.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Or with the following text embedded with address:";
            // 
            // dgvPolicyList
            // 
            this.dgvPolicyList.AllowUserToAddRows = false;
            this.dgvPolicyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPolicyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPolicyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPolicyList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPolicyList.Location = new System.Drawing.Point(12, 82);
            this.dgvPolicyList.Name = "dgvPolicyList";
            this.dgvPolicyList.RowHeadersWidth = 20;
            this.dgvPolicyList.RowTemplate.Height = 30;
            this.dgvPolicyList.Size = new System.Drawing.Size(1360, 531);
            this.dgvPolicyList.TabIndex = 100;
            this.dgvPolicyList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPolicyList_CellValueChanged);
            this.dgvPolicyList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPolicyList_ColumnHeaderMouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1247, 619);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 30);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Addr1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(108, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Addr2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(300, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Addr4:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(204, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Addr3:";
            // 
            // tbAddr4
            // 
            this.tbAddr4.Location = new System.Drawing.Point(350, 30);
            this.tbAddr4.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tbAddr4.Name = "tbAddr4";
            this.tbAddr4.Size = new System.Drawing.Size(35, 20);
            this.tbAddr4.TabIndex = 4;
            this.tbAddr4.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbAddr4.ValueChanged += new System.EventHandler(this.tbAddr4_ValueChanged);
            // 
            // tbAddr3
            // 
            this.tbAddr3.Location = new System.Drawing.Point(254, 30);
            this.tbAddr3.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tbAddr3.Name = "tbAddr3";
            this.tbAddr3.Size = new System.Drawing.Size(35, 20);
            this.tbAddr3.TabIndex = 3;
            this.tbAddr3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbAddr3.ValueChanged += new System.EventHandler(this.tbAddr3_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(396, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Addr5:";
            // 
            // tbAddr5
            // 
            this.tbAddr5.Location = new System.Drawing.Point(446, 30);
            this.tbAddr5.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tbAddr5.Name = "tbAddr5";
            this.tbAddr5.Size = new System.Drawing.Size(35, 20);
            this.tbAddr5.TabIndex = 5;
            this.tbAddr5.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbAddr5.ValueChanged += new System.EventHandler(this.tbAddr5_ValueChanged);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Green;
            this.lblRecordCount.Location = new System.Drawing.Point(1044, 63);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(328, 13);
            this.lblRecordCount.TabIndex = 32;
            this.lblRecordCount.Text = "Record(s) : ";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckAll.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.Location = new System.Drawing.Point(12, 619);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(125, 30);
            this.btnCheckAll.TabIndex = 101;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUncheckAll.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheckAll.Location = new System.Drawing.Point(143, 619);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(125, 30);
            this.btnUncheckAll.TabIndex = 102;
            this.btnUncheckAll.Text = "Un-Check All";
            this.btnUncheckAll.UseVisualStyleBackColor = false;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // frmReviewDeficient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.btnUncheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAddr5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAddr4);
            this.Controls.Add(this.tbAddr3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbAddr2);
            this.Controls.Add(this.tbAddr1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPolicyList);
            this.Controls.Add(this.label4);
            this.Name = "frmReviewDeficient";
            this.Text = "Review Deficient";
            this.Load += new System.EventHandler(this.frmReviewDeficient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolicyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddr5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbAddr1;
        private System.Windows.Forms.NumericUpDown tbAddr2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPolicyList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown tbAddr4;
        private System.Windows.Forms.NumericUpDown tbAddr3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tbAddr5;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
    }
}