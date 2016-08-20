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
    public partial class StudentManagement : Form
    {
        private string mStudentName;
        private string mStudentId;
        private string mStudentMajor;
        private string mStudentClass;
        private string mStudentSex;
        private string mStudentPoliticalStatus;
        private string mStudentNationality;
        private string[] majors = { "信息与计算科学", "数学与应用数学", "应用物理" };
        private string[] mClassNums;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable inputDataTable = new DataTable();
        private ArrayList columnsNames = new ArrayList();
        private ArrayList locations = new ArrayList();
        private string defaultPath = Common.defaultPath;
        private int selectedIndex;
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
            }
            else if (treeView1.SelectedNode.Text == "成绩")
            {
                gradePanel.BringToFront();
                this.AcceptButton = searchButton1;
            }
        }
        private string getSql(string mStudentId, string mStudentName, string mStudentMajor, string mStudentClass, string mStudentSex, string mStudentNationality, string mStudentPoliticalStatus)
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
                            + "AND 民族 LIKE '%" + mStudentNationality + "%'"
                            + "AND 性别 LIKE '%" + mStudentSex + "%' AND 政治面貌 LIKE '%" + mStudentPoliticalStatus + "%'";
                    }
                }
                else
                {
                    sql = "SELECT * FROM Student_List WHERE 姓名 LIKE '%" + mStudentName + "%'"
                            + "AND 民族 LIKE '%" + mStudentNationality + "%'"
                            + "AND 性别 LIKE '%" + mStudentSex + "%' "
                            + "AND 政治面貌 LIKE '%" + mStudentPoliticalStatus + "%'";
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
            string s = mStudentId + mStudentName + mStudentMajor + mStudentClass + mStudentSex + mStudentNationality + mStudentPoliticalStatus;
            if (s == "")
            {
                MessageBox.Show("请输入搜索条件");
            }
            else
            {
                string sql = getSql(mStudentId, mStudentName, mStudentMajor, mStudentClass, mStudentSex, mStudentNationality, mStudentPoliticalStatus);
                ds = DbHelperSQLite.Query(sql);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnsNames.Add(dt.Columns[i].ColumnName);
                }
                StudentListGridView.DataSource = dt;
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

        private void majorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mStudentMajor = majors[majorBox.SelectedIndex];
            mStudentMajor = majorBox.SelectedItem.ToString();
            string sql = "SELECT class_num FROM Class_List WHERE class_major = '" + mStudentMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);           
            int n = ds.Tables[0].Rows.Count;
            classBox.Items.Clear();
            if (n != 0)
            {
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
                string sql1 = "REPLACE INTO Student_List(" + columnsNames[0].ToString();              
                string sql2 = ") Values('" + inputDataTable.Rows[i][columnsNames[0].ToString()];
                for (int j = 1; j < inputDataTable.Columns.Count; j++)
                {
                    sql1 = sql1 + "," + columnsNames[j].ToString();
                    sql2 = sql2 + "','" + inputDataTable.Rows[i][columnsNames[j].ToString()];
                }
                string sql = sql1 + sql2 + "')";
                SQLStringList.Add(sql);
            }
            DbHelperSQLite.ExecuteSqlTran(SQLStringList);
            MessageBox.Show("共导入" + inputDataTable.Rows.Count + "条学生信息");
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
                        }
                        else
                        {
                            location.Add(i);
                            location.Add(j);
                            locations.Add(location);
                        }
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
            Common.dt = dt;
            Common.index = e.ColumnIndex;
            StudentInfoForm studentInfoForm = new StudentInfoForm();
            studentInfoForm.Show();
        }
        /**************************************************************************************/




        /**************************************************************************************/
        private string idText;
        private string majorText;
        private string classText;
        private string yearText;
        private string sessonText;        
        private DataTable gradeDt = new DataTable();
        private ArrayList gradeColumnNames = new ArrayList();
        string[] names = { "课程名称", "课程性质", "期末成绩", "成绩", "补考成绩" };
        private string getSql(string idText, string majorText, string classText, string yearText, string sessonText)
        {
            string sql = idText + majorText + yearText + sessonText;
            if(sql == "" && sql == null)
            {
                MessageBox.Show("请输入查询条件");
            }
            else
            {
                if (idText != "" && idText != null)
                {
                    sql = "学号='" + idText + "'";
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
            string sql = "SELECT * FROM Student_Grade WHERE " + getSql(idText, majorText, classText, yearText, sessonText);           
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
        private DataTable comban(DataTable dt, string[] columnNames)
        {
            int index = 0;
            string tag = dt.Rows[0]["学号"].ToString() + dt.Rows[0]["学年"].ToString() + dt.Rows[0]["学期"].ToString();
            
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
                    dt.Rows[i].Delete();
                    i = i - 1;
                }
                else
                {
                    tag = tag1;
                    index = i;
                }
            }
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
            string sql = "SELECT class_num FROM Class_List WHERE class_major = '" + mGradeMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);
            int n = ds.Tables[0].Rows.Count;
            classComboBox2.Items.Clear();
            if (n != 0)
            {
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
            gradeDataGridView.DataSource = gradeDt;
            okGroupBox2.Visible = true;
        }

        private void gradeOutputButton_Click(object sender, EventArgs e)
        {
            output(gradeDt, "学生成绩单");
        }

        private void insertOKButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = comban(gradeDt, names);
            SQLiteInput(dt, "Grade_List");
            okGroupBox2.Visible = false;
        }

        private void insertCancelButton1_Click(object sender, EventArgs e)
        {
            okGroupBox2.Visible = false;
            gradeDt.Clear();
        }
    }
}
