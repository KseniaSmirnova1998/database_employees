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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee_info> Employees = new List<Employee_info>();

        public MainWindow()
        {
            InitializeComponent();
            Employees.Add(new Employee_info("Иван Иванов", "Менеджер", "Отдел кадров"));
            Employees.Add(new Employee_info("Анна Петрова", "Программист", "Отдел разработки"));

            Employee_info.ItemsSource = Employees;
            listView.ItemsSource = Employees;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
