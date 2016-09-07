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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void passwordConfirmTextBox_TextChanged(object sender, EventArgs e)
        {
            if(passwordConfirmTextBox.Text == passwordTextBox.Text)
            {
                pictureBox1.Visible = true;
                signUpButton.Enabled = true;
            }
            else
            {
                pictureBox1.Visible = false;
                signUpButton.Enabled = false;
            }            
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Account_List(账号,密码,权限) VALUES('" + accountTextBox.Text + "','" 
                + passwordTextBox.Text + "'," + 0 + ")";
            
        }

        private void accountTextBox_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Account_List WHERE 账号='" + accountTextBox.Text + "'";
            DataTable dt1 = DbHelperSQLite.Query(sql1).Tables[0];
            if (dt1.Rows.Count == 1)
            {
                messageLabel.Text = "该账号已存在";
                signUpButton.Enabled = false;
            }
        }
    }
}
