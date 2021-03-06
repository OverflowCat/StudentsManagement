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
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }
        private string studentId = Common.dt.Rows[Common.index]["学号"].ToString();
        private DataTable dt = new DataTable();
        private int index = Common.index;
        private string studentName;

        private void StudentInfoForm_Load(object sender, EventArgs e)
        {
            dt = Common.dt.Copy();
            studentName = Common.dt.Rows[index]["姓名"].ToString();
            idTextBox.Text = studentId;
            NameTextBox.Text = studentName;
            oldNameTextBox.Text = dt.Rows[index]["曾用名"].ToString();
            sexTextBox.Text = dt.Rows[index]["性别"].ToString();
            nationTextBox.Text = dt.Rows[index]["民族"].ToString();
            majorTextBox.Text = dt.Rows[index]["专业"].ToString();
            hometownTextBox.Text = dt.Rows[index]["籍贯"].ToString();
            policTextBox.Text = dt.Rows[index]["政治面貌"].ToString();
            birthTextBox.Text = dt.Rows[index]["出生日期"].ToString();
            idcardTextBox.Text = dt.Rows[index]["身份证号"].ToString();
            classTextBox.Text = dt.Rows[index]["行政班"].ToString();
            studyYearTextBox.Text = dt.Rows[index]["学制"].ToString();
            gradeTextBox.Text = dt.Rows[index]["当前所在级"].ToString();
            inDateTextBox.Text = dt.Rows[index]["入学日期"].ToString();
            roomTextBox.Text = dt.Rows[index]["宿舍号"].ToString();
            levelTextBox.Text = dt.Rows[index]["学历层次"].ToString();
            eLevelTextBox.Text = dt.Rows[index]["英语等级"].ToString();
            eGradeTextBox.Text = dt.Rows[index]["英语成绩"].ToString();
            pclevelText.Text = dt.Rows[index]["计算机等级"].ToString();
            pcgradeText.Text = dt.Rows[index]["计算机成绩"].ToString();
            phoneTextBox.Text = dt.Rows[index]["手机号"].ToString();
            qqTextBox.Text = dt.Rows[index]["QQ号"].ToString();
            emailTextBox.Text = dt.Rows[index]["电子邮箱"].ToString();
            addressTextBox.Text = dt.Rows[index]["家庭地址"].ToString();
            codeTextBox.Text = dt.Rows[index]["邮政编码"].ToString();
            mNameTextBox.Text = dt.Rows[index]["母亲姓名"].ToString();
            fNameTextBox.Text = dt.Rows[index]["父亲姓名"].ToString();
            mPhoneTextBox.Text = dt.Rows[index]["母亲电话"].ToString();
            fPhoneTextBox.Text = dt.Rows[index]["父亲电话"].ToString();
            mWorkTextBox.Text = dt.Rows[index]["母亲单位"].ToString();
            fWorktextBox.Text = dt.Rows[index]["父亲单位"].ToString();
            psTextBox.Text = dt.Rows[index]["备注"].ToString();
            updateButton1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /*private DataTable comban(DataTable dt, string[] columnNames)
        {
            int index = 0;
            string tag = dt.Rows[0]["学号"].ToString() + dt.Rows[0]["学年"].ToString() + dt.Rows[0]["学期"].ToString();
            int[] grade1 = { 0, 0, 0 };
            int grade2 = 0;
            int[] count = { 0, 0, 0, 0 };
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
                switch (dt.Rows[0]["课程性质"].ToString())
                {
                    case "公共基础课":
                    case "综合教育必修课":
                    case "公共选修课":
                        grade1[0] = grade;
                        count[0] += 1;
                        break;
                    case "专业必修课":
                    case "专业选修课":
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
                    if (dt.Rows[i]["课程性质"].ToString() == "体育项目课")
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
                            case "公共基础课":
                            case "综合教育必修课":
                            case "公共选修课":
                                grade1[0] += grade;
                                count[0] += 1;
                                break;
                            case "专业必修课":
                            case "专业选修课":
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
            for (int i = 0; i < count.Count(); i++)
            {
                if (count[i] == 0)
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
                if (tag1 == tag)
                {
                    for (int j = 0; j < columNames.Count(); j++)
                    {
                        dt.Rows[index][columNames[j]] = dt.Rows[index][columNames[j]] + " " + dt.Rows[i][columNames[j]];
                    }
                    DataRow dr1 = dt.Rows[i];
                    dt1.ImportRow(dr1);
                    dt.Rows[i].Delete();
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
                            if (percents[1] != -1)
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
                for (int i = 0; i < dt.Rows.Count; i++)
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
                if (percents[8] == 1)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (count[i] == 0 && percents[i + 1] != -1)
                        {
                            k -= percents[i + 1];
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
                case "上":
                case "优":
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
            openFileDialog.Filter = "excel2007|*.xlsx|excel97-2003|*.xls";
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql3 = "values('" + dt.Rows[i][0];
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    sql3 = sql3 + "','" + dt.Rows[i][j];
                }
                string sql = sql1 + sql2 + sql3 + "')";
                sqls.Add(sql);
            }
            DbHelperSQLite.ExecuteSqlTran(sqls);
        }


        /**********************************************************/




        /**********************************************************/
        private ArrayList regulerLessonGrade = new ArrayList();
        private ArrayList PElessonGrade = new ArrayList();
        private DataTable gradeDt = new DataTable();
        private DataTable eGradeDt = new DataTable();
        private ArrayList gradeColumnNames = new ArrayList();
        string[] names = { "课程名称", "课程性质", "期末成绩", "成绩", "补考成绩", "学分" };
        private int selectedIndex;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Student_Grade WHERE 学号='" + studentId
                + "' AND 学年 Like '%" + yearComboBox1.Text
                + "%' AND 学期 LIKE '%" + sessonComboBox1.Text + "%'";
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
            gradeDataGridView.ContextMenuStrip = contextMenuStrip1;
            gradeRecountButton.Visible = true;
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

        private void gradeInputButton_Click(object sender, EventArgs e)
        {
            gradeDt = input(0);
            gradeDataGridView.DataSource = gradeDt;
            gradeOutputButton.Enabled = false;
            gradeDataGridView.ContextMenuStrip = null;
            string[] names = { "学号", "学年", "学期", "课程名称", "课程性质", "成绩", "期末成绩", "补考成绩", "学分" };
            ArrayList tags = new ArrayList();
            for (int i = 0; i < 9; i++)
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
                gradeInputGroupBox.Show();
            }
        }

        private void gradeOutputButton_Click(object sender, EventArgs e)
        {
            output(gradeDt, studentId + "+" + studentName + "+成绩单");
        }

        private void button4_Click(object sender, EventArgs e)
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
                if (n == 0)
                {
                    sql = "REPLACE INTO Evaluation_Grade(学号,学年,学期,智育成绩) VALUES ('" + dt.Rows[i]["学号"]
                    + "','" + dt.Rows[i]["学年"] + "','" + dt.Rows[i]["学期"] + "','" + regulerLessonGrade[i] + "')";
                    sqlList.Add(sql);
                }
            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
            gradeInputGroupBox.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gradeInputGroupBox.Visible = false;
            gradeDt.Clear();
        }

        private void gradeDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gradeInputGroupBox.Visible != true)
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
                if (n == 0)
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
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

        /******************************************************************/



        /******************************************************************/
        private DataTable activityDt = new DataTable();
        private DataTable evaluationDt = new DataTable();
        private int tag = 0;
        private void activitySearchButton_Click(object sender, EventArgs e)
        {
            string date = "";
            if(dateTimePicker1.Checked == true)
            {
                date = dateTimePicker1.Text;
            }
            string sql = "SELECT * FROM Student_Activity1 WHERE 学号 = '" + studentId
                + "' AND 学年 LIKE '%" + yearComboBox2.Text
                + "%' AND 学期 LIKE '%" + sessonComboBox2.Text
                + "%' AND 活动日期 LIKE '%" + date + "%'";
            activityDt = DbHelperSQLite.Query(sql).Tables[0];
            aeDataGridView.DataSource = activityDt;
            aeDataGridView.ContextMenuStrip = contextMenuStrip2;
            aeDataGridView.ReadOnly = true;
            tag = 0;
        }

        private void evaluationSearchButton_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Evaluation_Item WHERE 学号 = '" + studentId
                + "' AND 学年 LIKE '%" + yearComboBox2.Text
                + "%' AND 学期 LIKE '%" + sessonComboBox2.Text + "%'";
            evaluationDt = DbHelperSQLite.Query(sql).Tables[0];
            aeDataGridView.DataSource = evaluationDt;
            aeDataGridView.ContextMenuStrip = contextMenuStrip2;
            aeDataGridView.ReadOnly = false;
            tag = 1;
        }

        private void evaluationInputButton_Click(object sender, EventArgs e)
        {
            evaluationDt = input(0);
            aeDataGridView.DataSource = evaluationDt;
            eGroupBox.Visible = true;
            aeDataGridView.ContextMenuStrip = null;
        }

        private void inputOkButton1_Click(object sender, EventArgs e)
        {
            SQLiteInput(evaluationDt, "Evaluation_Item");
            eGroupBox.Visible = false;
        }

        private void inputCancelButton_Click(object sender, EventArgs e)
        {
            aeDataGridView.DataSource = null;
            eGroupBox.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(tag == 0)
            {
                output(activityDt, studentId + "+" + studentName + "+活动记录");
            }
            else
            {
                output(evaluationDt, studentId + "+" + studentName + "+综评记录");
            }
            
        }

        private void aeDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateButton.Visible = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SQLiteInput(evaluationDt, "Evaluation_Item");
            updateButton.Visible = false;
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(tag == 0)
            {
                sql = "DELETE FROM Activities_Student WHERE 学号='" + studentId
                    + "' AND 活动序列 = '" + activityDt.Rows[selectedIndex]["活动序列"] + "'";
            }
            else
            {
                sql = "DELETE FROM Evaluation_Item WHERE 记录序列 = '" + evaluationDt.Rows[selectedIndex]["记录序列"] + "'";
            }
            int n = DbHelperSQLite.ExecuteSql(sql);
            if(n == 1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }        

        private void aeDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1) return;
                aeDataGridView.ClearSelection();
                aeDataGridView.Rows[e.RowIndex].Selected = true;
                selectedIndex = e.RowIndex;
            }
        }        

        /*******************************************************************/



        /*******************************************************************/
        private DataTable evaluationGradeDt = new DataTable(); 
        private void evaluatingSearchButton_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Evaluation_Grade WHERE 学号='" + studentId
                + "' AND 学年 LIKE '%" + yearComboBox3.Text
                + "%' AND 学期 LIKE '%" + sessonComboBox3.Text + "%'";
            evaluationGradeDt = DbHelperSQLite.Query(sql).Tables[0];
            evaluationDataGridView.DataSource = evaluationGradeDt;
            evaluationOutputButton.Enabled = true;
        }

        private void evaluationOutputButton_Click(object sender, EventArgs e)
        {
            output(evaluationGradeDt, studentId + "+" + studentName + "+综评成绩");
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if(yearComboBox3.Text != null && yearComboBox3.Text != "" 
                && sessonComboBox3.Text != null && sessonComboBox3.Text != "")
            {
                Common.evaluationCalculate(studentId, yearComboBox3.Text, sessonComboBox3.Text);
                string sql = "SELECT * FROM Evaluation_Grade WHERE 学号='" + studentId
                + "' AND 学年 LIKE '%" + yearComboBox3.Text
                + "%' AND 学期 LIKE '%" + sessonComboBox3.Text + "%'";
                evaluationGradeDt = DbHelperSQLite.Query(sql).Tables[0];
                evaluationDataGridView.DataSource = evaluationGradeDt;
            }
            else
            {
                MessageBox.Show("请输入学年与学期", "提示");
            }
        }

        /*****************************************************************/




        /*****************************************************************/
        private DataTable dtCopy = Common.dt.Copy(); 
        private void updateButton1_Click(object sender, EventArgs e)
        {
            dt = dtCopy.Copy();
            Common.dt = dtCopy.Copy();
            dtCopy.Clear();
            DataRow dr = dt.Rows[index];
            dtCopy.ImportRow(dr);
            SQLiteInput(dtCopy, "Student_List");
            studentName = dtCopy.Rows[0]["姓名"].ToString();
            updateButton1.Visible = false;
        }
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["姓名"] = NameTextBox.Text;
            updateButton1.Visible = true;
        }

        private void oldNameTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["曾用名"] = oldNameTextBox.Text;
            updateButton1.Visible = true;
        }

        private void sexTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["性别"] = sexTextBox.Text;
            updateButton1.Visible = true;
        }

        private void nationTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["民族"] = nationTextBox.Text;
            updateButton1.Visible = true;
        }

        private void policTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["政治面貌"] = policTextBox.Text;
            updateButton1.Visible = true;
        }

        private void majorTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["专业"] = majorTextBox.Text;
            updateButton1.Visible = true;
        }

        private void classTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["行政班"] = classTextBox.Text;
            updateButton1.Visible = true;
        }

        private void birthTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["出生日期"] = birthTextBox.Text;
            updateButton1.Visible = true;
        }

        private void hometownTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["籍贯"] = hometownTextBox.Text;
            updateButton1.Visible = true;
        }

        private void idcardTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["身份证号"] = idcardTextBox.Text;
            updateButton1.Visible = true;
        }

        private void studyYearTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["学制"] = studyYearTextBox.Text;
            updateButton1.Visible = true;
        }

        private void gradeTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["当前所在级"] = gradeTextBox.Text;
            updateButton1.Visible = true;
        }

        private void inDateTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["入学日期"] = inDateTextBox.Text;
            updateButton1.Visible = true;
        }

        private void roomTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["宿舍号"] = roomTextBox.Text;
            updateButton1.Visible = true;
        }

        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["学历层次"] = levelTextBox.Text;
            updateButton1.Visible = true;
        }

        private void eLevelTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["英语等级"] = eLevelTextBox.Text;
            updateButton1.Visible = true;
        }

        private void eGradeTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["英语成绩"] = eGradeTextBox.Text;
            updateButton1.Visible = true;
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["手机号"] = phoneTextBox.Text;
            updateButton1.Visible = true;
        }

        private void qqTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["QQ号"] = qqTextBox.Text;
            updateButton1.Visible = true;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["电子邮箱"] = emailTextBox.Text;
            updateButton1.Visible = true;
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["家庭地址"] = addressTextBox.Text;
            updateButton1.Visible = true;
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["邮政编码"] = codeTextBox.Text;
            updateButton1.Visible = true;
        }

        private void mNameTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["母亲姓名"] = mNameTextBox.Text;
            updateButton1.Visible = true;
        }

        private void fNameTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["父亲姓名"] = fNameTextBox.Text;
            updateButton1.Visible = true;
        }

        private void mPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["母亲电话"] = mPhoneTextBox.Text;
            updateButton1.Visible = true;
        }

        private void fPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["父亲电话"] = fPhoneTextBox.Text;
            updateButton1.Visible = true;
        }

        private void mWorkTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["母亲单位"] = mWorkTextBox.Text;
            updateButton1.Visible = true;
        }

        private void fWorktextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["父亲单位"] = fWorktextBox.Text;
            updateButton1.Visible = true;
        }

        private void psTextBox_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["备注"] = psTextBox.Text;
            updateButton1.Visible = true;
        }

        private void pclevelText_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["计算机等级"] = pclevelText.Text;
            updateButton1.Visible = true;
        }

        private void pcgradeText_TextChanged(object sender, EventArgs e)
        {
            dtCopy.Rows[index]["计算机成绩"] = pcgradeText.Text;
            updateButton1.Visible = true;
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
        private void gradeDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(gradeDataGridView, (DataTable)gradeDataGridView.DataSource, e);
            }

        }

        private void aeDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(aeDataGridView, (DataTable)aeDataGridView.DataSource, e);
            }
        }

        private void evaluationDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortByClick(evaluationDataGridView, (DataTable)evaluationDataGridView.DataSource, e);
            }
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
    }
}
