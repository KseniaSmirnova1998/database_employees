﻿using System;
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
using System.Xml.Serialization;

namespace Assignment
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    
    public partial class MainPage : Page
    {
        List<Employee_monthly> Employees = new List<Employee_monthly>();
        const string FileEmployees = "employees.txt";

        public MainPage()
        {

            InitializeComponent();

            
            Load();

            Employee_monthly.ItemsSource = Employees;
            listView_Employees.ItemsSource = Employees;
           

        }
        private void grid_load(object sender, RoutedEventArgs e)
        {
            Load();
            listView_Employees.ItemsSource = Employees;
            
        }  

        public List<Employee_monthly> FindEmployees(string input)
        {
            List<Employee_monthly> found = new List<Employee_monthly>();
            foreach (var item in Employees)
                if ((item.Name.Contains(input)) || (item.Department.Contains(input)))
                    found.Add(item);
            return found;
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView_Employees.ItemsSource = Employees;
            string textsearch = textBoxSearch.Text;
            if (textsearch == null)
                listView_Employees.ItemsSource = Employees;
            else listView_Employees.ItemsSource = FindEmployees(textsearch);
            Save();
        }



        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            Save();
            NavigationService.Navigate(Pages.Employee_addPage);
            
           
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView_Employees.SelectedIndex != -1)
            {
                
                Employees.Remove(Employees[listView_Employees.SelectedIndex]);
                Save();
                
                listView_Employees.Items.Refresh();
                
                
               
            }
        }

        private void listView_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            buttonDelete.IsEnabled = listView_Employees.SelectedIndex != -1;
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
            listView_Employees.Items.Refresh();
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (listView_Employees.SelectedIndex != -1)
            {
                Pages.EditPage.EmployeeEdit = Employees[listView_Employees.SelectedIndex];
                NavigationService.Navigate(Pages.EditPage);
                
            }
        }

        
    }
}
