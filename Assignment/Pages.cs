using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
     static class Pages
    {
        private static Log_inPage _log_inPage = new Log_inPage();
        private static MainPage _mainPage = new MainPage();
        private static Employee_add _employee_add = new Employee_add();

        public static Log_inPage Log_inPage
        {
            get { return _log_inPage; }
        }

        public static MainPage MainPage
        {
            get { return _mainPage; }
        }

        public static Employee_add Employee_add
        {
            get { return _employee_add; }
        }
    }
}
