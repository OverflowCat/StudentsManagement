using ExcelOperate;
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
            birthTextBox.Text = dt.Rows[index]["出生日期"].ToString().Substring(0, 10);
            idcardTextBox.Text = dt.Rows[index]["身份证号"].ToString();
            classTextBox.Text = dt.Rows[index]["行政班"].ToString();
            studyYearTextBox.Text = dt.Rows[index]["学制"].ToString();
            gradeTextBox.Text = dt.Rows[index]["当前所在级"].ToString();
            inDateTextBox.Text = dt.Rows[index]["入学日期"].ToString().Substring(0, 10);
            roomTextBox.Text = dt.Rows[index]["宿舍号"].ToString();
            levelTextBox.Text = dt.Rows[index]["学历层次"].ToString();
            eLevelTextBox.Text = dt.Rows[index]["英语等级"].ToString();
            eGradeTextBox.Text = dt.Rows[index]["英语成绩"].ToString();
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private DataTable comban(DataTable dt, string[] columnNames)
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
        string[] names = { "课程名称", "课程性质", "期末成绩", "成绩", "补考成绩" };
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < ((string[])lessonNames[i]).Count(); j++)
                {
                    dt.Rows[i]["课程名称"] = ((string[])lessonNames[i])[j];
                    dt.Rows[i]["课程性质"] = ((string[])lessonProperties[i])[j];
                    dt.Rows[i]["期末成绩"] = ((string[])finalGrades[i])[j];
                    dt.Rows[i]["成绩"] = ((string[])grades[i])[j];
                    dt.Rows[i]["补考成绩"] = ((string[])secondGrades[i])[j];
                    gradeDt.ImportRow(dt.Rows[i]);
                }
            }
            gradeDataGridView.DataSource = gradeDt;
            gradeOutputButton.Enabled = true;
            gradeDataGridView.ContextMenuStrip = contextMenuStrip1;
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
    }
}
