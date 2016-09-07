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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static Boolean tag = true;

        private void button1_Click(object sender, EventArgs e)
        {
            string mAccount = accountTextBox.Text;
            string mPassword = passwordTextBox.Text;
            if (mAccount == "" || mAccount == null || mPassword == "" || mPassword == null)
            {
                messageLabel.Text = "请输入账号和密码";
            }
            else
            {
                string sql = "SELECT * FROM Account_List WHERE 账号='" + mAccount + "'";
                DataTable dt = DbHelperSQLite.Query(sql).Tables[0];
                if(dt.Rows.Count == 0)
                {
                    messageLabel.Text = "账号不存在";
                }
                else
                {
                    if(mPassword == dt.Rows[0]["密码"].ToString())
                    {
                        StudentManagement sm = new StudentManagement();
                        sm.Show();
                        tag = false;
                        this.Close();
                    }
                    else
                    {
                        messageLabel.Text = "密码错误";
                    }
                }
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {

        }
    }
}
