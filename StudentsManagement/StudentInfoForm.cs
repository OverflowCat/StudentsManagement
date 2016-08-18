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
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }
        private string studentId = Common.dt.Rows[Common.index]["学号"].ToString();
        private DataTable dt = Common.dt;
        private int index = Common.index;
        private void StudentInfoForm_Load(object sender, EventArgs e)
        {
           textBox1.Text = studentId;
           textBox2.Text = dt.Rows[index]["姓名"].ToString();
           textBox3.Text = dt.Rows[index]["性别"].ToString();
           textBox4.Text = dt.Rows[index]["民族"].ToString();
           textBox5.Text = dt.Rows[index]["政治面貌"].ToString();
           textBox6.Text = dt.Rows[index]["专业"].ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
