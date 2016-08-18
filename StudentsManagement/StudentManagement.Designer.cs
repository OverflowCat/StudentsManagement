namespace StudentsManagement
{
    partial class StudentManagement
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("学生");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("成绩");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("活动");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("综合评定");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.studentPanel = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.okGroupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.okButton1 = new System.Windows.Forms.Button();
            this.StudentListGridView = new System.Windows.Forms.DataGridView();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_political = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_major = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.sstudentIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.majorBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sexBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nationalityText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.politicalStatusText = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.activityPanel = new System.Windows.Forms.Panel();
            this.studentPanel.SuspendLayout();
            this.okGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentListGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 119);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "student";
            treeNode1.Text = "学生";
            treeNode2.Name = "grade";
            treeNode2.Text = "成绩";
            treeNode3.Name = "activity";
            treeNode3.Text = "活动";
            treeNode4.Name = "evaluation";
            treeNode4.Text = "综合评定";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(87, 635);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // studentPanel
            // 
            this.studentPanel.Controls.Add(this.updateButton);
            this.studentPanel.Controls.Add(this.okGroupBox1);
            this.studentPanel.Controls.Add(this.StudentListGridView);
            this.studentPanel.Controls.Add(this.outputButton);
            this.studentPanel.Controls.Add(this.flowLayoutPanel1);
            this.studentPanel.Controls.Add(this.inputButton);
            this.studentPanel.Controls.Add(this.searchButton);
            this.studentPanel.Location = new System.Drawing.Point(108, 119);
            this.studentPanel.Name = "studentPanel";
            this.studentPanel.Size = new System.Drawing.Size(1131, 635);
            this.studentPanel.TabIndex = 18;
            this.studentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(68, 599);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // okGroupBox1
            // 
            this.okGroupBox1.Controls.Add(this.cancelButton1);
            this.okGroupBox1.Controls.Add(this.okButton1);
            this.okGroupBox1.Location = new System.Drawing.Point(41, 586);
            this.okGroupBox1.Name = "okGroupBox1";
            this.okGroupBox1.Size = new System.Drawing.Size(200, 46);
            this.okGroupBox1.TabIndex = 18;
            this.okGroupBox1.TabStop = false;
            this.okGroupBox1.Text = "是否导入";
            this.okGroupBox1.Visible = false;
            // 
            // cancelButton1
            // 
            this.cancelButton1.Location = new System.Drawing.Point(119, 13);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(75, 23);
            this.cancelButton1.TabIndex = 1;
            this.cancelButton1.Text = "取消";
            this.cancelButton1.UseVisualStyleBackColor = true;
            this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
            // 
            // okButton1
            // 
            this.okButton1.Location = new System.Drawing.Point(6, 13);
            this.okButton1.Name = "okButton1";
            this.okButton1.Size = new System.Drawing.Size(75, 23);
            this.okButton1.TabIndex = 0;
            this.okButton1.Text = "确认";
            this.okButton1.UseVisualStyleBackColor = true;
            this.okButton1.Click += new System.EventHandler(this.okButton1_Click);
            // 
            // StudentListGridView
            // 
            this.StudentListGridView.AllowUserToAddRows = false;
            this.StudentListGridView.AllowUserToOrderColumns = true;
            this.StudentListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.student_name,
            this.student_sex,
            this.student_nationality,
            this.student_political,
            this.student_major,
            this.student_class});
            this.StudentListGridView.Location = new System.Drawing.Point(0, 96);
            this.StudentListGridView.Name = "StudentListGridView";
            this.StudentListGridView.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.StudentListGridView.RowTemplate.Height = 23;
            this.StudentListGridView.Size = new System.Drawing.Size(1131, 484);
            this.StudentListGridView.TabIndex = 15;
            this.StudentListGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentListGridView_CellDoubleClick);
            this.StudentListGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.StudentListGridView_CellMouseDown);
            this.StudentListGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.StudentListGridView_CellValidating);
            this.StudentListGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentListGridView_CellValueChanged);
            // 
            // student_id
            // 
            this.student_id.DataPropertyName = "学号";
            this.student_id.HeaderText = "学号";
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            // 
            // student_name
            // 
            this.student_name.DataPropertyName = "姓名";
            this.student_name.HeaderText = "姓名";
            this.student_name.Name = "student_name";
            // 
            // student_sex
            // 
            this.student_sex.DataPropertyName = "性别";
            this.student_sex.HeaderText = "性别";
            this.student_sex.Name = "student_sex";
            // 
            // student_nationality
            // 
            this.student_nationality.DataPropertyName = "民族";
            this.student_nationality.HeaderText = "民族";
            this.student_nationality.Name = "student_nationality";
            // 
            // student_political
            // 
            this.student_political.DataPropertyName = "政治面貌";
            this.student_political.HeaderText = "政治面貌";
            this.student_political.Name = "student_political";
            // 
            // student_major
            // 
            this.student_major.DataPropertyName = "专业";
            this.student_major.HeaderText = "专业名称";
            this.student_major.Name = "student_major";
            // 
            // student_class
            // 
            this.student_class.DataPropertyName = "行政班";
            this.student_class.HeaderText = "行政班";
            this.student_class.Name = "student_class";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click_1);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(944, 599);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(75, 23);
            this.outputButton.TabIndex = 17;
            this.outputButton.Text = "导出";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.sstudentIdText);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.studentNameText);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.majorBox);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.classBox);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.sexBox);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.nationalityText);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.politicalStatusText);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(68, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(761, 75);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "学号";
            // 
            // sstudentIdText
            // 
            this.sstudentIdText.Location = new System.Drawing.Point(38, 3);
            this.sstudentIdText.Name = "sstudentIdText";
            this.sstudentIdText.Size = new System.Drawing.Size(100, 21);
            this.sstudentIdText.TabIndex = 3;
            this.sstudentIdText.TextChanged += new System.EventHandler(this.sstudentIdText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名";
            // 
            // studentNameText
            // 
            this.studentNameText.Location = new System.Drawing.Point(179, 3);
            this.studentNameText.Name = "studentNameText";
            this.studentNameText.Size = new System.Drawing.Size(100, 21);
            this.studentNameText.TabIndex = 6;
            this.studentNameText.TextChanged += new System.EventHandler(this.studentNameText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "专业";
            // 
            // majorBox
            // 
            this.majorBox.FormattingEnabled = true;
            this.majorBox.Items.AddRange(new object[] {
            "信息与计算科学",
            "数学与应用数学",
            "应用物理"});
            this.majorBox.Location = new System.Drawing.Point(320, 3);
            this.majorBox.Name = "majorBox";
            this.majorBox.Size = new System.Drawing.Size(121, 20);
            this.majorBox.TabIndex = 7;
            this.majorBox.SelectedIndexChanged += new System.EventHandler(this.majorBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "班级";
            // 
            // classBox
            // 
            this.classBox.FormattingEnabled = true;
            this.classBox.Location = new System.Drawing.Point(482, 3);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(121, 20);
            this.classBox.TabIndex = 10;
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.classBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(609, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "性别";
            // 
            // sexBox
            // 
            this.sexBox.FormattingEnabled = true;
            this.sexBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.sexBox.Location = new System.Drawing.Point(644, 3);
            this.sexBox.Name = "sexBox";
            this.sexBox.Size = new System.Drawing.Size(100, 20);
            this.sexBox.TabIndex = 12;
            this.sexBox.SelectedIndexChanged += new System.EventHandler(this.sexBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "民族";
            // 
            // nationalityText
            // 
            this.nationalityText.Location = new System.Drawing.Point(38, 30);
            this.nationalityText.Name = "nationalityText";
            this.nationalityText.Size = new System.Drawing.Size(100, 21);
            this.nationalityText.TabIndex = 14;
            this.nationalityText.TextChanged += new System.EventHandler(this.nationalityText_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "政治面貌";
            // 
            // politicalStatusText
            // 
            this.politicalStatusText.Location = new System.Drawing.Point(203, 30);
            this.politicalStatusText.Name = "politicalStatusText";
            this.politicalStatusText.Size = new System.Drawing.Size(76, 21);
            this.politicalStatusText.TabIndex = 16;
            this.politicalStatusText.TextChanged += new System.EventHandler(this.politicalStatusText_TextChanged);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(852, 599);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(75, 23);
            this.inputButton.TabIndex = 16;
            this.inputButton.Text = "导入";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(886, 25);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(124, 42);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // activityPanel
            // 
            this.activityPanel.Location = new System.Drawing.Point(108, 119);
            this.activityPanel.Name = "activityPanel";
            this.activityPanel.Size = new System.Drawing.Size(1131, 635);
            this.activityPanel.TabIndex = 2;
            // 
            // StudentManagement
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 766);
            this.Controls.Add(this.studentPanel);
            this.Controls.Add(this.activityPanel);
            this.Controls.Add(this.treeView1);
            this.KeyPreview = true;
            this.Name = "StudentManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentManagement";
            this.studentPanel.ResumeLayout(false);
            this.okGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentListGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.DataGridView StudentListGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sstudentIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox majorBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sexBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nationalityText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox politicalStatusText;
        private System.Windows.Forms.Panel activityPanel;
        private System.Windows.Forms.Panel studentPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_political;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_major;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_class;
        private System.Windows.Forms.GroupBox okGroupBox1;
        private System.Windows.Forms.Button cancelButton1;
        private System.Windows.Forms.Button okButton1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}

