using ExcelOperate;
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
    public partial class ActivityInputForm : Form
    {
        public ActivityInputForm()
        {
            InitializeComponent();
        }
        private DataTable dt = new DataTable();
        private string[] names = { "活动名称", "学年", "学期", "活动日期", "活动加分", "备注"};
        private string[] text = { "", "", "", "", "", "" };
        private void button1_Click(object sender, EventArgs e)
        {
            dt = Common.input(0);
            activityInputTextBox1.Text = Common.fileName;
        }

        private void activityAddButton2_Click(object sender, EventArgs e)
        {
            if(dt.Rows.Count != 0)
            {
                Common.SQLiteInput(dt, "Activities_List");
            }
            else
            {
                int tag = 0;                
                for (int i = 1; i < 5; i++)
                {
                    if (text[i-1] == "")
                    {
                        tag = i;
                        break;
                    }
                }
                if(tag == 0)
                {
                    string sql1 = "REPLACE INTO Activities_List(" + names[0];
                    string sql2 = "VALUES ('" + text[0];
                    for (int i = 0; i<6; i++)
                    {
                        if (i != 0)
                        {
                            sql1 = sql1 + "," + names[i];
                            sql2 = sql2 + "','" + text[i];
                        }
                    }
                    string sql = sql1 + ") " + sql2 + "')";
                    DbHelperSQLite.ExecuteSql(sql);
                    DialogResult d = MessageBox.Show("是否添加参与活动名单", "提示", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        DataTable studentList = Common.input(0);
                        string activitySql = "SELECT 活动序列 FROM Activities_List WHERE 活动名称='" + text[0] + "'AND 学年 = '"
                            + text[1] + "' AND 学期 = '" + text[2] + "' AND 日期 = '" + text[3] + "'";
                        DataSet ds = DbHelperSQLite.Query(activitySql);
                        studentList.Columns.Add(ds.Tables[0].Columns[0]);
                        for(int i = 0; i < studentList.Rows.Count; i++)
                        {
                            studentList.Rows[i]["活动序列"] = ds.Tables[0].Rows[0][0];
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("缺少必要信息：" + names[tag - 1], "错误");                    
                }            
            }
        }

        private void activityInputTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (activityInputTextBox1.Text != Common.fileName)
            {
                dt = ExcelHelper.RenderDataTableFromExcel(activityInputTextBox1.Text, 0, 0);
            }
        }

        private void activityNameTextBox2_TextChanged(object sender, EventArgs e)
        {
            text[0] = activityNameTextBox2.Text;
        }

        private void activityYearComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            text[1] = activityYearComboBox1.Text;
        }

        private void activitySessionComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            text[2] = activitySessionComboBox2.Text;
        }

        private void activityDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            text[3] = activityDateTimePicker1.Text;
        }

        private void activityValuesTextBox3_TextChanged(object sender, EventArgs e)
        {
            text[4] = activityValuesTextBox3.Text;
        }

        private void activityPsTextBox1_TextChanged(object sender, EventArgs e)
        {
            text[5] = activityPsTextBox1.Text;
        }

        private void activityCancelButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
