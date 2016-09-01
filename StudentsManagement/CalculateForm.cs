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
    public partial class CalculateForm : Form
    {
        private string[] mClassNums;
        private int tag = 0;
        private DataTable studentDt = new DataTable();
        private DataTable studentDt1 = new DataTable();

        public CalculateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if(yearComboBox.Text != null && yearComboBox.Text != "" 
                && sessonComboBox.Text != null && sessonComboBox.Text != "")
            {
                string sql = getSql(gradeComboBox.Text, majorComboBox.Text, classComboBox.Text);
                if (sql != "")
                {
                    studentDt = DbHelperSQLite.Query(sql).Tables[0];
                    studentDt1 = studentDt.Copy();
                    calculate(studentDt1, tag);
                    if (checkBox1.Checked == true)
                    {
                        sort(studentDt1, tag);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择学年与学期", "提示");
            }
        }

        private string getSql( string mGrade, string mMajor, string mClass)
        {
            string sql = "SELECT 学号,专业,行政班 FROM Student_List WHERE";
            if(mGrade != null && mGrade != "")
            {
                if(mMajor != null && mMajor != "")
                {
                    if(mClass != null && mClass != "")
                    {
                        sql = sql + " 专业= '" + mMajor + "' AND 行政班='" + mClass + "'";
                        tag = 1;
                    }
                    else
                    {
                        sql = sql + " 专业= '" + mMajor + "'";
                        tag = 2;
                    }
                }
                else
                {
                    sql = sql + " 当前所在级='" + mGrade + "'";
                    tag = 3;
                }
            }
            else
            {
                if (mMajor != null && mMajor != "")
                {
                    if (mClass != null && mClass != "")
                    {
                        sql = sql + " 专业= '" + mMajor + "' AND 行政班='" + mClass + "'";
                        tag = 1;
                    }
                    else
                    {
                        sql = sql + " 专业= '" + mMajor + "'";
                        tag = 2;
                    }
                }
                else
                {
                    DialogResult d = MessageBox.Show("是否进行全系学生成绩计算？", "提示", MessageBoxButtons.YesNo);
                    if(d.ToString() == "Yes")
                    {
                        sql = "SELECT 学号,专业,行政班 FROM Student_List ";
                        tag = 4;
                    }
                    else
                    {
                        sql = "";
                    }
                }
            }
            return sql;
        }

        private void calculate(DataTable dt, int tag)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = dt.Rows.Count;
            num1.Text = dt.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tag1 = Common.evaluationCalculate(dt.Rows[i]["学号"].ToString(), yearComboBox.Text, sessonComboBox.Text);
                progressBar1.Value += 1;
                if(tag1 == 1)
                {
                    num2.Text = progressBar1.Value.ToString();
                    string info = "\\ " + DateTime.Now.ToLongTimeString() + " \\ 学生 " + dt.Rows[i]["学号"] + " 的综评成绩计算完成";
                    output(textBox1, info);
                }
                else
                {
                    num2.Text = progressBar1.Value.ToString();
                    string info = "\\ " + DateTime.Now.ToLongTimeString() + " \\ 学生 " + dt.Rows[i]["学号"] + " 的综评成绩计算失败，缺少智育成绩";
                    output(textBox1, info);
                    studentDt1.Rows[i].Delete();                    
                }
                
            }
            studentDt1.AcceptChanges();
        }

        private void output(TextBox textBox, string info)
        {
            textBox.AppendText(info);
            textBox.AppendText(Environment.NewLine);
            textBox.ScrollToCaret();
        }

        private void sort(DataTable dt, int tag)
        {
            string sortName = "";
            switch(tag)
            {
                case 1:
                    sortName = "班级排名";
                    break;
                case 2:
                    sortName = "专业排名";
                    break;
                case 3:
                case 4:
                    sortName = "院系排名";
                    break;
            }
            string sql = "SELECT 学号,总成绩," + sortName + " FROM Evaluation_Grade WHERE 学号 in ( '" + dt.Rows[0]["学号"] + "'";
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                sql = sql + ",'" + dt.Rows[i]["学号"] + "'";
            }
            sql = sql + ") AND 学年 = '" + yearComboBox.Text + "' AND 学期='" + sessonComboBox.Text + "'";
            DataTable grade = DbHelperSQLite.Query(sql).Tables[0];
            grade.DefaultView.Sort = "总成绩 DESC";
            ArrayList sqlList = new ArrayList();
            for(int i = 0; i < grade.Rows.Count; i++)
            {
                grade.Rows[i][sortName] = i + 1;
                string sql1 = "UPDATE Evaluation_Grade SET " + sortName + "='" + grade.Rows[i][sortName].ToString()
                    + "' WHERE 学号='" + grade.Rows[i]["学号"] + "' AND 学年 = '" + yearComboBox.Text
                    + "' AND 学期 ='" + sessonComboBox.Text + "'";
                sqlList.Add(sql1);
            }
            DbHelperSQLite.ExecuteSqlTran(sqlList);
            string info = "\\ " + DateTime.Now.ToLongTimeString() + "\\" + "已完成" + sortName + "计算";
            output(textBox1, info);
        }
        private void majorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentMajor = majorComboBox.SelectedItem.ToString();
            string sql = "SELECT DISTINCT 行政班 FROM Student_List WHERE 专业 = '" + studentMajor + "'";
            DataSet ds = DbHelperSQLite.Query(sql);
            int n = ds.Tables[0].Rows.Count;
            classComboBox.Items.Clear();
            if (n != 0)
            {
                mClassNums = new string[n];
                for (int i = 0; i < n; i++)
                {
                    mClassNums[i] = ds.Tables[0].Rows[i][0].ToString().Trim();
                }
                classComboBox.Items.AddRange(mClassNums);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
