using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Логика взаимодействия для Employee_addPage.xaml
    /// </summary>
    public partial class Employee_addPage : Page
        
    {
        public List<Employee_monthly> Employees;
        const string FileEmployees = "employees.txt";
        public Employee_addPage()
        {
            InitializeComponent();
            Load();

            Employee_monthly.ItemsSource = Employees;
        }
        
        Employee_monthly _newEmployee_monthly;


        public Employee_monthly NewEmployee_monthly
        {
            get { return _newEmployee_monthly; }
        }
        private void Save()
        {
            using (var sw = new StreamWriter(FileEmployees))
            {
                foreach (var empl in Employees)
                {
                    sw.WriteLine($"{empl.Name}:{empl.Position}:{empl.Department}:{empl.Arrival}:{empl.Leaving}:{empl.Missed}");
                }
            }
        }

        private void Load()
        {
            try
            {
                Employees = new List<Employee_monthly>();


                using (var sr = new StreamReader(FileEmployees))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(':');
                        if (parts.Length == 6)
                        {
                            var employee = new Employee_monthly(parts[0], parts[1], parts[2], parts[3], parts[4], int.Parse(parts[5]));
                            Employees.Add(employee);
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            Pages.MainPage.listView_Employees.Items.Refresh();
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

            if (comboBox_department.SelectedItem == null)
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
            Employees.Add(_newEmployee_monthly);
            //Save();
            Pages.Employee_addPage.textBox_arrival.Text = "";
            Pages.Employee_addPage.textBox_name.Text = "";
            Pages.Employee_addPage.textBox_missed.Text = "";
            Pages.Employee_addPage.textBox_leaving.Text = "";
            Pages.Employee_addPage.textBox_position.Text = "";
            Pages.Employee_addPage.comboBox_department.SelectedItem = null;

            Save();
             Pages.MainPage.listView_Employees.Items.Refresh();
            NavigationService.Navigate(Pages.MainPage);
            
            
            

        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MainPage);
        }
    }
}
