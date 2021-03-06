﻿using System;
namespace Assignment
{
    internal class Employee_info
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

        public Employee_info (string name, string position, string department)
        {
            _name = name;
            _position = position;
            _department = department;
        }
    }
}
