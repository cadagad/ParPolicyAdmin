
namespace ParPolicyAdmin.UserControls
{
    partial class ucProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjects));
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLabel4 = new System.Windows.Forms.TextBox();
            this.tbLabel2 = new System.Windows.Forms.TextBox();
            this.tbLabel1 = new System.Windows.Forms.TextBox();
            this.tbLabel3 = new System.Windows.Forms.TextBox();
            this.pnlNewProject = new System.Windows.Forms.Panel();
            this.lblSubmitMsg = new System.Windows.Forms.Label();
            this.lblDueDateMsg = new System.Windows.Forms.Label();
            this.lblYearMsg = new System.Windows.Forms.Label();
            this.lblNameMsg = new System.Windows.Forms.Label();
            this.lblTypeMsg = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblNewProject = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbShowArchived = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.pnlDescription.SuspendLayout();
            this.pnlNewProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjects
            // 
            this.dgvProjects.AllowUserToAddRows = false;
            this.dgvProjects.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProjects.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProjects.Location = new System.Drawing.Point(15, 12);
            this.dgvProjects.MultiSelect = false;
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProjects.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProjects.RowHeadersVisible = false;
            this.dgvProjects.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjects.Size = new System.Drawing.Size(282, 371);
            this.dgvProjects.TabIndex = 3;
            this.dgvProjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjects_CellClick);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(15, 412);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 30);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(111, 412);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 30);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.SystemColors.Control;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Location = new System.Drawing.Point(207, 412);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(90, 30);
            this.btnArchive.TabIndex = 6;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.label4);
            this.pnlDescription.Controls.Add(this.label3);
            this.pnlDescription.Controls.Add(this.label2);
            this.pnlDescription.Controls.Add(this.label1);
            this.pnlDescription.Controls.Add(this.tbLabel4);
            this.pnlDescription.Controls.Add(this.tbLabel2);
            this.pnlDescription.Controls.Add(this.tbLabel1);
            this.pnlDescription.Controls.Add(this.tbLabel3);
            this.pnlDescription.Location = new System.Drawing.Point(315, 12);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(369, 406);
            this.pnlDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(3, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Archive:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Create:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Open:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Existing Projects:";
            // 
            // tbLabel4
            // 
            this.tbLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel4.Enabled = false;
            this.tbLabel4.Location = new System.Drawing.Point(6, 276);
            this.tbLabel4.Multiline = true;
            this.tbLabel4.Name = "tbLabel4";
            this.tbLabel4.Size = new System.Drawing.Size(360, 46);
            this.tbLabel4.TabIndex = 10;
            this.tbLabel4.Text = "Closes (Archives) the currently active project.  Once archived, the project is in" +
    "active and no new data can be added to it.  Reports and other data can be review" +
    "ed.";
            // 
            // tbLabel2
            // 
            this.tbLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel2.Enabled = false;
            this.tbLabel2.Location = new System.Drawing.Point(6, 107);
            this.tbLabel2.Multiline = true;
            this.tbLabel2.Name = "tbLabel2";
            this.tbLabel2.Size = new System.Drawing.Size(360, 42);
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
            this.tbLabel1.Size = new System.Drawing.Size(360, 53);
            this.tbLabel1.TabIndex = 4;
            this.tbLabel1.Text = resources.GetString("tbLabel1.Text");
            // 
            // tbLabel3
            // 
            this.tbLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.tbLabel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLabel3.Enabled = false;
            this.tbLabel3.Location = new System.Drawing.Point(6, 180);
            this.tbLabel3.Multiline = true;
            this.tbLabel3.Name = "tbLabel3";
            this.tbLabel3.Size = new System.Drawing.Size(360, 65);
            this.tbLabel3.TabIndex = 8;
            this.tbLabel3.Text = resources.GetString("tbLabel3.Text");
            // 
            // pnlNewProject
            // 
            this.pnlNewProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewProject.Controls.Add(this.lblSubmitMsg);
            this.pnlNewProject.Controls.Add(this.lblDueDateMsg);
            this.pnlNewProject.Controls.Add(this.lblYearMsg);
            this.pnlNewProject.Controls.Add(this.lblNameMsg);
            this.pnlNewProject.Controls.Add(this.lblTypeMsg);
            this.pnlNewProject.Controls.Add(this.tbYear);
            this.pnlNewProject.Controls.Add(this.btnReset);
            this.pnlNewProject.Controls.Add(this.btnAdd);
            this.pnlNewProject.Controls.Add(this.lblNewProject);
            this.pnlNewProject.Controls.Add(this.dtpDueDate);
            this.pnlNewProject.Controls.Add(this.lblDueDate);
            this.pnlNewProject.Controls.Add(this.lblYear);
            this.pnlNewProject.Controls.Add(this.lblName);
            this.pnlNewProject.Controls.Add(this.cbType);
            this.pnlNewProject.Controls.Add(this.lblType);
            this.pnlNewProject.Controls.Add(this.tbName);
            this.pnlNewProject.Location = new System.Drawing.Point(312, 12);
            this.pnlNewProject.Name = "pnlNewProject";
            this.pnlNewProject.Size = new System.Drawing.Size(269, 371);
            this.pnlNewProject.TabIndex = 11;
            this.pnlNewProject.Visible = false;
            this.pnlNewProject.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNewProject_Paint);
            // 
            // lblSubmitMsg
            // 
            this.lblSubmitMsg.AutoSize = true;
            this.lblSubmitMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmitMsg.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSubmitMsg.Location = new System.Drawing.Point(9, 324);
            this.lblSubmitMsg.Name = "lblSubmitMsg";
            this.lblSubmitMsg.Size = new System.Drawing.Size(45, 13);
            this.lblSubmitMsg.TabIndex = 18;
            this.lblSubmitMsg.Text = "Submit";
            this.lblSubmitMsg.Visible = false;
            // 
            // lblDueDateMsg
            // 
            this.lblDueDateMsg.AutoSize = true;
            this.lblDueDateMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDateMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDueDateMsg.Location = new System.Drawing.Point(9, 254);
            this.lblDueDateMsg.Name = "lblDueDateMsg";
            this.lblDueDateMsg.Size = new System.Drawing.Size(76, 13);
            this.lblDueDateMsg.TabIndex = 17;
            this.lblDueDateMsg.Text = "Due Date Msg";
            this.lblDueDateMsg.Visible = false;
            // 
            // lblYearMsg
            // 
            this.lblYearMsg.AutoSize = true;
            this.lblYearMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblYearMsg.Location = new System.Drawing.Point(9, 194);
            this.lblYearMsg.Name = "lblYearMsg";
            this.lblYearMsg.Size = new System.Drawing.Size(52, 13);
            this.lblYearMsg.TabIndex = 16;
            this.lblYearMsg.Text = "Year Msg";
            this.lblYearMsg.Visible = false;
            // 
            // lblNameMsg
            // 
            this.lblNameMsg.AutoSize = true;
            this.lblNameMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNameMsg.Location = new System.Drawing.Point(9, 134);
            this.lblNameMsg.Name = "lblNameMsg";
            this.lblNameMsg.Size = new System.Drawing.Size(58, 13);
            this.lblNameMsg.TabIndex = 15;
            this.lblNameMsg.Text = "Name Msg";
            this.lblNameMsg.Visible = false;
            // 
            // lblTypeMsg
            // 
            this.lblTypeMsg.AutoSize = true;
            this.lblTypeMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTypeMsg.Location = new System.Drawing.Point(9, 74);
            this.lblTypeMsg.Name = "lblTypeMsg";
            this.lblTypeMsg.Size = new System.Drawing.Size(54, 13);
            this.lblTypeMsg.TabIndex = 14;
            this.lblTypeMsg.Text = "Type Msg";
            this.lblTypeMsg.Visible = false;
            // 
            // tbYear
            // 
            this.tbYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYear.Location = new System.Drawing.Point(4, 170);
            this.tbYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.tbYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(256, 21);
            this.tbYear.TabIndex = 13;
            this.tbYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(135, 291);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 30);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(4, 291);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 30);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblNewProject
            // 
            this.lblNewProject.AutoSize = true;
            this.lblNewProject.BackColor = System.Drawing.SystemColors.Control;
            this.lblNewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewProject.Location = new System.Drawing.Point(7, 8);
            this.lblNewProject.Name = "lblNewProject";
            this.lblNewProject.Size = new System.Drawing.Size(141, 16);
            this.lblNewProject.TabIndex = 1;
            this.lblNewProject.Text = "Create New Project";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "";
            this.dtpDueDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(4, 230);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(256, 21);
            this.dtpDueDate.TabIndex = 7;
            this.dtpDueDate.Value = new System.DateTime(2023, 2, 21, 11, 6, 21, 0);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDueDate.Location = new System.Drawing.Point(9, 214);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(61, 13);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblYear.Location = new System.Drawing.Point(9, 154);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblName.Location = new System.Drawing.Point(9, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(4, 50);
            this.cbType.MaxLength = 20;
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(256, 21);
            this.cbType.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblType.Location = new System.Drawing.Point(9, 34);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(4, 110);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(256, 21);
            this.tbName.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblMessage.Location = new System.Drawing.Point(12, 390);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(45, 13);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Submit";
            this.lblMessage.Visible = false;
            // 
            // cbShowArchived
            // 
            this.cbShowArchived.AutoSize = true;
            this.cbShowArchived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowArchived.Location = new System.Drawing.Point(150, 386);
            this.cbShowArchived.Name = "cbShowArchived";
            this.cbShowArchived.Size = new System.Drawing.Size(147, 17);
            this.cbShowArchived.TabIndex = 20;
            this.cbShowArchived.Text = "Include Archive Projects?";
            this.cbShowArchived.UseVisualStyleBackColor = true;
            this.cbShowArchived.CheckedChanged += new System.EventHandler(this.cbShowArchived_CheckedChanged);
            // 
            // ucProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowArchived);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlNewProject);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.pnlDescription);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucProjects";
            this.Size = new System.Drawing.Size(700, 475);
            this.Load += new System.EventHandler(this.ucProjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.pnlNewProject.ResumeLayout(false);
            this.pnlNewProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.TextBox tbLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLabel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLabel3;
        private System.Windows.Forms.Panel pnlNewProject;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblNewProject;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown tbYear;
        private System.Windows.Forms.Label lblDueDateMsg;
        private System.Windows.Forms.Label lblYearMsg;
        private System.Windows.Forms.Label lblNameMsg;
        private System.Windows.Forms.Label lblTypeMsg;
        private System.Windows.Forms.Label lblSubmitMsg;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox cbShowArchived;
    }
}
