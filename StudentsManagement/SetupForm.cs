using System;
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
         
        private void SetupForm_Load(object sender, EventArgs e)
        {
            Double[] percent = Common.percent;
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
                            MessageBox.Show("更新成功");
                        }
                        else
                        {
                            MessageBox.Show("更新失败");
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
                            MessageBox.Show("更新成功");
                        }
                        else
                        {
                            MessageBox.Show("更新失败");
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
