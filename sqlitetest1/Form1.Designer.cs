namespace sqlitetest1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_addCourse = new System.Windows.Forms.Button();
            this.btn_editCourse = new System.Windows.Forms.Button();
            this.btn_deleteCourse = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cc_teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cc_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cc_ps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_addClassChoice = new System.Windows.Forms.Button();
            this.btn_editClassChoice = new System.Windows.Forms.Button();
            this.btn_deleteClassChoice = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.checkBox_useMinCout = new System.Windows.Forms.CheckBox();
            this.tb_minCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox_useMinCredit = new System.Windows.Forms.CheckBox();
            this.tb_mincredit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.ps,
            this.term,
            this.credit});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(507, 280);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // code
            // 
            this.code.HeaderText = "课程号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 66;
            // 
            // name
            // 
            this.name.HeaderText = "课名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 54;
            // 
            // ps
            // 
            this.ps.HeaderText = "类型";
            this.ps.Name = "ps";
            this.ps.ReadOnly = true;
            this.ps.Width = 54;
            // 
            // term
            // 
            this.term.HeaderText = "学期";
            this.term.Name = "term";
            this.term.ReadOnly = true;
            this.term.Width = 54;
            // 
            // credit
            // 
            this.credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.credit.HeaderText = "学分";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            this.credit.Width = 54;
            // 
            // btn_addCourse
            // 
            this.btn_addCourse.Location = new System.Drawing.Point(444, 298);
            this.btn_addCourse.Name = "btn_addCourse";
            this.btn_addCourse.Size = new System.Drawing.Size(75, 23);
            this.btn_addCourse.TabIndex = 10;
            this.btn_addCourse.Text = "添加课程";
            this.btn_addCourse.UseVisualStyleBackColor = true;
            this.btn_addCourse.Click += new System.EventHandler(this.btn_addCourse_Click);
            // 
            // btn_editCourse
            // 
            this.btn_editCourse.Location = new System.Drawing.Point(363, 298);
            this.btn_editCourse.Name = "btn_editCourse";
            this.btn_editCourse.Size = new System.Drawing.Size(75, 23);
            this.btn_editCourse.TabIndex = 11;
            this.btn_editCourse.Text = "编辑课程";
            this.btn_editCourse.UseVisualStyleBackColor = true;
            this.btn_editCourse.Click += new System.EventHandler(this.btn_editCourse_Click);
            // 
            // btn_deleteCourse
            // 
            this.btn_deleteCourse.Location = new System.Drawing.Point(282, 298);
            this.btn_deleteCourse.Name = "btn_deleteCourse";
            this.btn_deleteCourse.Size = new System.Drawing.Size(75, 23);
            this.btn_deleteCourse.TabIndex = 12;
            this.btn_deleteCourse.Text = "删除课程";
            this.btn_deleteCourse.UseVisualStyleBackColor = true;
            this.btn_deleteCourse.Click += new System.EventHandler(this.btn_deleteCourse_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cc_teacher,
            this.cc_location,
            this.cc_ps});
            this.dataGridView2.Location = new System.Drawing.Point(525, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(326, 280);
            this.dataGridView2.TabIndex = 13;
            // 
            // cc_teacher
            // 
            this.cc_teacher.HeaderText = "教师";
            this.cc_teacher.Name = "cc_teacher";
            this.cc_teacher.ReadOnly = true;
            this.cc_teacher.Width = 54;
            // 
            // cc_location
            // 
            this.cc_location.HeaderText = "地点";
            this.cc_location.Name = "cc_location";
            this.cc_location.ReadOnly = true;
            this.cc_location.Width = 54;
            // 
            // cc_ps
            // 
            this.cc_ps.HeaderText = "时间";
            this.cc_ps.Name = "cc_ps";
            this.cc_ps.ReadOnly = true;
            this.cc_ps.Width = 54;
            // 
            // btn_addClassChoice
            // 
            this.btn_addClassChoice.Location = new System.Drawing.Point(763, 298);
            this.btn_addClassChoice.Name = "btn_addClassChoice";
            this.btn_addClassChoice.Size = new System.Drawing.Size(88, 23);
            this.btn_addClassChoice.TabIndex = 14;
            this.btn_addClassChoice.Text = "添加上课班级";
            this.btn_addClassChoice.UseVisualStyleBackColor = true;
            this.btn_addClassChoice.Click += new System.EventHandler(this.btn_addClassChoice_Click);
            // 
            // btn_editClassChoice
            // 
            this.btn_editClassChoice.Location = new System.Drawing.Point(670, 298);
            this.btn_editClassChoice.Name = "btn_editClassChoice";
            this.btn_editClassChoice.Size = new System.Drawing.Size(87, 23);
            this.btn_editClassChoice.TabIndex = 15;
            this.btn_editClassChoice.Text = "编辑上课班级";
            this.btn_editClassChoice.UseVisualStyleBackColor = true;
            this.btn_editClassChoice.Click += new System.EventHandler(this.btn_editClassChoice_Click);
            // 
            // btn_deleteClassChoice
            // 
            this.btn_deleteClassChoice.Location = new System.Drawing.Point(570, 298);
            this.btn_deleteClassChoice.Name = "btn_deleteClassChoice";
            this.btn_deleteClassChoice.Size = new System.Drawing.Size(94, 23);
            this.btn_deleteClassChoice.TabIndex = 16;
            this.btn_deleteClassChoice.Text = "删除上课班级";
            this.btn_deleteClassChoice.UseVisualStyleBackColor = true;
            this.btn_deleteClassChoice.Click += new System.EventHandler(this.btn_deleteClassChoice_Click);
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(525, 344);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(75, 23);
            this.btn_process.TabIndex = 17;
            this.btn_process.Text = "排课";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // checkBox_useMinCout
            // 
            this.checkBox_useMinCout.AutoSize = true;
            this.checkBox_useMinCout.Location = new System.Drawing.Point(393, 348);
            this.checkBox_useMinCout.Name = "checkBox_useMinCout";
            this.checkBox_useMinCout.Size = new System.Drawing.Size(60, 16);
            this.checkBox_useMinCout.TabIndex = 18;
            this.checkBox_useMinCout.Text = "至少选";
            this.checkBox_useMinCout.UseVisualStyleBackColor = true;
            this.checkBox_useMinCout.CheckedChanged += new System.EventHandler(this.checkBox_useMinCout_CheckedChanged);
            // 
            // tb_minCount
            // 
            this.tb_minCount.Enabled = false;
            this.tb_minCount.Location = new System.Drawing.Point(459, 346);
            this.tb_minCount.Name = "tb_minCount";
            this.tb_minCount.Size = new System.Drawing.Size(25, 21);
            this.tb_minCount.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "门课";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Teal;
            this.linkLabel1.Location = new System.Drawing.Point(762, 349);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 12);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "by Vanish";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox_useMinCredit
            // 
            this.checkBox_useMinCredit.AutoSize = true;
            this.checkBox_useMinCredit.Location = new System.Drawing.Point(216, 348);
            this.checkBox_useMinCredit.Name = "checkBox_useMinCredit";
            this.checkBox_useMinCredit.Size = new System.Drawing.Size(60, 16);
            this.checkBox_useMinCredit.TabIndex = 22;
            this.checkBox_useMinCredit.Text = "至少选";
            this.checkBox_useMinCredit.UseVisualStyleBackColor = true;
            this.checkBox_useMinCredit.CheckedChanged += new System.EventHandler(this.checkBox_useMinCredit_CheckedChanged);
            // 
            // tb_mincredit
            // 
            this.tb_mincredit.Enabled = false;
            this.tb_mincredit.Location = new System.Drawing.Point(282, 346);
            this.tb_mincredit.Name = "tb_mincredit";
            this.tb_mincredit.Size = new System.Drawing.Size(40, 21);
            this.tb_mincredit.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "学分";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_mincredit);
            this.Controls.Add(this.checkBox_useMinCredit);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_minCount);
            this.Controls.Add(this.checkBox_useMinCout);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_deleteClassChoice);
            this.Controls.Add(this.btn_editClassChoice);
            this.Controls.Add(this.btn_addClassChoice);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btn_deleteCourse);
            this.Controls.Add(this.btn_editCourse);
            this.Controls.Add(this.btn_addCourse);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HDU排课助手v1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_addCourse;
        private System.Windows.Forms.Button btn_editCourse;
        private System.Windows.Forms.Button btn_deleteCourse;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_addClassChoice;
        private System.Windows.Forms.Button btn_editClassChoice;
        private System.Windows.Forms.Button btn_deleteClassChoice;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.CheckBox checkBox_useMinCout;
        private System.Windows.Forms.TextBox tb_minCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ps;
        private System.Windows.Forms.DataGridViewTextBoxColumn term;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc_teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc_location;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc_ps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox_useMinCredit;
        private System.Windows.Forms.TextBox tb_mincredit;
        private System.Windows.Forms.Label label2;
    }
}

