using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement
{
    class Common
    {
        public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static DataTable dt = new DataTable();
        public static int index;
    }
}
