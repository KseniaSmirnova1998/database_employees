using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Логика взаимодействия для Employee_add.xaml
    /// </summary>
    public partial class Employee_add : Window
    {
        
        public Employee_add()
        {
            InitializeComponent();
        }

        Employee_monthly _newEmployee_monthly;
        

        public Employee_monthly NewEmployee_monthly
        {
            get { return _newEmployee_monthly;  }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            int missed;

            
            
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("Введите имя и фамилию сотрудника.");
                textBox_name.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(textBox_position.Text))
            {
                MessageBox.Show("Введите должность сотрудника.");
                textBox_position.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(comboBox_department.Text))
            {
                MessageBox.Show("Укажите отдел, где работает сотрудник");
                textBox_missed.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(textBox_arrival.Text))
            {
                MessageBox.Show("Введите среднее время прибытия сотрудника.");
                textBox_arrival.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(textBox_leaving.Text))
            {
                MessageBox.Show("Введите среднее время ухода сотрудника.");
                textBox_leaving.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(textBox_missed.Text))
            {
                MessageBox.Show("Введите количество пропущенных сотрудником рабочих дней.");
                textBox_missed.Focus();
                return;
            }

            if (!int.TryParse(textBox_missed.Text, out missed))
            {
                MessageBox.Show("Некорректное значение! Введите целое число от 0 до 31.");
                textBox_missed.Focus();
                return;
            }

            if (missed < 0 || missed > 31)
            {
                MessageBox.Show("Некорректное значение! Введите целое число от 0 до 31.");
                textBox_missed.Focus();
                return;
            }

            _newEmployee_monthly = new Employee_monthly(textBox_name.Text, textBox_position.Text, comboBox_department.Text, textBox_arrival.Text, textBox_leaving.Text, missed);
            
            DialogResult = true;
        }

        private void comboBox_department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_department.Text))
            {
                MessageBox.Show("Укажите отдел, в котором работает сотрудник.");
                return;
            }
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
 