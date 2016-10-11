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
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
        }
        private string[] lessons = { "公共基础课", "公共选修课", "专业必修课", "专业选修课", "综合教育必修课", "实践课", "体育项目课" };
        private void SetupForm_Load(object sender, EventArgs e)
        {
            Double[] percent = Common.percent;
            int[] percent1 = Common.percent1;
            textBox1.Text = percent[0].ToString();
            textBox2.Text = percent[1].ToString();
            textBox3.Text = percent[2].ToString();
            if(percent[4] == 0)
            {
                radioButton2.Select();
                textBox5.Text = percent[5].ToString();
            }
            else
            {
                radioButton1.Select();
                textBox4.Text = percent[3].ToString();
                textBox5.Text = percent[5].ToString();
            }
            if (percent1[0] == 0)
            {
                radioButton3.Checked = true;
                for(int i = 1; i < 8; i++)
                {
                    if(percent1[i] == -1)
                    {
                        checkedListBox1.SetItemChecked(i - 1, true);
                    }
                }
            }
            else
            {
                radioButton4.Checked = true;
                TextBox[] gradeTextBox = { textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 };
                int i = 1;
                foreach (TextBox textBox in gradeTextBox)
                {
                    if(percent1[i] != -1)
                    {
                        textBox.Text = percent1[i++].ToString();
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i-1,true);
                        i++;
                    }
                }
            }
            if(percent1[8] == 1)
            {
                checkBox1.Checked = true;
            }       
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Evaluation_Percent SET 德育比例=" + textBox1.Text
                + ", 智育比例 = " + textBox2.Text + ", 个人能力比例=" + textBox3.Text;
            if(radioButton1.Checked == true)
            {
                if(textBox4.Text == "" || textBox4.Text == null)
                {
                    MessageBox.Show("请输入个性发展成绩占比", "提示");
                }
                else
                {
                    int total = Convert.ToInt16(textBox1.Text) + Convert.ToInt16(textBox2.Text) + Convert.ToInt16(textBox3.Text) + Convert.ToInt16(textBox4.Text);
                    if (total == 100)
                    {
                        sql = sql + ",个性发展比例=" + textBox4.Text + ",个性发展标志=1" +
                                        ",个性发展分值 = " + textBox5.Text;
                        int tag = DbHelperSQLite.ExecuteSql(sql);
                        if (tag == 1)
                        {
                            MessageBox.Show("综评成绩计算参数更新成功");
                        }
                        else
                        {
                            MessageBox.Show("综评成绩计算参数更新失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("比例总和不等于100", "错误");
                    }
                }     
            }
            else
            {
                if (textBox5.Text != "" && textBox5.Text != null)
                {
                    int total = Convert.ToInt16(textBox1.Text) + Convert.ToInt16(textBox2.Text) + Convert.ToInt16(textBox3.Text);
                    if (total == 100)
                    {
                        sql = sql + ",个性发展标志=0" + ",个性发展分值 = " + textBox5.Text;
                        int tag = DbHelperSQLite.ExecuteSql(sql);
                        if (tag == 1)
                        {
                            MessageBox.Show("综评成绩计算参数更新成功");
                        }
                        else
                        {
                            MessageBox.Show("综评成绩计算参数更新失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("比例总和不等于100", "错误");
                    }
                }
                else
                {
                    MessageBox.Show("请输入个性发展最高分值", "提示");
                }
            }
            update1();
            Common.percent = GetPercent();
            Common.percent1 = GetPercent1();
            Reload();
        }
        private void Reload()
        {
            Double[] percent = Common.percent;
            int[] percent1 = Common.percent1;
            textBox1.Text = percent[0].ToString();
            textBox2.Text = percent[1].ToString();
            textBox3.Text = percent[2].ToString();
            if (percent[4] == 0)
            {
                radioButton2.Select();
                textBox5.Text = percent[5].ToString();
            }
            else
            {
                radioButton1.Select();
                textBox4.Text = percent[3].ToString();
                textBox5.Text = percent[5].ToString();
            }
            if (percent1[0] == 0)
            {
                radioButton3.Checked = true;
                for (int i = 1; i < 8; i++)
                {
                    if (percent1[i] == -1)
                    {
                        checkedListBox1.SetItemChecked(i - 1, true);
                    }
                }
            }
            else
            {
                radioButton4.Checked = true;
                TextBox[] gradeTextBox = { textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 };
                int i = 1;
                foreach (TextBox textBox in gradeTextBox)
                {
                    if (percent1[i] != -1)
                    {
                        textBox.Text = percent1[i++].ToString();
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i - 1, true);
                        i++;
                    }
                }
                if(percent1[8] == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }
        private Double[] GetPercent()
        {
            string sql = "SELECT * FROM Evaluation_Percent";
            DataTable percent = DbHelperSQLite.Query(sql).Tables[0];
            Double[] percents = { Convert.ToDouble(percent.Rows[0]["德育比例"]),
                Convert.ToDouble(percent.Rows[0]["智育比例"]),
                Convert.ToDouble(percent.Rows[0]["个人能力比例"]),
                Convert.ToDouble(percent.Rows[0]["个性发展比例"]),
                Convert.ToDouble(percent.Rows[0]["个性发展标志"]),
            Convert.ToDouble(percent.Rows[0]["个性发展分值"])};
            return percents;
        }
        private int[] GetPercent1()
        {
            string sql = "SELECT * FROM Grade_Percent";
            DataTable percent = DbHelperSQLite.Query(sql).Tables[0];
            int[] percents = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < percent.Columns.Count; i++)
            {
                percents[i] = Convert.ToInt16(percent.Rows[0][i]);
            }
            return percents;
        }
        private void update1()
        {
            string sql1 = "UPDATE Grade_Percent SET ";
            if (radioButton3.Checked == true)
            {
                sql1 = sql1 + "成绩计算模式 = 0";
                for (int i = 0; i < 7; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        sql1 = sql1 + "," + lessons[i] + " = -1";
                    }
                    else
                    {
                        sql1 = sql1 + "," + lessons[i] + " = 0";
                    }
                }
                DbHelperSQLite.ExecuteSql(sql1);
            }
            else
            {
                double total = 0;
                sql1 = sql1 + "成绩计算模式 = 1";
                TextBox[] gradeTextBox = { textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 };
                for(int i = 0; i < gradeTextBox.Count(); i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        sql1 = sql1 + "," + lessons[i] + " = -1";
                    }
                    else
                    {
                        total += Convert.ToDouble(gradeTextBox[i].Text);
                        sql1 = sql1 + "," + lessons[i] + " = " + gradeTextBox[i].Text;
                    }
                }
                if(checkBox1.Checked == true)
                {
                    sql1 = sql1 + ",缺少类别参与计算=1";
                }
                else
                {
                    sql1 = sql1 + ",缺少类别参与计算=0";
                }
                if (total == 100)
                {
                    int n = DbHelperSQLite.ExecuteSql(sql1);
                    if(n == 1)
                    {
                        MessageBox.Show("智育成绩计算参数更新成功");
                    }
                    else
                    {
                        MessageBox.Show("智育成绩计算参数更新失败");
                    }
                }
                else
                {
                    MessageBox.Show("比例总和错误，请修改", "提示");
                }
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
