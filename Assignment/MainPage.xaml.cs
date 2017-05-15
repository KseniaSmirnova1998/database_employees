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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Employee_monthly> Employees = new List<Employee_monthly>();
        public MainPage()
        {
            
            InitializeComponent();
            

            Employees.Add(new Employee_monthly("Иван Иванов", "Менеджер", "Отдел кадров", "8.30", "18.46", 0));
            Employees.Add(new Employee_monthly("Анна Петрова", "Программист", "Отдел разработки", "8.30", "18.46", 0));

            Employee_monthly.ItemsSource = Employees;
            listView_Employees.ItemsSource = Employees;
        }

        public List<Employee_monthly> FindEmployees(string input)
        {
            List<Employee_monthly> temp = new List<Employee_monthly>();
            foreach (var item in Employees)
                if (input == item.Name)
                    temp.Add(item);
            return temp;
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
             string textsearch = textBoxSearch.Text;
           /*  if (textsearch == null)
                listView_Employees.ItemsSource = Employees;
            else listView_Employees.ItemsSource = FindEmployees(textsearch); */
        }
        


        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new Employee_add();
            if (window.ShowDialog().Value)
            {
                Employees.Add(window.NewEmployee_monthly);
                listView_Employees.Items.Refresh();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView_Employees.SelectedIndex != -1)
            {
                Employees.RemoveAt(listView_Employees.SelectedIndex);
                listView_Employees.Items.Refresh();
            }
        }

        private void listView_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            buttonDelete.IsEnabled = listView_Employees.SelectedIndex != -1;
        }
    }
}
