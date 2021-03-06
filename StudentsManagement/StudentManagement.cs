﻿using ExcelOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsManagement
{
    public partial class StudentManagement : Form
    {
        private string mStudentName;
        private string mStudentId;
        private string mStudentMajor;
        private string mStudentClass;
        private string mStudentSex;
        private string mStudentPoliticalStatus;
        private string mStudentNationality;
        private string mStudentGradeYear;
        private string[] majors = { "信息与计算科学", "数学与应用数学", "应用物理" };
        private string[] mClassNums;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable inputDataTable = new DataTable();
        private ArrayList columnsNames = new ArrayList();
        private ArrayList locations = new ArrayList();
        private string defaultPath = Common.defaultPath;
        private int selectedIndex;
        private int dtTag;
        public StudentManagement()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "学生")
            {
                studentPanel.BringToFront();
                this.AcceptButton = searchButton;
                label17.Text = "学生基础信息管理界面";
            }
            else if (treeView1.SelectedNode.Text == "成绩")
            {
                gradePanel.BringToFront();
                this.AcceptButton = searchButton1;
                label17.Text = "学生成绩信息管理界面";
            }
            else if (treeView1.SelectedNode.Text == "活动")
            {
                activityPanel.BringToFront();
                this.AcceptButton = searchButton2;
                label17.Text = "院系活动信息管理界面";
            }
            else
            {
                evaluationPanel.BringToFront();
                this.AcceptButton = eSearchButton1;
                eUpdateButton.Visible = false;
                label17.Text = "学生综合评测信息管理界面";
            }
        }
        private string getSql(string mStudentId, string mStudentName, string mStudentGradeYear, string mStudentMajor, string mStudentClass, string mStudentSex, string mStudentNationality, string mStudentPoliticalStatus)
        {
            string sql = "";
            if (mStudentId == null || mStudentId == "")
            {
                if (mStudentMajor != null && mStudentMajor != "")
                {
                    if (mStudentClass != null && mStudentClass != "")
                    {
                        sql = "SELECT * FROM Student_List WHERE 姓名 LIKE '%" + mStudentName + "%' AND 专业 = '" + mStudentMajor + "'"
                            + "AND 行政班 = '" + mStudentClass + "' AND 民族 LIKE '%" + mStudentNationality + "%'"
                            + "AND 性别 LIKE '%" + mStudentSex + "%' AND 政治面貌 LIKE '%" + mStudentPoliticalStatus + "%'";
                    }
                    else
                    {
                        sql = "SELECT * FROM Student_List WHERE 姓名 LIKE '%" + mStudentName + "%' AND 专业 = '" + mStudentMajor + "'"
                            + "AND 民族 LIKE '%" + mStudentNationality + "%' AND 当前所在级 LIKE '%" + mStudentGradeYear + "%'"
                            + "AND 性别 LIKE '%" + mStudentSex + "%' AND 政治面貌 LIKE '%" + mStudentPoliticalStatus + "%'";
                    }
                }
                else
                {
                    sql = "SELECT * FROM Student_List WHERE 姓名 LIKE '%" + mStudentName + "%'"
                            + "AND 民族 LIKE '%" + mStudentNationality + "%'"
                            + "AND 性别 LIKE '%" + mStudentSex + "%' "
                            + "AND 政治面貌 LIKE '%" + mStudentPoliticalStatus + "%'"
                            + "AND 当前所在级 LIKE '%" + mStudentGradeYear + "%'";
                }
            }
            else
            {
                sql = "SELECT * FROM Student_List WHERE 学号 LIKE '" + mStudentId + "%'";
            }
            return sql;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string s = mStudentId + mStudentName + mStudentGradeYear + mStudentMajor + mStudentClass + mStudentSex + mStudentNationality + mStudentPoliticalStatus;
            if (s == "")
            {
                MessageBox.Show("请输入搜索条件");
            }
            else
            {
                string sql = getSql(mStudentId, mStudentName,mStudentGradeYear, mStudentMajor, mStudentClass, mStudentSex, mStudentNationality, mStudentPoliticalStatus);
                ds = DbHelperSQLite.Query(sql);
                dt = ds.Tables[0];
                if (columnsNames.Count == 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        columnsNames.Add(dt.Columns[i].ColumnName);
                    }
                }
                StudentListGridView.DataSource = dt;
                outputButton.Enabled = true;
                dtTag = 0;
                StudentListGridView.ReadOnly = false;
            }
        }

        private void sstudentIdText_TextChanged(object sender, EventArgs e)
        {
            mStudentId = sstudentIdText.Text.ToString().Trim();
        }

        private void studentNameText_TextChanged(object sender, EventArgs e)
        {
            mStudentName = studentNameText.Text.ToString().Trim();
        }
        private void gradeYearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStudentGradeYear = gradeYearBox.Text;
        }
        private void majorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mStudentMajor = majors[majorBox.SelectedIndex];
            mStudentMajor = majorBox.SelectedItem.ToString();
            string sql = "SELECT DISTINCT 行政班 FROM Student_List WHERE 专业 = '" + mStudentMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);           
            int n = ds.Tables[0].Rows.Count;
            classBox.Items.Clear();
            if (n != 0)
            {
                classBox.Items.Add("");
                mClassNums = new string[n];
                for (int i = 0; i < n; i++)
                {
                    mClassNums[i] = ds.Tables[0].Rows[i][0].ToString().Trim();
                }
                classBox.Items.AddRange(mClassNums);

            }
        }
        private void classBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStudentClass = classBox.SelectedItem.ToString();
        }

        private void sexBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStudentSex = sexBox.SelectedItem.ToString();
        }

        private void nationalityText_TextChanged(object sender, EventArgs e)
        {
            mStudentNationality = nationalityText.Text.ToString().Trim();
        }

        private void politicalStatusText_TextChanged(object sender, EventArgs e)
        {
            mStudentPoliticalStatus = politicalStatusText.Text.ToString().Trim();
        }

        private void StudentListGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog studentInputDialog = new OpenFileDialog();
            studentInputDialog.InitialDirectory = defaultPath;
            //Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            studentInputDialog.Filter = "excel2007|*.xlsx|excel97-2003|*.xls";
            studentInputDialog.RestoreDirectory = true;
            if(studentInputDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = studentInputDialog.FileName;
                defaultPath = fileName.Replace(System.IO.Path.GetFileName(studentInputDialog.FileName),"");//得到文件名
                //inputDataTable.Clear();
                inputDataTable = ExcelHelper.RenderDataTableFromExcel(fileName, 0, 0);
                StudentListGridView.DataSource = inputDataTable;
                dtTag = 1;
                for (int i = 0; i < inputDataTable.Columns.Count; i++)
                {
                    columnsNames.Add(inputDataTable.Columns[i].ColumnName);
                }
                okGroupBox1.Visible = true;
                StudentListGridView.ReadOnly = true;
            }
                     
        }

        private void okButton1_Click(object sender, EventArgs e)
        {
            ArrayList SQLStringList = new ArrayList();
            for (int i = 0; i < inputDataTable.Rows.Count; i++)
            {
                string sqlCheck = "UPDATE Student_List SET 学号='" + inputDataTable.Rows[i]["学号"] + "' WHERE 学号='" + inputDataTable.Rows[i]["学号"] + "'";
                int check = DbHelperSQLite.ExecuteSql(sqlCheck);
                if (check == 1)
                {
                    DialogResult d = MessageBox.Show("学号为" + inputDataTable.Rows[i]["学号"] + "的学生信息重复\n是否更新？", "信息重复", MessageBoxButtons.YesNoCancel);
                    if (d.ToString() == "Yes")
                    {
                        string sql1 = "UPDATE Student_List SET ";
                        string sql2 = inputDataTable.Columns[1].ColumnName + "='" + inputDataTable.Rows[i][inputDataTable.Columns[1].ColumnName] + "'";
                        for (int j = 2; j < inputDataTable.Columns.Count; j++)
                        {
                            sql2 = sql2 + ", " + inputDataTable.Columns[j].ColumnName + "='" + inputDataTable.Rows[i][inputDataTable.Columns[j].ColumnName] + "'";
                        }
                        string sql = sql1 + sql2 + " WHERE 学号 = '" + inputDataTable.Rows[i]["学号"] + "'";
                        SQLStringList.Add(sql);
                    }
                }
                else
                {
                    string sql1 = "INSERT INTO Student_List(" + columnsNames[0].ToString();
                    string sql2 = ") Values('" + inputDataTable.Rows[i][columnsNames[0].ToString()];
                    for (int j = 1; j < inputDataTable.Columns.Count; j++)
                    {
                        sql1 = sql1 + "," + columnsNames[j].ToString();
                        sql2 = sql2 + "','" + inputDataTable.Rows[i][columnsNames[j].ToString()];
                    }
                    string sql = sql1 + sql2 + "')";
                    SQLStringList.Add(sql);
                }
            }
            DbHelperSQLite.ExecuteSqlTran(SQLStringList);
            MessageBox.Show("共导入" + SQLStringList.Count + "条学生信息");
            okGroupBox1.Visible = false;
        }

        private void cancelButton1_Click(object sender, EventArgs e)
        {
            inputDataTable.Clear();
            okGroupBox1.Visible = false;
        }

        private void StudentListGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void StudentListGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (StudentListGridView.RowCount != 0)
            {
                int i = e.RowIndex;
                int j = e.ColumnIndex;
                int tag = 0;
                ArrayList location = new ArrayList();
                if (locations.Count == 0)
                {
                    location.Add(i);
                    location.Add(j);
                    locations.Add(location);
                }
                else
                {
                    for (int k = 0; k < locations.Count; k++)
                    {
                        if (i.Equals(((ArrayList)locations[k])[0]))
                        {
                            ((ArrayList)locations[k]).Add(j);
                            tag = 1;
                            break;
                        }
                    }
                    if(tag == 0)
                    {
                        location.Add(i);
                        location.Add(j);
                        locations.Add(location);
                    }
                }
                                                
                updateButton.Visible = true;
            }            
            //ds.Tables[0].Rows[e.RowIndex][e.ColumnIndex] = sender.ToString();
            //MessageBox.Show(dt.Rows[e.RowIndex][e.ColumnIndex].ToString());
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ArrayList SQLiteStringList = new ArrayList();
            for(int i = 0; i < locations.Count; i++)
            {
                string sql1 = "UPDATE Student_List SET " 
                    + columnsNames[Convert.ToInt32(((ArrayList)locations[i])[1])].ToString() + "='"
                    + dt.Rows[Convert.ToInt32(((ArrayList)locations[i])[0])][Convert.ToInt32(((ArrayList)locations[i])[1])];
                for(int j = 2; j < ((ArrayList)locations[i]).Count; j++)
                {
                    sql1 = sql1 + "'," + columnsNames[Convert.ToInt32(((ArrayList)locations[i])[j])].ToString() + "='" 
                        + dt.Rows[Convert.ToInt32(((ArrayList)locations[i])[0])][Convert.ToInt32(((ArrayList)locations[i])[j])];
                }
                sql1 = sql1 + "' WHERE 学号='" + dt.Rows[Convert.ToInt32(((ArrayList)locations[i])[0])][0].ToString() + "'";
                SQLiteStringList.Add(sql1);
            }
            DbHelperSQLite.ExecuteSqlTran(SQLiteStringList);
            updateButton.Visible = false;
            locations.Clear();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = selectedIndex;
            DialogResult d = MessageBox.Show("是否删除？", "请确认", MessageBoxButtons.OKCancel);
            if(d.ToString().Equals("OK"))
            {                
                string sql = "DELETE FROM Student_List WHERE 学号='" + dt.Rows[i]["学号"] +"'";
                int j = DbHelperSQLite.ExecuteSql(sql);
                if (j == 1)
                {
                    dt.Rows[i].Delete();
                    MessageBox.Show("已成功删除");                    
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            
        }

        private void StudentListGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1) return;
                StudentListGridView.ClearSelection();
                StudentListGridView.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "excel97-2003|*.xls";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "学生名单";
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName.ToString();
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                string local = path.Substring(0, path.LastIndexOf("\\"));
                string[] oldColumnsNames = (string[])columnsNames.ToArray(typeof(string));
                string[] newColumnsNames = (string[])columnsNames.ToArray(typeof(string));
                ExcelHelper.Export(dt, name, path,"",oldColumnsNames,newColumnsNames);
            }
        }

        private void StudentListGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtTag == 0)
            {
                Common.dt = dt;
                Common.index = e.RowIndex;
                StudentInfoForm studentInfoForm = new StudentInfoForm();
                studentInfoForm.Show();
            }           
        }
        /**************************************************************************************/




        /**************************************************************************************/
        private string idText;
        private string majorText;
        private string classText;
        private string yearText;
        private string sessonText;
        private ArrayList regulerLessonGrade = new ArrayList();
        private ArrayList PElessonGrade = new ArrayList();    
        private DataTable gradeDt = new DataTable();
        private DataTable eGradeDt = new DataTable();
        private ArrayList gradeColumnNames = new ArrayList();
        string[] names = { "课程名称", "课程性质", "期末成绩", "成绩", "补考成绩" ,"学分"};
        private string getSql(string idText, string majorText, string classText, string yearText, string sessonText)
        {
            string sql = idText + majorText + yearText + sessonText;
            if(sql == "" || sql == null)
            {
                //MessageBox.Show("请输入查询条件");
            }
            else
            {
                if (idText != "" && idText != null)
                {
                    sql = "学号='" + idText + "'AND 学年 LIKE '"
                        + yearText + "%' AND 学期 LIKE'" + sessonText + "%'";
                }
                else
                {
                    sql = "专业 LIKE '" + majorText + "%' AND 行政班  LIKE '" + classText + "%' AND 学年 LIKE '"
                        + yearText + "%' AND 学期 LIKE'" + sessonText + "%'"; 
                }
            }
            return sql;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = getSql(idText, majorText, classText, yearText, sessonText);
            if(sql == "" || sql == null)
            {
                MessageBox.Show("请输入查询条件", "提示");
            }
            else
            {
                sql = "SELECT * FROM Student_Grade WHERE " + sql;
                DataSet ds = DbHelperSQLite.Query(sql);
                DataTable dt = ds.Tables[0];
                gradeDt = dt.Copy();
                gradeDt.Rows.Clear();
                ArrayList lessonNames = split(dt, "课程名称");
                ArrayList lessonProperties = split(dt, "课程性质");
                ArrayList finalGrades = split(dt, "期末成绩");
                ArrayList grades = split(dt, "成绩");
                ArrayList secondGrades = split(dt, "补考成绩");
                ArrayList lessonScore = split(dt, "学分");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < ((string[])lessonNames[i]).Count(); j++)
                    {
                        dt.Rows[i]["课程名称"] = ((string[])lessonNames[i])[j];
                        dt.Rows[i]["课程性质"] = ((string[])lessonProperties[i])[j];
                        dt.Rows[i]["期末成绩"] = ((string[])finalGrades[i])[j];
                        dt.Rows[i]["成绩"] = ((string[])grades[i])[j];
                        dt.Rows[i]["补考成绩"] = ((string[])secondGrades[i])[j];
                        dt.Rows[i]["学分"] = ((string[])lessonScore[i])[j];
                        gradeDt.ImportRow(dt.Rows[i]);
                    }
                }
                gradeDataGridView.DataSource = gradeDt;
                gradeOutputButton.Enabled = true;
                gradeRecountButton.Visible = true;
            }           
        }
        private ArrayList split(DataTable dt, string columnName)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] list = dt.Rows[i][columnName].ToString().Split();
                arrayList.Add(list);
            }            
            return arrayList;
        }
        /*private DataTable comban(DataTable dt, string[] columnNames)
        {
            int index = 0;
            string tag = dt.Rows[0]["学号"].ToString() + dt.Rows[0]["学年"].ToString() + dt.Rows[0]["学期"].ToString();
            int[] grade1 = { 0,0,0};
            int grade2 = 0;
            int[] count = {0,0,0,0 };
            regulerLessonGrade.Clear();
            PElessonGrade.Clear();
            if (dt.Rows[0]["课程性质"].ToString() == "体育项目课")
            {
                grade2 = Convert.ToInt16(dt.Rows[0]["期末成绩"]);
            }
            else
            {
                int grade;
                switch (dt.Rows[0]["期末成绩"].ToString())
                {
                    case "优":
                        grade = 85;
                        break;
                    case "良":
                        grade = 75;
                        break;
                    case "及格":
                        grade = 60;
                        break;
                    case "不及格":
                        grade = 45;
                        break;
                    default:
                        grade = Convert.ToInt16(dt.Rows[0]["期末成绩"]);
                        break;
                }
                switch(dt.Rows[0]["课程性质"].ToString())
                {
                    case "公共基础课": case "综合教育必修课": case "公共选修课":
                        grade1[0] = grade;
                        count[0] += 1;
                        break;
                    case "专业必修课": case "专业选修课":
                        grade1[1] = grade;
                        count[1] += 1;
                        break;
                    case "实践课":
                        grade1[2] = grade;
                        count[2] += 1;
                        break;
                }
            }
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                int c = dt.Rows.Count;                
                string tag1 = dt.Rows[i]["学号"].ToString() + dt.Rows[i]["学年"].ToString() + dt.Rows[i]["学期"].ToString();
                if (tag1 == tag)
                {
                    for (int j = 0; j < columnNames.Count(); j++)
                    {
                        string str = dt.Rows[index][columnNames[j]].ToString() + " " + dt.Rows[i][columnNames[j]].ToString();
                        dt.Rows[index][columnNames[j]] = str;                                              
                    }
                    if(dt.Rows[i]["课程性质"].ToString() == "体育项目课")
                    {
                        grade2 = Convert.ToInt16(dt.Rows[i]["期末成绩"]);
                    }
                    else
                    {
                        int grade = 0;
                        switch (dt.Rows[i]["期末成绩"].ToString())
                        {
                            case "优":
                            case "上":
                                grade = 85;
                                break;
                            case "良":
                            case "中":
                                grade = 75;
                                break;
                            case "及格":
                            case "下":
                                grade = 60;
                                break;
                            case "不及格":
                                grade = 45;
                                break;
                            default:
                                grade = Convert.ToInt16(dt.Rows[i]["期末成绩"]);
                                break;
                        }
                        switch (dt.Rows[i]["课程性质"].ToString())
                        {
                            case "公共基础课": case "综合教育必修课": case "公共选修课":
                                grade1[0] += grade;
                                count[0] += 1;
                                break;
                            case "专业必修课": case "专业选修课":
                                grade1[1] += grade;
                                count[1] += 1;
                                break;
                            case "实践课":
                                grade1[2] += grade;
                                count[2] += 1;
                                break;
                        }

                    }
                    dt.Rows.Remove(dt.Rows[i]);
                    i = i - 1;
                }
                else
                {
                    tag = tag1;
                    index = i;
                    double grade = (grade1[0] / count[0] + grade1[1] / count[1] + grade1[2] / count[2]) * 0.3 + grade2 * 0.1;
                    regulerLessonGrade.Add(grade);
                    grade1[0] = 0;
                    grade1[1] = 0;
                    grade1[2] = 0;
                    grade2 = 0;
                    count[0] = 0;
                    count[1] = 0;
                    count[2] = 0;
                    count[3] += 1;
                    if (dt.Rows[i]["课程性质"].ToString() == "体育项目课")
                    {
                        grade2 = Convert.ToInt16(dt.Rows[i]["期末成绩"]);
                    }
                    else
                    {
                        int grade0 = 0;
                        switch (dt.Rows[i]["期末成绩"].ToString())
                        {
                            case "优":
                                grade0 = 85;
                                break;
                            case "良":
                                grade0 = 75;
                                break;
                            case "及格":
                                grade0 = 60;
                                break;
                            case "不及格":
                                grade0 = 45;
                                break;
                            default:
                                grade0 = Convert.ToInt16(dt.Rows[i]["期末成绩"]);
                                break;
                        }
                        switch (dt.Rows[i]["课程性质"].ToString())
                        {
                            case "公共基础课":
                            case "综合教育必修课":
                            case "公共选修课":
                                grade1[0] += grade0;
                                count[0] += 1;
                                break;
                            case "专业必修课":
                            case "专业选修课":
                                grade1[1] += grade0;
                                count[1] += 1;
                                break;
                            case "实践课":
                                grade1[2] += grade0;
                                count[2] += 1;
                                break;
                        }

                    }
                }
            }
            for(int i = 0; i < count.Count() ; i++)
            {
                if(count[i] == 0)
                {
                    count[i] = 1;
                }
            }
            double grade3 = (grade1[0] / count[0] + grade1[1] / count[1] + grade1[2] / count[2]) * 0.3 + grade2 * 0.1;
            regulerLessonGrade.Add(grade3);
            //PElessonGrade.Add(grade2);
            //dt.AcceptChanges();
            return dt;
        }*/
        private DataTable comban(DataTable dt, string[] columNames)
        {
            int index = 0;
            regulerLessonGrade.Clear();
            DataTable dt1 = dt.Clone();
            dt1.Rows.Clear();
            string tag = dt.Rows[index]["学号"].ToString() + dt.Rows[index]["学年"].ToString() + dt.Rows[index]["学期"].ToString();
            DataRow dr = dt.Rows[index];
            dt1.ImportRow(dr);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                string tag1 = dt.Rows[i]["学号"].ToString() + dt.Rows[i]["学年"].ToString() + dt.Rows[i]["学期"].ToString();
                if(tag1 == tag)
                {
                    for (int j = 0; j < columNames.Count(); j++)
                    {
                        dt.Rows[index][columNames[j]] = dt.Rows[index][columNames[j]] + " " + dt.Rows[i][columNames[j]];
                    }
                    DataRow dr1 = dt.Rows[i];
                    dt1.ImportRow(dr1);
                    dt.Rows[i].Delete();
                    //i -= 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                }
                else
                {
                    countGrade(dt1);
                    dt1.Rows.Clear();
                    DataRow dr2 = dt.Rows[i];
                    dt1.ImportRow(dr2);
                    tag = tag1;
                    index = i;
                }
            }
            countGrade(dt1);
            dt.AcceptChanges();
            return dt;
        }

        private void countGrade(DataTable dt)
        {
            int[] percents = Common.percent1;
            double totalGrade = 0;
            if (percents[0] == 0)
            {
                double gradePoint = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["课程性质"].ToString())
                    {
                        case "公共基础课":
                            if(percents[1] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }                           
                            break;
                        case "公共选修课":
                            if (percents[2] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                        case "专业必修课":
                            if (percents[3] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                        case "专业选修课":
                            if (percents[4] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                        case "综合教育必修课":
                            if (percents[5] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                        case "实践课":
                            if (percents[6] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                        case "体育项目课":
                            if (percents[7] != -1)
                            {
                                totalGrade = totalGrade + getScore(dt.Rows[i]["期末成绩"].ToString()) * Convert.ToDouble(dt.Rows[i]["学分"]);
                                gradePoint += Convert.ToDouble(dt.Rows[i]["学分"]);
                            }
                            break;
                    }
                }
                totalGrade = totalGrade / gradePoint;
                regulerLessonGrade.Add(totalGrade);
            }
            else
            {
                double k = 100;
                double[] grades = { 0, 0, 0, 0, 0, 0, 0 };
                int[] count = { 0, 0, 0, 0, 0, 0, 0 };
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["课程性质"].ToString())
                    {
                        case "公共基础课":
                            if (percents[1] != -1)
                            {
                                grades[0] = grades[0] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[0] += 1;
                            }
                            break;
                        case "公共选修课":
                            if (percents[2] != -1)
                            {
                                grades[1] = grades[1] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[1] += 1;
                            }
                            break;
                        case "专业必修课":
                            if (percents[3] != -1)
                            {
                                grades[2] = grades[2] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[2] += 1;
                            }
                            break;
                        case "专业选修课":
                            if (percents[4] != -1)
                            {
                                grades[3] = grades[3] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[3] += 1;
                            }
                            break;
                        case "综合教育必修课":
                            if (percents[5] != -1)
                            {
                                grades[4] = grades[4] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[4] += 1;
                            }
                            break;
                        case "实践课":
                            if (percents[6] != -1)
                            {
                                grades[5] = grades[5] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[5] += 1;
                            }
                            break;
                        case "体育项目课":
                            if (percents[7] != -1)
                            {
                                grades[6] = grades[6] + getScore(dt.Rows[i]["期末成绩"].ToString());
                                count[6] += 1;
                            }
                            break;
                    }
                }
                if(percents[8] == 1)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if(count[i] == 0 && percents[i+1] !=-1 )
                        {
                            k -= percents[i+1];
                        }
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    if (count[i] != 0)
                    {
                        totalGrade = totalGrade + (grades[i] / count[i]) * (percents[i + 1] / k);
                    }
                }
                regulerLessonGrade.Add(totalGrade);
            }
        }
        private double getScore(string grade)
        {
            double score = 0;
            switch (grade)
            {
                case "上": case "优":
                    score = 90;
                    break;
                case "良":
                    score = 80;
                    break;
                case "中":
                    score = 70;
                    break;
                case "及格":
                    score = 60;
                    break;
                case "不及格":
                    score = 50;
                    break;
                default:
                    score = Convert.ToInt16(grade);
                    break;
            }
            return score;
        }
        private DataTable input(int tag)
        {
            DataTable dataTable = new DataTable();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = defaultPath;
            //Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "excel97-2003|*.xls|excel2007|*.xlsx";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                //defaultPath = fileName.Replace(System.IO.Path.GetFileName(studentInputDialog.FileName), "");//得到文件名
                //inputDataTable.Clear();
                dataTable = ExcelHelper.RenderDataTableFromExcel(fileName, 0, 0);
                gradeColumnNames.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                     gradeColumnNames.Add(dt.Columns[i].ColumnName);             
                }
            }
            return dataTable;
        }
        private void output(DataTable dataTable, string saveName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "excel97-2003|*.xls";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = saveName;
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName.ToString();
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                string local = path.Substring(0, path.LastIndexOf("\\"));
                ArrayList columnsNames = new ArrayList();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    columnsNames.Add(dataTable.Columns[i].ColumnName);
                }
                string[] oldColumnsNames = (string[])columnsNames.ToArray(typeof(string));
                string[] newColumnsNames = oldColumnsNames;
                ExcelHelper.Export(dataTable, name, path, "", oldColumnsNames, newColumnsNames);
            }
        }
        private void SQLiteInput(DataTable dt, string table)
        {
            ArrayList sqls = new ArrayList();
            string sql1 = "REPLACE INTO " + table;
            string sql2 = "(" + dt.Columns[0].ColumnName;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                sql2 = sql2 + ", " + dt.Columns[i].ColumnName;
            }
            sql2 = sql2 + ")";
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                string sql3 = "values('" + dt.Rows[i][0];
                for(int j = 1; j < dt.Columns.Count; j++)
                {
                    sql3 = sql3 + "','" + dt.Rows[i][j];
                }
                string sql = sql1 + sql2 + sql3 + "')";
                sqls.Add(sql);
            }
            DbHelperSQLite.ExecuteSqlTran(sqls);
        }
        private void majorComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            majorText = majorComboBox1.Text;
            string mGradeMajor = majorComboBox1.SelectedItem.ToString();
            string sql = "SELECT DISTINCT 行政班 FROM Student_List WHERE 专业 = '" + mGradeMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);
            int n = ds.Tables[0].Rows.Count;
            classComboBox2.Items.Clear();
            if (n != 0)
            {
                classComboBox2.Items.Add("");
                mClassNums = new string[n];
                for (int i = 0; i < n; i++)
                {
                    mClassNums[i] = ds.Tables[0].Rows[i][0].ToString().Trim();
                }
                classComboBox2.Items.AddRange(mClassNums);
            }
        }

        private void idTextBox1_TextChanged(object sender, EventArgs e)
        {
            idText = idTextBox1.Text;
        }

        private void classComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            classText = classComboBox2.Text;
        }

        private void yearComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearText = yearComboBox3.Text;
        }

        private void sessonComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            sessonText = sessonComboBox4.Text;
        }

        private void gradeInputButton_Click(object sender, EventArgs e)
        {
            gradeDt = input(0);
            if(gradeDt.Columns.Count != 0)
            {
                gradeDataGridView.DataSource = gradeDt;
                string[] names = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩" };
                ArrayList tags = new ArrayList();
                for (int i = 0; i < 8; i++)
                {
                    int tag = 0;
                    for (int j = 0; j < gradeDt.Columns.Count; j++)
                    {
                        if (gradeDt.Columns[j].ColumnName == names[i])
                        {
                            tag = 1;
                        }
                    }
                    tags.Add(tag);
                }
                string str = "";
                if (tags[0].ToString() == "0")
                {
                    str = str + names[0];
                }
                for (int i = 1; i < 8; i++)
                {
                    if (tags[i].ToString() == "0")
                    {
                        str = str + " " + names[i];
                    }
                }
                if (str != "")
                {
                    MessageBox.Show("缺少：" + str + "等信息", "错误");
                }
                else
                {
                    okGroupBox2.Show();
                }
            }           
        }

        private void gradeOutputButton_Click(object sender, EventArgs e)
        {
            output(gradeDt, "学生成绩单");
        }

        private void insertOKButton1_Click(object sender, EventArgs e)
        {
            DataTable gradeDt1 = gradeDt.Copy();
            DataTable dt = comban(gradeDt1, names);
            DataTable dt1 = dt;
            string[] neededNames = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩" ,"学分"};
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                int tag = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (dt1.Columns[i].ColumnName == neededNames[j])
                    {
                        tag = 1;
                    }
                }
                if(tag == 0)
                {
                    dt1.Columns.Remove(dt1.Columns[i]);
                    i -= 1;
                }
            }
            SQLiteInput(dt1, "Grade_List");
            ArrayList sqlList = new ArrayList();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                string sql = "UPDATE Evaluation_Grade SET 智育成绩 = '" + regulerLessonGrade[i] + "' WHERE 学号='" + dt.Rows[i]["学号"]
                    + "' AND 学年 = '" + dt.Rows[i]["学年"] + "' AND 学期='" + dt.Rows[i]["学期"] + "'";
                int n = DbHelperSQLite.ExecuteSql(sql);
                if (n == 0)
                {
                    sql = "REPLACE INTO Evaluation_Grade(学号,学年,学期,智育成绩) VALUES ('" + dt.Rows[i]["学号"]
                    + "','" + dt.Rows[i]["学年"] + "','" + dt.Rows[i]["学期"] + "','" + regulerLessonGrade[i] + "')";
                    sqlList.Add(sql);
                }
            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
            okGroupBox2.Visible = false;
        }

        private void insertCancelButton1_Click(object sender, EventArgs e)
        {
            okGroupBox2.Visible = false;
            gradeDt.Clear();
        }
        private void gradeRecountButton_Click(object sender, EventArgs e)
        {
            DataTable gradeDt1 = gradeDt.Copy();
            DataTable dt = comban(gradeDt1, names);
            DataTable dt1 = dt;
            string[] neededNames = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩", "学分" };
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                int tag = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (dt1.Columns[i].ColumnName == neededNames[j])
                    {
                        tag = 1;
                    }
                }
                if (tag == 0)
                {
                    dt1.Columns.Remove(dt1.Columns[i]);
                    i -= 1;
                }
            }
            SQLiteInput(dt1, "Grade_List");
            ArrayList sqlList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql = "UPDATE Evaluation_Grade SET 智育成绩 = '" + regulerLessonGrade[i] + "' WHERE 学号='" + dt.Rows[i]["学号"]
                    + "' AND 学年 = '" + dt.Rows[i]["学年"] + "' AND 学期='" + dt.Rows[i]["学期"] + "'";
                int n = DbHelperSQLite.ExecuteSql(sql);
                if (n == 0)
                {
                    sql = "REPLACE INTO Evaluation_Grade(学号,学年,学期,智育成绩) VALUES ('" + dt.Rows[i]["学号"]
                    + "','" + dt.Rows[i]["学年"] + "','" + dt.Rows[i]["学期"] + "','" + regulerLessonGrade[i] + "')";
                    sqlList.Add(sql);
                }

            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
            gradeRecountButton.Visible = false;
        }
        private void gradeDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (okGroupBox2.Visible != true)
            {
                gradeUpdateButton.Visible = true;
            }
        }
        private void gradeUpdateButton_Click(object sender, EventArgs e)
        {
            DataTable gradeDt1 = gradeDt.Copy();
            DataTable dt = comban(gradeDt1, names);
            DataTable dt1 = dt;
            string[] neededNames = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩","学分" };
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                int tag = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (dt1.Columns[i].ColumnName == neededNames[j])
                    {
                        tag = 1;
                    }
                }
                if (tag == 0)
                {
                    dt1.Columns.Remove(dt1.Columns[i]);
                    i -= 1;
                }
            }
            SQLiteInput(dt1, "Grade_List");
            ArrayList sqlList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql = "UPDATE Evaluation_Grade SET 智育成绩 = '" + regulerLessonGrade[i] + "' WHERE 学号='" + dt.Rows[i]["学号"]
                    + "' AND 学年 = '" + dt.Rows[i]["学年"] + "' AND 学期='" + dt.Rows[i]["学期"] + "'";
                int n = DbHelperSQLite.ExecuteSql(sql);
                if( n == 0)
                {
                    sql = "REPLACE INTO Evaluation_Grade(学号,学年,学期,智育成绩) VALUES ('" + dt.Rows[i]["学号"]
                    + "','" + dt.Rows[i]["学年"] + "','" + dt.Rows[i]["学期"] + "','" + regulerLessonGrade[i] + "')";
                    sqlList.Add(sql);
                }
                
            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
            gradeUpdateButton.Visible = false;
        }        
        private void gradeDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1) return;
                gradeDataGridView.ClearSelection();
                gradeDataGridView.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }        
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = selectedIndex;
            DialogResult d = MessageBox.Show("是否删除？", "请确认", MessageBoxButtons.OKCancel);
            if (d.ToString().Equals("OK"))
            {
                gradeDt.Rows.Remove(gradeDt.Rows[index]);
                DataTable gradeDt1 = gradeDt.Copy();
                DataTable dt = comban(gradeDt1, names);
                DataTable dt1 = dt;
                string[] neededNames = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩" };
                for (int i = 0; i < dt1.Columns.Count; i++)
                {
                    int tag = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (dt1.Columns[i].ColumnName == neededNames[j])
                        {
                            tag = 1;
                        }
                    }
                    if (tag == 0)
                    {
                        dt1.Columns.Remove(dt1.Columns[i]);
                        i -= 1;
                    }
                }
                SQLiteInput(dt1, "Grade_List");
                ArrayList sqlList = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "UPDATE Evaluation_Grade SET 智育成绩 = '" + regulerLessonGrade[i] + "' WHERE 学号='" + dt.Rows[i]["学号"]
                    + "' AND 学年 = '" + dt.Rows[i]["学年"] + "' AND 学期='" + dt.Rows[i]["学期"] + "'";
                    int n = DbHelperSQLite.ExecuteSql(sql);
                    if (n == 0)
                    {
                        sql = "REPLACE INTO Evaluation_Grade(学号,学年,学期,智育成绩) VALUES ('" + dt.Rows[i]["学号"]
                        + "','" + dt.Rows[i]["学年"] + "','" + dt.Rows[i]["学期"] + "','" + regulerLessonGrade[i] + "')";
                        sqlList.Add(sql);
                    }
                }
                DbHelperSQLite.ExecuteSqlTran(sqlList);
            }
        }
        /*********************************************************************/




        /*********************************************************************/

        private DataTable activityDt = new DataTable();
        private DataTable studentDt = new DataTable();
        //private DataTable evaluationDt = new DataTable();
        private ArrayList locations1 = new ArrayList();       
        private ArrayList activityColumnNames = new ArrayList();
        private DataTable newEvaluationDt(DataTable dt)
        {
            DataTable evaluationDt = new DataTable();
            //evaluationDt.Columns.Add(dt.Columns["学号"]);
            //evaluationDt.Columns.Add(dt.Columns["评测项目"]);
            evaluationDt.Columns.Add("学号", typeof(string));
            evaluationDt.Columns.Add("学年", typeof(string));
            evaluationDt.Columns.Add("学期", typeof(int));
            evaluationDt.Columns.Add("评测项目", typeof(string));
            evaluationDt.Columns.Add("内容", typeof(string));
            evaluationDt.Columns.Add("分值", typeof(double));
            return evaluationDt;
        }
        private void searchButton2_Click(object sender, EventArgs e)
        {
            activityUpdateButton1.Visible = false;
            string date = "";
            if(dateTimePicker1.Checked == true)
            {
                date = "AND 活动日期 = '" + dateTimePicker1.Text + "'";
            }
            else
            {
                date = "";
            }
            string text = activityNameText.Text + date + yearComboBox1.Text + sessonComboBox1.Text;
            if(text == "")
            {
                MessageBox.Show("请输入条件", "提示");
            }
            else
            {
                string sql = "SELECT * FROM Activities_List WHERE 活动名称 LIKE '%" + activityNameText.Text + "%'"
                + date + " AND 学年 LIKE '%" + yearComboBox1.Text + "%' AND 学期 LIKE '%" + sessonComboBox1.Text + "%'";
                activityDt = DbHelperSQLite.Query(sql).Tables[0];
                if (activityDt.Rows.Count != 0)
                {
                    if (activityColumnNames.Count == 0)
                    {
                        for (int i = 0; i < activityDt.Columns.Count; i++)
                        {
                            activityColumnNames.Add(activityDt.Columns[i].ColumnName);
                        }
                    }
                    activityDataGridView.DataSource = activityDt;
                    activityOutputButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("未找到相关信息", "提示");
                }
                if (returnActivityButton.Visible == true)
                {
                    returnActivityButton.Visible = false;
                }
            }
        }

        private void activityInputButton_Click(object sender, EventArgs e)
        {
            ActivityInputForm activityInputForm = new ActivityInputForm();
            activityInputForm.Show();
        }

        private void activityDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selectedIndex = index;
            string sql = "SELECT * FROM Student_Activity WHERE 活动序列 = '" + activityDt.Rows[index]["活动序列"] + "'";
            studentDt = DbHelperSQLite.Query(sql).Tables[0];
            activityDataGridView.DataSource = studentDt;
            activityDataGridView.ContextMenuStrip = contextMenuStrip4;
            activityDataGridView.ReadOnly = true;
            returnActivityButton.Visible = true;
            listInputButton.Visible = true;
        }

        private void returnActivityButton_Click(object sender, EventArgs e)
        {
            activityDataGridView.DataSource = activityDt;
            activityDataGridView.ContextMenuStrip = contextMenuStrip3;
            activityDataGridView.ReadOnly = false;
            returnActivityButton.Visible = false;
            listInputButton.Visible = false;
        }
        private void listInputButton_Click(object sender, EventArgs e)
        {
            DataTable inputActivityDt1 = input(0);
            if (inputActivityDt1.Rows.Count != 0)
            {
                int tag1 = 0;
                for (int i = 0; i < inputActivityDt1.Columns.Count; i++)
                {
                    if (inputActivityDt1.Columns[i].ColumnName == "学号")
                    {
                        tag1 = 1;
                        break;
                    }
                    else
                    {
                        inputActivityDt1.Columns.Remove(inputActivityDt1.Columns[i]);
                        i--;
                    }
                }
                if (tag1 != 1)
                {
                    MessageBox.Show("请提供学生学号信息", "提示");
                }
                else
                {
                    DataTable excistCheckDt = DbHelperSQLite.Query("SELECT 学号 FROM Activities_Student WHERE 活动序列 = "
                        + activityDt.Rows[selectedIndex]["活动序列"]).Tables[0];
                    inputActivityDt1.Columns.Add("活动序列", typeof(string));
                    DataTable evaluationDt = newEvaluationDt(inputActivityDt1);
                    int k = 0;
                    for (int i = 0; i < inputActivityDt1.Rows.Count; i++)
                    {
                        int tag = 0;
                        for (int j = 0; j < excistCheckDt.Rows.Count; j++)
                        {
                            if (excistCheckDt.Rows[j]["学号"].ToString() == inputActivityDt1.Rows[i]["学号"].ToString())
                            {
                                tag = 1;
                                break;
                            }
                        }
                        if (tag == 0)
                        {
                            evaluationDt.Rows.Add();
                            evaluationDt.AcceptChanges();
                            inputActivityDt1.Rows[i]["活动序列"] = activityDt.Rows[selectedIndex]["活动序列"];
                            evaluationDt.Rows[k]["学号"] = inputActivityDt1.Rows[i]["学号"];
                            evaluationDt.Rows[k]["学年"] = activityDt.Rows[selectedIndex]["学年"];
                            evaluationDt.Rows[k]["学期"] = activityDt.Rows[selectedIndex]["学期"];
                            evaluationDt.Rows[k]["评测项目"] = activityDt.Rows[selectedIndex]["评测项目"];
                            evaluationDt.Rows[k]["内容"] = "参加：" + activityDt.Rows[selectedIndex]["活动名称"];
                            evaluationDt.Rows[k]["分值"] = activityDt.Rows[selectedIndex]["活动加分"];
                            k++;
                        }
                    }
                    string itemIndex = DbHelperSQLite.Query("SELECT MAX(记录序列) FROM Evaluation_Item").Tables[0].Rows[0][0].ToString();
                    SQLiteInput(inputActivityDt1, "Activities_Student");
                    SQLiteInput(evaluationDt, "Evaluation_Item");
                    int itemIndex1 = Convert.ToInt16(itemIndex);
                    ArrayList sqlList = new ArrayList();
                    for (int i = 0; i < evaluationDt.Rows.Count; i++)
                    {
                        itemIndex1++;
                        string sql = "INSERT INTO Activities_Item(学号,活动序列,记录序列) VALUES('" + evaluationDt.Rows[i]["学号"]
                            + "'," + activityDt.Rows[selectedIndex]["活动序列"] + "," + itemIndex1.ToString() + ") ";
                        sqlList.Add(sql);
                    }
                    DbHelperSQLite.ExecuteSqlTran(sqlList);
                }
            }
            string sql1 = "SELECT * FROM Student_Activity WHERE 活动序列 = '" + activityDt.Rows[selectedIndex]["活动序列"] + "'";
            studentDt = DbHelperSQLite.Query(sql1).Tables[0];
            activityDataGridView.DataSource = studentDt;
        }
        private void activityDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1) return;
                activityDataGridView.ClearSelection();
                activityDataGridView.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }

        private void 导入名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable inputActivityDt1 = input(0);
            if (inputActivityDt1.Rows.Count != 0)
            {
                int tag1 = 0;
                for (int i = 0; i < inputActivityDt1.Columns.Count; i++)
                {
                    if (inputActivityDt1.Columns[i].ColumnName == "学号")
                    {
                        tag1 = 1;
                        break;
                    }
                    else
                    {
                        inputActivityDt1.Columns.Remove(inputActivityDt1.Columns[i]);
                        i--;
                    }
                }
                if(tag1 != 1)
                {
                    MessageBox.Show("请提供学生学号信息", "提示");
                }
                else
                {
                    DataTable excistCheckDt = DbHelperSQLite.Query("SELECT 学号 FROM Activities_Student WHERE 活动序列 = " 
                        + activityDt.Rows[selectedIndex]["活动序列"]).Tables[0];
                    inputActivityDt1.Columns.Add("活动序列", typeof(string));
                    DataTable evaluationDt = newEvaluationDt(inputActivityDt1);
                    int k = 0;
                    for (int i = 0; i < inputActivityDt1.Rows.Count; i++)
                    {
                        int tag = 0;
                        for(int j = 0; j < excistCheckDt.Rows.Count; j++)
                        {
                            if(excistCheckDt.Rows[j]["学号"].ToString() == inputActivityDt1.Rows[i]["学号"].ToString())
                            {
                                tag = 1;
                                break;
                            }
                        }
                        if (tag == 0)
                        {
                            evaluationDt.Rows.Add();
                            evaluationDt.AcceptChanges();
                            inputActivityDt1.Rows[i]["活动序列"] = activityDt.Rows[selectedIndex]["活动序列"];
                            evaluationDt.Rows[k]["学号"] = inputActivityDt1.Rows[i]["学号"];
                            evaluationDt.Rows[k]["学年"] = activityDt.Rows[selectedIndex]["学年"];
                            evaluationDt.Rows[k]["学期"] = activityDt.Rows[selectedIndex]["学期"];
                            evaluationDt.Rows[k]["评测项目"] = activityDt.Rows[selectedIndex]["评测项目"];
                            evaluationDt.Rows[k]["内容"] = "参加：" + activityDt.Rows[selectedIndex]["活动名称"];
                            evaluationDt.Rows[k]["分值"] = activityDt.Rows[selectedIndex]["活动加分"];
                            k++;
                        }
                    }
                    string itemIndex = DbHelperSQLite.Query("SELECT MAX(记录序列) FROM Evaluation_Item").Tables[0].Rows[0][0].ToString();
                    SQLiteInput(inputActivityDt1, "Activities_Student");
                    SQLiteInput(evaluationDt, "Evaluation_Item");
                    int itemIndex1 = Convert.ToInt16(itemIndex);
                    ArrayList sqlList = new ArrayList();
                    for(int i = 0; i < evaluationDt.Rows.Count; i++)
                    {
                        itemIndex1++;
                        string sql = "INSERT INTO Activities_Item(学号,活动序列,记录序列) VALUES('" + evaluationDt.Rows[i]["学号"]
                            + "'," + activityDt.Rows[selectedIndex]["活动序列"] + "," + itemIndex1.ToString() + ") ";
                        sqlList.Add(sql);
                    }
                    DbHelperSQLite.ExecuteSqlTran(sqlList);
                }
            }
        }

        private void 删除活动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql1 = "DELETE FROM Activites_List WHERE 活动序列 = " + activityDt.Rows[selectedIndex]["活动序列"];
            string sql2 = "DELETE FROM Activites_Student WHERE 活动序列 = '" + activityDt.Rows[selectedIndex]["活动序列"] + "'";
            DbHelperSQLite.ExecuteSql(sql1);
            DbHelperSQLite.ExecuteSql(sql2);
        }

        private void 清空名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable itemIndexs = DbHelperSQLite.Query("SELECT * FROM Activities_Item WHERE 活动序列 = '"
                + activityDt.Rows[selectedIndex]["活动序列"] + "'").Tables[0];
            ArrayList sqlList = new ArrayList();
            string sql1 = "DELETE FROM Activites_Student WHERE 活动序列 = '" + activityDt.Rows[selectedIndex]["活动序列"] + "'";
            sqlList.Add(sql1);
            for(int i = 0; i < itemIndexs.Rows.Count; i++)
            {
                string sql2 = "DELETE FROM Evaluation_Item WHERE 记录序列 = " + itemIndexs.Rows[i]["记录序列"];
                sqlList.Add(sql2);
            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
        }

        private void activityDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            int tag = 0;
            ArrayList location = new ArrayList();
            if (locations1.Count == 0)
            {
                location.Add(i);
                location.Add(j);
                locations1.Add(location);
            }
            else
            {
                for (int k = 0; k < locations1.Count; k++)
                {
                    if (i.Equals(((ArrayList)locations1[k])[0]))
                    {
                        ((ArrayList)locations1[k]).Add(j);
                        tag = 1;
                        break;
                    }
                }
                if(tag == 0)
                {
                    location.Add(i);
                    location.Add(j);
                    locations1.Add(location);
                }
            }
            activityUpdateButton1.Visible = true;
        }

        private void activityUpdateButton1_Click(object sender, EventArgs e)
        {
            ArrayList SQLiteStringList = new ArrayList();
            for (int i = 0; i < locations1.Count; i++)
            {
                 string sql1 = "UPDATE Activities_List SET "
                    + activityColumnNames[Convert.ToInt32(((ArrayList)locations1[i])[1])].ToString() + "='"
                    + activityDt.Rows[Convert.ToInt32(((ArrayList)locations1[i])[0])][Convert.ToInt32(((ArrayList)locations1[i])[1])];
                 for (int j = 2; j < ((ArrayList)locations1[i]).Count; j++)
                 {
                     sql1 = sql1 + "'," + activityColumnNames[Convert.ToInt32(((ArrayList)locations1[i])[j])].ToString() + "='"
                        + activityDt.Rows[Convert.ToInt32(((ArrayList)locations1[i])[0])][Convert.ToInt32(((ArrayList)locations1[i])[j])];
                 }
                 sql1 = sql1 + "' WHERE 活动序列='" + activityDt.Rows[Convert.ToInt32(((ArrayList)locations1[i])[0])][0].ToString() + "'";
                 SQLiteStringList.Add(sql1);
            }
            DbHelperSQLite.ExecuteSqlTran(SQLiteStringList);
            activityUpdateButton1.Visible = false;
            locations1.Clear();
        }

        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable itemIndexs = DbHelperSQLite.Query("SELECT 记录序列 FROM Activities_Item WHERE 活动序列 = '"
                + studentDt.Rows[selectedIndex]["活动序列"] + "' AND 学号 = '" + studentDt.Rows[selectedIndex]["学号"] 
                + "'").Tables[0];
            string sql = "DELETE FROM Activities_Student WHERE 活动序列 = '"
                + studentDt.Rows[selectedIndex]["活动序列"]
                + "' AND 学号 = '" + studentDt.Rows[selectedIndex]["学号"] + "'";
            string sql1 = "DELETE FROM Activities_Item WHERE 活动序列 = '"
                + studentDt.Rows[selectedIndex]["活动序列"] + "' AND 学号 = '" + studentDt.Rows[selectedIndex]["学号"]
                + "'";
            string sql2 = "DELETE FROM Evaluation_Item WHERE 记录序列 =" + Convert.ToInt16(itemIndexs.Rows[0][0]);
            ArrayList sqlList = new ArrayList();
            sqlList.Add(sql);
            sqlList.Add(sql1);
            sqlList.Add(sql2);
            studentDt.Rows.Remove(studentDt.Rows[selectedIndex]);
            DbHelperSQLite.ExecuteSqlTran(sqlList);
        }

        /********************************************************************/




        /********************************************************************/
        private DataTable evaluationGradeDt = new DataTable();
        private DataTable evaluationListDt = new DataTable();
        private DataTable evaluationOutDt = new DataTable();
        private ArrayList locations2 = new ArrayList();
        private ArrayList evaluationColumnNames = new ArrayList();
        private void eSearchButton1_Click(object sender, EventArgs e)
        {
            string text = eIdTextBox1.Text + eYearComboBox1.Text + eSessionComboBox2.Text + eMajorComboBox3.Text;
            if (text != null & text != "")
            {
                记录序列.Visible = false;
                string sql = "SELECT * FROM Student_EGrade WHERE ";
                string sql1 = "";
                if (eIdTextBox1.Text != null && eIdTextBox1.Text != "")
                {
                    sql = sql + "学号 = '" + eIdTextBox1.Text
                        + "' AND 学年 LIKE '%" + eYearComboBox1.Text + "%' AND 学期 LIKE '%"
                        + eSessionComboBox2.Text + "%'";
                }
                else
                {
                    sql = sql + "学年 LIKE '%" + eYearComboBox1.Text + "%' AND 学期 LIKE '%"
                    + eSessionComboBox2.Text + "%'";
                    if (eMajorComboBox3.Text != "" && eMajorComboBox3.Text != null)
                    {
                        sql1 = "(SELECT 学号 FROM Student_List WHERE 专业 LIKE '%" + eMajorComboBox3.Text
                        + "%' ANd 行政班 LIKE '%" + eClassComboBox4.Text + "%')";
                        sql = sql + "AND 学号 IN " + sql1;
                    }
                }
                evaluationGradeDt = DbHelperSQLite.Query(sql).Tables[0];
                evaluationDataGridView.DataSource = evaluationGradeDt;
                eOutputButton.Enabled = true;
                evaluationDataGridView.ReadOnly = true;
                evaluationOutDt = evaluationGradeDt;
                evaluationDataGridView.ContextMenuStrip = contextMenuStrip5;
            }
            else
            {
                MessageBox.Show("请输入查询条件", "提示");
            }
        }

        private void eSearchButton2_Click(object sender, EventArgs e)
        {
            string text = eIdTextBox1.Text + eYearComboBox1.Text + eSessionComboBox2.Text + eMajorComboBox3.Text;
            if (text != null & text != "")
            {
                记录序列.Visible = true;
                string sql = "SELECT * FROM Student_EItem WHERE ";
                string sql1 = "";
                if (eIdTextBox1.Text != null && eIdTextBox1.Text != "")
                {
                    sql = sql + "学号 = '" + eIdTextBox1.Text
                        + "' AND 学年 LIKE '%" + eYearComboBox1.Text + "%' AND 学期 LIKE '%"
                        + eSessionComboBox2.Text + "%'";
                }
                else
                {
                    sql = sql + "学年 LIKE '%" + eYearComboBox1.Text + "%' AND 学期 LIKE '%"
                    + eSessionComboBox2.Text + "%'";
                    if (eMajorComboBox3.Text != "" && eMajorComboBox3.Text != null)
                    {
                        sql1 = "(SELECT 学号 FROM Student_List WHERE 专业 LIKE '%" + eMajorComboBox3.Text
                        + "%' ANd 行政班 LIKE '%" + eClassComboBox4.Text + "%')";
                        sql = sql + "AND 学号 IN " + sql1;
                    }
                }
                evaluationListDt = DbHelperSQLite.Query(sql).Tables[0];
                for (int i = 0; i < evaluationListDt.Columns.Count; i++)
                {
                    evaluationColumnNames.Add(evaluationListDt.Columns[i].ColumnName);
                }
                evaluationDataGridView.DataSource = evaluationListDt;
                eOutputButton.Enabled = true;
                evaluationDataGridView.ReadOnly = false;
                evaluationOutDt = evaluationListDt;
                evaluationDataGridView.ContextMenuStrip = contextMenuStrip6;
            }
            else
            {
                MessageBox.Show("请输入查询条件", "提示");
            }
        }

        private void eInputButton_Click(object sender, EventArgs e)
        {
            evaluationListDt = input(0);
            if(evaluationListDt.Rows.Count != 0)
            {
                evaluationDataGridView.DataSource = evaluationListDt;
                eGroupBox1.Visible = true;
                evaluationDataGridView.ContextMenuStrip = null;
            }
            else
            {
                MessageBox.Show("未导入文件或文件没有数据", "提示");
            }
        }

        private void eInputOkbutton_Click(object sender, EventArgs e)
        {
            SQLiteInput(evaluationListDt, "Evaluation_Item");
            eGroupBox1.Visible = false;
        }

        private void cancelInputButton_Click(object sender, EventArgs e)
        {
            evaluationDataGridView.DataSource = null;
            eGroupBox1.Visible = false;
        }

        private void eOutputButton_Click(object sender, EventArgs e)
        {
            output(evaluationOutDt, "综评信息");
        }

        private void evaluationDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            int tag = 0;
            ArrayList location = new ArrayList();
            if (locations1.Count == 0)
            {
                location.Add(i);
                location.Add(j);
                locations2.Add(location);
            }
            else
            {
                for (int k = 0; k < locations2.Count; k++)
                {
                    if (i.Equals(((ArrayList)locations2[k])[0]))
                    {
                        ((ArrayList)locations2[k]).Add(j);
                        tag = 1;
                        break;
                    }
                }
                if (tag == 0)
                {
                    location.Add(i);
                    location.Add(j);
                    locations2.Add(location);
                }
            }
            eUpdateButton.Visible = true;
        }

        private void eUpdateButton_Click(object sender, EventArgs e)
        {
            ArrayList SQLiteStringList = new ArrayList();
            for (int i = 0; i < locations2.Count; i++)
            {
                string sql1 = "UPDATE Evaluation_Item SET "
                   + evaluationColumnNames[Convert.ToInt32(((ArrayList)locations2[i])[1])].ToString() + "='"
                   + evaluationListDt.Rows[Convert.ToInt32(((ArrayList)locations2[i])[0])][Convert.ToInt32(((ArrayList)locations2[i])[1])];
                for (int j = 2; j < ((ArrayList)locations2[i]).Count; j++)
                {
                    sql1 = sql1 + "'," + evaluationColumnNames[Convert.ToInt32(((ArrayList)locations2[i])[j])].ToString() + "='"
                       + evaluationListDt.Rows[Convert.ToInt32(((ArrayList)locations2[i])[0])][Convert.ToInt32(((ArrayList)locations2[i])[j])];
                }
                sql1 = sql1 + "' WHERE 记录序列='" + evaluationListDt.Rows[Convert.ToInt32(((ArrayList)locations2[i])[0])][0].ToString() + "'";
                SQLiteStringList.Add(sql1);
            }
            DbHelperSQLite.ExecuteSqlTran(SQLiteStringList);
            eUpdateButton.Visible = false;
            locations2.Clear();
        }

        private void eMajorComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string eStudentMajor = eMajorComboBox3.SelectedItem.ToString();
            string sql = "SELECT DISTINCT 行政班 FROM Student_List WHERE 专业 = '" + eStudentMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);
            int n = ds.Tables[0].Rows.Count;
            eClassComboBox4.Items.Clear();
            if (n != 0)
            {
                eClassComboBox4.Items.Add("");
                mClassNums = new string[n];
                for (int i = 0; i < n; i++)
                {
                    mClassNums[i] = ds.Tables[0].Rows[i][0].ToString().Trim();
                }
                eClassComboBox4.Items.AddRange(mClassNums);
            }
        }

        /*private void evaluationCalculate(string studentId, string year, string sesson)
        {
            double grade1 = 20;
            double grade2 = 0;
            double grade3 = 10;
            double grade4 = 0;
            double grade = 0;           
            string sql = "SELECT 评测项目,分值 FROM Evaluation_Item WHERE 学号 = '" + studentId
                + "' AND 学年 = '" + year
                + "' AND 学期 = '" + sesson + "'";
            DataTable dt = DbHelperSQLite.Query(sql).Tables[0];
            string sql1 = "SELECT 智育成绩 FROM Evaluation_Grade WHERE 学号 = '" + studentId
                + "' AND 学年 = '" + year
                + "' AND 学期 = '" + sesson + "'";
            grade2 = Convert.ToDouble(DbHelperSQLite.Query(sql1).Tables[0].Rows[0][0]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["评测项目"].ToString())
                {
                    case "德育评测":
                    case "德育测评":
                        grade1 += Convert.ToDouble(dt.Rows[i]["分值"]);
                        if(grade1 > 100)
                        {
                            grade1 = 100;
                        }
                        else if(grade1 < 0)
                        {
                            grade1 = 0;
                        }
                        break;
                    case "能力评测":
                    case "能力测评":
                        grade3 += Convert.ToDouble(dt.Rows[i]["分值"]);
                        break;
                    case "个性发展评测":
                    case "个性发展测评":
                        grade4 += Convert.ToDouble(dt.Rows[i]["分值"]);
                        if (grade1 > 40)
                        {
                            grade1 = 40;
                        }
                        break;
                }
            }
            grade = grade1 * 0.4 + grade2 * 0.4 + grade3 * 0.2 + grade4;
            string sql2 = "REPLACE INTO Evaluation_Grade(学号,学年,学期,德育成绩,智育成绩,能力成绩,个性发展成绩,总成绩) VALUES('" + studentId
                + "','" + year + "','" + sesson + "', " + grade1.ToString() + "," + grade2.ToString()
                + "," + grade3.ToString() + "," + grade4.ToString() + "," + grade.ToString() + ")";
            DbHelperSQLite.ExecuteSql(sql2);
        }*/

        private void evaluationDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1) return;
                evaluationDataGridView.ClearSelection();
                evaluationDataGridView.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }

        private void 计算成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eStudentId = evaluationGradeDt.Rows[selectedIndex]["学号"].ToString();
            string year = evaluationGradeDt.Rows[selectedIndex]["学年"].ToString();
            string sesson = evaluationGradeDt.Rows[selectedIndex]["学期"].ToString();
            Common.evaluationCalculate(eStudentId, year, sesson);
        }

        private void 删除ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Evaluation_Item WHERE 记录序列 = '" + evaluationListDt.Rows[selectedIndex]["记录序列"] + "'";
            DbHelperSQLite.ExecuteSql(sql);
            string eStudentId = evaluationListDt.Rows[selectedIndex]["学号"].ToString();
            string year = evaluationListDt.Rows[selectedIndex]["学年"].ToString();
            string sesson = evaluationListDt.Rows[selectedIndex]["学期"].ToString();
            Common.evaluationCalculate(eStudentId, year, sesson);
            evaluationListDt.Rows.Remove(evaluationListDt.Rows[selectedIndex]);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateForm calculateFrom = new CalculateForm();
            calculateFrom.Show();
        }

        private void setupLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {

        }

        private void activityOutputButton_Click(object sender, EventArgs e)
        {
            output((DataTable)activityDataGridView.DataSource, "活动信息");
        }

        private void sortByClick(DataGridView dgv, DataTable dt, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgv.Columns[e.ColumnIndex].Name;
            SortOrder so = dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            if (so == SortOrder.Ascending)
            {
                columnName += " asc";
            }
            else if (so == SortOrder.Descending)
            {
                columnName += " desc";
            }
            DataTable dt1 = dt.Copy();
            DataRow[] drs = dt1.Select(String.Empty, columnName);
            dt.Clear();
            foreach (DataRow dr in drs)
            {
                dt.ImportRow(dr);
            }
            dgv.DataSource = dt;
        }
        private void StudentListGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                sortByClick(StudentListGridView, dt, e);
            }
        }

        private void evaluationDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(evaluationDataGridView, (DataTable)evaluationDataGridView.DataSource, e);
            }
        }

        private void activityDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(activityDataGridView, (DataTable)activityDataGridView.DataSource, e);
            }
        }

        private void gradeDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(gradeDataGridView, (DataTable)gradeDataGridView.DataSource, e);
            }
        }


    }
}
