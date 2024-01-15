namespace ParPolicyAdmin.Forms
{
    partial class frmAnnualMailing
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
            this.cbSystemCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMailingHeader = new System.Windows.Forms.Label();
            this.tbPolicyNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddress1 = new System.Windows.Forms.TextBox();
            this.tbAddress2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAddress3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAddress6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAddress5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAddress4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbHolderName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPostalCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCountryCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbKeyName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbLanguageCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbSystemCode
            // 
            this.cbSystemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSystemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSystemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSystemCode.FormattingEnabled = true;
            this.cbSystemCode.Location = new System.Drawing.Point(12, 52);
            this.cbSystemCode.MaxLength = 20;
            this.cbSystemCode.Name = "cbSystemCode";
            this.cbSystemCode.Size = new System.Drawing.Size(100, 21);
            this.cbSystemCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "* Code:";
            // 
            // lblMailingHeader
            // 
            this.lblMailingHeader.AutoSize = true;
            this.lblMailingHeader.BackColor = System.Drawing.SystemColors.Control;
            this.lblMailingHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailingHeader.Location = new System.Drawing.Point(9, 9);
            this.lblMailingHeader.Name = "lblMailingHeader";
            this.lblMailingHeader.Size = new System.Drawing.Size(129, 16);
            this.lblMailingHeader.TabIndex = 7;
            this.lblMailingHeader.Text = "Add / Edit Mailing";
            // 
            // tbPolicyNumber
            // 
            this.tbPolicyNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPolicyNumber.Location = new System.Drawing.Point(12, 102);
            this.tbPolicyNumber.MaxLength = 9;
            this.tbPolicyNumber.Name = "tbPolicyNumber";
            this.tbPolicyNumber.Size = new System.Drawing.Size(102, 21);
            this.tbPolicyNumber.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "* Policy # (9):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "* Address-1 (32):";
            // 
            // tbAddress1
            // 
            this.tbAddress1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress1.Location = new System.Drawing.Point(12, 152);
            this.tbAddress1.MaxLength = 32;
            this.tbAddress1.Multiline = true;
            this.tbAddress1.Name = "tbAddress1";
            this.tbAddress1.Size = new System.Drawing.Size(200, 45);
            this.tbAddress1.TabIndex = 6;
            // 
            // tbAddress2
            // 
            this.tbAddress2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress2.Location = new System.Drawing.Point(12, 226);
            this.tbAddress2.MaxLength = 32;
            this.tbAddress2.Multiline = true;
            this.tbAddress2.Name = "tbAddress2";
            this.tbAddress2.Size = new System.Drawing.Size(200, 45);
            this.tbAddress2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(12, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address-2 (32):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Address-3 (32):";
            // 
            // tbAddress3
            // 
            this.tbAddress3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress3.Location = new System.Drawing.Point(12, 300);
            this.tbAddress3.MaxLength = 32;
            this.tbAddress3.Multiline = true;
            this.tbAddress3.Name = "tbAddress3";
            this.tbAddress3.Size = new System.Drawing.Size(200, 45);
            this.tbAddress3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(218, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Address-6 (32):";
            // 
            // tbAddress6
            // 
            this.tbAddress6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress6.Location = new System.Drawing.Point(218, 300);
            this.tbAddress6.MaxLength = 32;
            this.tbAddress6.Multiline = true;
            this.tbAddress6.Name = "tbAddress6";
            this.tbAddress6.Size = new System.Drawing.Size(200, 45);
            this.tbAddress6.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(218, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Address-5 (32):";
            // 
            // tbAddress5
            // 
            this.tbAddress5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress5.Location = new System.Drawing.Point(218, 226);
            this.tbAddress5.MaxLength = 32;
            this.tbAddress5.Multiline = true;
            this.tbAddress5.Name = "tbAddress5";
            this.tbAddress5.Size = new System.Drawing.Size(200, 45);
            this.tbAddress5.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(218, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Address-4 (32):";
            // 
            // tbAddress4
            // 
            this.tbAddress4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress4.Location = new System.Drawing.Point(218, 152);
            this.tbAddress4.MaxLength = 32;
            this.tbAddress4.Multiline = true;
            this.tbAddress4.Name = "tbAddress4";
            this.tbAddress4.Size = new System.Drawing.Size(200, 45);
            this.tbAddress4.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(118, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "* Holder Name (32):";
            // 
            // tbHolderName
            // 
            this.tbHolderName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHolderName.Location = new System.Drawing.Point(118, 102);
            this.tbHolderName.MaxLength = 32;
            this.tbHolderName.Name = "tbHolderName";
            this.tbHolderName.Size = new System.Drawing.Size(206, 21);
            this.tbHolderName.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(115, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Language (1):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(12, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Postal Code (9)";
            // 
            // tbPostalCode
            // 
            this.tbPostalCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPostalCode.Location = new System.Drawing.Point(12, 374);
            this.tbPostalCode.MaxLength = 9;
            this.tbPostalCode.Name = "tbPostalCode";
            this.tbPostalCode.Size = new System.Drawing.Size(202, 21);
            this.tbPostalCode.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(221, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Country Code (1):";
            // 
            // tbCountryCode
            // 
            this.tbCountryCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCountryCode.Location = new System.Drawing.Point(224, 52);
            this.tbCountryCode.MaxLength = 1;
            this.tbCountryCode.Name = "tbCountryCode";
            this.tbCountryCode.Size = new System.Drawing.Size(100, 21);
            this.tbCountryCode.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(221, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Key Name (32)";
            // 
            // tbKeyName
            // 
            this.tbKeyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKeyName.Location = new System.Drawing.Point(219, 374);
            this.tbKeyName.MaxLength = 32;
            this.tbKeyName.Name = "tbKeyName";
            this.tbKeyName.Size = new System.Drawing.Size(199, 21);
            this.tbKeyName.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(10, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbLanguageCode
            // 
            this.tbLanguageCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLanguageCode.Location = new System.Drawing.Point(118, 52);
            this.tbLanguageCode.MaxLength = 1;
            this.tbLanguageCode.Name = "tbLanguageCode";
            this.tbLanguageCode.Size = new System.Drawing.Size(100, 21);
            this.tbLanguageCode.TabIndex = 2;
            // 
            // frmAnnualMailing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(434, 451);
            this.Controls.Add(this.tbLanguageCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbKeyName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbCountryCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbPostalCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbHolderName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAddress6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAddress5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbAddress4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAddress3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbAddress2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAddress1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPolicyNumber);
            this.Controls.Add(this.lblMailingHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSystemCode);
            this.Name = "frmAnnualMailing";
            this.Text = "Annual Mailing";
            this.Load += new System.EventHandler(this.frmAnnualMailing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSystemCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMailingHeader;
        private System.Windows.Forms.TextBox tbPolicyNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddress1;
        private System.Windows.Forms.TextBox tbAddress2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAddress3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAddress6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAddress5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAddress4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbHolderName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbPostalCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCountryCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbKeyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbLanguageCode;
    }
}