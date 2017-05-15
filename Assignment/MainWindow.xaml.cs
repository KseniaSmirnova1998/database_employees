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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            Assignment_frame.Navigate(new Log_inPage());

            

            
        }

        
        /* public List<Employee_monthly> FindEmployees(string input)
        {
            List<Employee_monthly> temp = new List<Employee_monthly>();
            foreach (var item in Employees)
                if (input == item.Name)
                    temp.Add(item);
            return temp;
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //listView_Employees.ItemsSource = new List<Employee_monthly>();
            string textsearch = textBoxSearch.Text;
            if (textsearch == null)
                listView_Employees.ItemsSource = Employees;
            else listView_Employees.ItemsSource = FindEmployees(textsearch);
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
        } */

        



        /* private bool find(object employee)
         {
             foreach (ListViewItem employee in listView_Employees.Items)
             {
                 if (employee.Content.Equals(str))
                 {
                     return true;
                 }
             }

             return false;
         } 

         private void select(string str)
         {
             foreach (ListViewItem employee in listView_Employees.Items)
             {
                 if (employee.Content.Equals(str))
                 {
                     employee.IsSelected = true;
                 }
                 else
                 {
                     employee.IsSelected = false;
                 }
             }
         }



         private void buttonSearch_Click(object sender, RoutedEventArgs e)
         {
             if (find(textBoxSearch.Text))
             {
                 select(textBoxSearch.Text);
             }
             else
             {
                 MessageBox.Show("Сотрудник не найден. Проверьте введенные данные.");
             }
         } */
    }
}
