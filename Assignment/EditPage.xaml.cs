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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {

        List<Employee_monthly> Employees;
        public Employee_monthly EmployeeEdit;
        const string FileEmployees = "employees.txt";
        public EditPage()
        {
            InitializeComponent();
        }

        private void grid_load(object sender, RoutedEventArgs e)
        {
            Pages.EditPage.textBox_arrival.Text = EmployeeEdit.Arrival;
            Pages.EditPage.textBox_name.Text = EmployeeEdit.Name;
            Pages.EditPage.textBox_leaving.Text = EmployeeEdit.Leaving;
            Pages.EditPage.textBox_missed.Text = EmployeeEdit.Missed.ToString();
            Pages.EditPage.textBox_position.Text = EmployeeEdit.Position;
            Pages.EditPage.comboBox_department.Text = EmployeeEdit.Department;

        }


        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Изменения не будут сохранены.", "Вы уверены, что хотите покинуть страницу?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(Pages.MainPage);
            }
            
        }

        

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            Load();
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

            Employee_monthly EmployeeEdited = new Employee_monthly(textBox_name.Text, textBox_position.Text, comboBox_department.Text, textBox_arrival.Text, textBox_leaving.Text, missed);
            Employee_monthly tempEmployee = null;
            foreach (var item in Employees)
            {
                if ((item.Name == EmployeeEdit.Name) && (item.Position == EmployeeEdit.Position) && (item.Department == EmployeeEdit.Department) && (item.Arrival == EmployeeEdit.Arrival) && (item.Leaving == EmployeeEdit.Leaving) && (item.Missed == EmployeeEdit.Missed))
                    tempEmployee = item;
            }
            if (tempEmployee != null)
            {
                Employees.Remove(tempEmployee);
            }
            Employees.Add(EmployeeEdited);
            Save();
            NavigationService.Navigate(Pages.MainPage);
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
    }
}
