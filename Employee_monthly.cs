using System;
namespace Assignment
{
    public class Employee_monthly : Employee_info
    {
        private string _arrival; // время прихода на работу (среднее за месяц)

        public string Arrival
        {
            get { return _arrival; }
            set { _arrival = value; }
        }

        private string _leaving; // время ухода с работы (среднее за месяц)

        public string Leaving
        {
            get { return _leaving; }
            set { _leaving = value; }
        }

        private string _workday; // средняя длина рабочего дня (за месяц)

        public string Workday
        {
            get { return _workday; }
            set { _workday = value; }
        }

        private string _missed; // среднее количество пропущенных дней (за месяц)

        public string Missed
        {
            get { return _missed; }
            set { _missed = value; }
        }
        public Employee_monthly(string name, string position, string department, )
        {
            _name = name;
            _position = position;
            _department = department;
        }
    }
    
}
