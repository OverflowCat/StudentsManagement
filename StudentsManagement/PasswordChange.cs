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
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void confirmTextBox_TextChanged(object sender, EventArgs e)
        {
            if(confirmTextBox.Text == newTextBox.Text)
            {
                pictureBox1.Visible = true;
                button1.Enabled = true;
            }
            else
            {
                pictureBox1.Visible = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Account_List WHERE 账号=" + idTextBox.Text;
            DataTable dt = DbHelperSQLite.Query(sql).Tables[0];
            if(dt.Rows[0]["密码"].ToString() == oldTextBox.Text)
            {
                string sql1 = "UPDATE Account_List SET 密码 = " + newTextBox.Text + " WHERE 账号 = " + idTextBox.Text;
                int i = DbHelperSQLite.ExecuteSql(sql1);
                if(i == 1)
                {
                    MessageBox.Show("密码修改成功", "提示");
                }
            }
            else
            {
                MessageBox.Show("原密码错误", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
