using System;
using System.Collections.Generic;
namespace Assignment
{
    public class Employee_monthly
    {
        private string _name; // имя сотрудника

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _position; // должность

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private string _department; // отдел

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
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

        // private string _workday; // средняя длина рабочего дня (за месяц)

        // public string Workday
       //  {
           //  get { return _workday; }
           //  set { _workday = value; }
       //  }

        private int _missed; // среднее количество пропущенных дней (за месяц)

        public int Missed
        {
            get { return _missed; }
            set { _missed = value; }
        }

        public static List<Employee_monthly> ItemsSource { get; internal set; }
        public Employee_monthly(string name, string position, string department, string arrival, string leaving, int missed)
        {
            _name = name;
            _department = department;
            _position = position;
            _arrival = arrival;
            _leaving = leaving;
            // _workday = workday;
            _missed = missed;

        } 
    }
    
}
