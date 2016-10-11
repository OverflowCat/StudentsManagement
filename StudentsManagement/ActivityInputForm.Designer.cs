namespace StudentsManagement
{
    partial class ActivityInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityInputForm));
            this.label1 = new System.Windows.Forms.Label();
            this.activityInputTextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.activityNameTextBox2 = new System.Windows.Forms.TextBox();
            this.activityYearComboBox1 = new System.Windows.Forms.ComboBox();
            this.activitySessionComboBox2 = new System.Windows.Forms.ComboBox();
            this.activityDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.activityValuesTextBox3 = new System.Windows.Forms.TextBox();
            this.activityAddButton2 = new System.Windows.Forms.Button();
            this.activityCancelButton2 = new System.Windows.Forms.Button();
            this.activityOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.activityPsTextBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.eComboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件导入";
            // 
            // activityInputTextBox1
            // 
            this.activityInputTextBox1.Location = new System.Drawing.Point(71, 32);
            this.activityInputTextBox1.Name = "activityInputTextBox1";
            this.activityInputTextBox1.Size = new System.Drawing.Size(200, 21);
            this.activityInputTextBox1.TabIndex = 1;
            this.activityInputTextBox1.TextChanged += new System.EventHandler(this.activityInputTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "活动名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32090, 32148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "学年";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "学期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "活动日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "活动加分";
            // 
            // activityNameTextBox2
            // 
            this.activityNameTextBox2.Location = new System.Drawing.Point(152, 70);
            this.activityNameTextBox2.Name = "activityNameTextBox2";
            this.activityNameTextBox2.Size = new System.Drawing.Size(121, 21);
            this.activityNameTextBox2.TabIndex = 9;
            this.activityNameTextBox2.TextChanged += new System.EventHandler(this.activityNameTextBox2_TextChanged);
            // 
            // activityYearComboBox1
            // 
            this.activityYearComboBox1.FormattingEnabled = true;
            this.activityYearComboBox1.Items.AddRange(new object[] {
            "2013-2014",
            "2014-2015",
            "2015-2016",
            "2016-2017",
            "2017-2018",
            "2018-2019",
            "2019-2020",
            "2020-2021",
            "2021-2022",
            "2022-2023",
            "2023-2024",
            "2024-2025",
            "2025-2026"});
            this.activityYearComboBox1.Location = new System.Drawing.Point(152, 102);
            this.activityYearComboBox1.Name = "activityYearComboBox1";
            this.activityYearComboBox1.Size = new System.Drawing.Size(121, 20);
            this.activityYearComboBox1.TabIndex = 10;
            this.activityYearComboBox1.SelectedIndexChanged += new System.EventHandler(this.activityYearComboBox1_SelectedIndexChanged);
            // 
            // activitySessionComboBox2
            // 
            this.activitySessionComboBox2.FormattingEnabled = true;
            this.activitySessionComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.activitySessionComboBox2.Location = new System.Drawing.Point(152, 133);
            this.activitySessionComboBox2.Name = "activitySessionComboBox2";
            this.activitySessionComboBox2.Size = new System.Drawing.Size(121, 20);
            this.activitySessionComboBox2.TabIndex = 11;
            this.activitySessionComboBox2.SelectedIndexChanged += new System.EventHandler(this.activitySessionComboBox2_SelectedIndexChanged);
            // 
            // activityDateTimePicker1
            // 
            this.activityDateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.activityDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.activityDateTimePicker1.Location = new System.Drawing.Point(152, 164);
            this.activityDateTimePicker1.Name = "activityDateTimePicker1";
            this.activityDateTimePicker1.Size = new System.Drawing.Size(155, 21);
            this.activityDateTimePicker1.TabIndex = 12;
            this.activityDateTimePicker1.ValueChanged += new System.EventHandler(this.activityDateTimePicker1_ValueChanged);
            // 
            // activityValuesTextBox3
            // 
            this.activityValuesTextBox3.Location = new System.Drawing.Point(152, 227);
            this.activityValuesTextBox3.Name = "activityValuesTextBox3";
            this.activityValuesTextBox3.Size = new System.Drawing.Size(100, 21);
            this.activityValuesTextBox3.TabIndex = 13;
            this.activityValuesTextBox3.TextChanged += new System.EventHandler(this.activityValuesTextBox3_TextChanged);
            // 
            // activityAddButton2
            // 
            this.activityAddButton2.Location = new System.Drawing.Point(71, 336);
            this.activityAddButton2.Name = "activityAddButton2";
            this.activityAddButton2.Size = new System.Drawing.Size(75, 23);
            this.activityAddButton2.TabIndex = 14;
            this.activityAddButton2.Text = "确认";
            this.activityAddButton2.UseVisualStyleBackColor = true;
            this.activityAddButton2.Click += new System.EventHandler(this.activityAddButton2_Click);
            // 
            // activityCancelButton2
            // 
            this.activityCancelButton2.Location = new System.Drawing.Point(194, 336);
            this.activityCancelButton2.Name = "activityCancelButton2";
            this.activityCancelButton2.Size = new System.Drawing.Size(75, 23);
            this.activityCancelButton2.TabIndex = 15;
            this.activityCancelButton2.Text = "取消";
            this.activityCancelButton2.UseVisualStyleBackColor = true;
            this.activityCancelButton2.Click += new System.EventHandler(this.activityCancelButton2_Click);
            // 
            // activityOpenFileDialog
            // 
            this.activityOpenFileDialog.FileName = "openFileDialog1";
            this.activityOpenFileDialog.Filter = "excel2007|*.xlsx|excel97-2003|*.xls";
            this.activityOpenFileDialog.RestoreDirectory = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // activityPsTextBox1
            // 
            this.activityPsTextBox1.Location = new System.Drawing.Point(148, 271);
            this.activityPsTextBox1.Multiline = true;
            this.activityPsTextBox1.Name = "activityPsTextBox1";
            this.activityPsTextBox1.Size = new System.Drawing.Size(155, 59);
            this.activityPsTextBox1.TabIndex = 17;
            this.activityPsTextBox1.TextChanged += new System.EventHandler(this.activityPsTextBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "评测项目";
            // 
            // eComboBox1
            // 
            this.eComboBox1.FormattingEnabled = true;
            this.eComboBox1.Items.AddRange(new object[] {
            "德育测评",
            "能力测评",
            "个性发展测评"});
            this.eComboBox1.Location = new System.Drawing.Point(152, 196);
            this.eComboBox1.Name = "eComboBox1";
            this.eComboBox1.Size = new System.Drawing.Size(121, 20);
            this.eComboBox1.TabIndex = 19;
            this.eComboBox1.SelectedIndexChanged += new System.EventHandler(this.eComboBox1_SelectedIndexChanged);
            // 
            // ActivityInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 371);
            this.Controls.Add(this.eComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.activityPsTextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.activityCancelButton2);
            this.Controls.Add(this.activityAddButton2);
            this.Controls.Add(this.activityValuesTextBox3);
            this.Controls.Add(this.activityDateTimePicker1);
            this.Controls.Add(this.activitySessionComboBox2);
            this.Controls.Add(this.activityYearComboBox1);
            this.Controls.Add(this.activityNameTextBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.activityInputTextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ActivityInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "活动添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox activityInputTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox activityNameTextBox2;
        private System.Windows.Forms.ComboBox activityYearComboBox1;
        private System.Windows.Forms.ComboBox activitySessionComboBox2;
        private System.Windows.Forms.DateTimePicker activityDateTimePicker1;
        private System.Windows.Forms.TextBox activityValuesTextBox3;
        private System.Windows.Forms.Button activityAddButton2;
        private System.Windows.Forms.Button activityCancelButton2;
        private System.Windows.Forms.OpenFileDialog activityOpenFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox activityPsTextBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox eComboBox1;
    }
}