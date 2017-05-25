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
        private static EditPage _editPage = new EditPage();
        private static Employee_addPage _employee_addPage = new Employee_addPage();
        private static View_OnlyPage _view_OnlyPage = new View_OnlyPage();
       

        public static Log_inPage Log_inPage
        {
            get { return _log_inPage; }
        }

        public static MainPage MainPage
        {
            get { return _mainPage; }
        }
        public static EditPage EditPage
        {
            get { return _editPage; }
        }

        public static Employee_addPage Employee_addPage
        {
            get { return _employee_addPage; }
        }

        public static View_OnlyPage View_OnlyPage
        {
            get { return _view_OnlyPage; }
        }

        
    }
}
