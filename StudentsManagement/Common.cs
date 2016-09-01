using ExcelOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsManagement
{
    class Common
    {
        public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static DataTable dt = new DataTable();
        public static int index;
        public static string fileName;
        public static ArrayList columnNames = new ArrayList();
        public static void SQLiteInput(DataTable dt, string table)
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
        public static DataTable input(int tag)
        {
            DataTable dataTable = new DataTable();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = defaultPath;
            //Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "excel2007|*.xlsx|excel97-2003|*.xls";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                //defaultPath = fileName.Replace(System.IO.Path.GetFileName(studentInputDialog.FileName), "");//得到文件名
                //inputDataTable.Clear();
                dataTable = ExcelHelper.RenderDataTableFromExcel(fileName, 0, 0);
                columnNames.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnNames.Add(dt.Columns[i].ColumnName);
                }
            }
            return dataTable;
        }
        public static int evaluationCalculate(string studentId, string year, string sesson)
        {
            int tag = 0;
            double grade1 = 20;
            double grade2 = 0;
            double grade3 = 10;
            double grade4 = 0;
            double grade = 0;
            string sql = "SELECT 评测项目,分值 FROM Evaluation_Item WHERE 学号 = '" + studentId
                + "' AND 学年 = '" + year
                + "' AND 学期 = '" + sesson + "'";
            DataTable dt = DbHelperSQLite.Query(sql).Tables[0];
            string sql1 = "SELECT 智育成绩 FROM Evaluation_Grade WHERE 学号 = '" + studentId
                + "' AND 学年 = '" + year
                + "' AND 学期 = '" + sesson + "'";
            DataTable dt1 = DbHelperSQLite.Query(sql1).Tables[0];
            if (dt1.Rows.Count == 0)
            {
                MessageBox.Show("学号" + studentId + "的学生没有智育成绩,请录入智育成绩后再计算", "提示");
            }
            else
            {
                grade2 = Convert.ToDouble(dt1.Rows[0][0]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["评测项目"].ToString())
                    {
                        case "德育评测":
                        case "德育测评":
                            grade1 += Convert.ToDouble(dt.Rows[i]["分值"]);
                            if (grade1 > 100)
                            {
                                grade1 = 100;
                            }
                            else if (grade1 < 0)
                            {
                                grade1 = 0;
                            }
                            break;
                        case "能力评测":
                        case "能力测评":
                            grade3 += Convert.ToDouble(dt.Rows[i]["分值"]);
                            break;
                        case "个性发展评测":
                        case "个性发展测评":
                            grade4 += Convert.ToDouble(dt.Rows[i]["分值"]);
                            if (grade1 > 40)
                            {
                                grade1 = 40;
                            }
                            break;
                    }
                }
                grade = grade1 * 0.4 + grade2 * 0.4 + grade3 * 0.2 + grade4;
                string sql2 = "REPLACE INTO Evaluation_Grade(学号,学年,学期,德育成绩,智育成绩,能力成绩,个性发展成绩,总成绩) VALUES('" + studentId
                    + "','" + year + "','" + sesson + "', " + grade1.ToString() + "," + grade2.ToString()
                    + "," + grade3.ToString() + "," + grade4.ToString() + "," + grade.ToString() + ")";
                DbHelperSQLite.ExecuteSql(sql2);
                tag = 1;
            }
            return tag;           
        }
    }
}
