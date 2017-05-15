using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Log_inPage.xaml
    /// </summary>
    public partial class Log_inPage : Page
    {
        public Log_inPage()
        
        {
            InitializeComponent();
            textBox_login.Focus();
        }
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            var hash = CalculateHash("12345");

            if (textBox_login.Text == "smirnova" && CalculateHash(PasswordBox.Password) == hash)
                NavigationService.Navigate(Pages.MainPage);
            else
                MessageBox.Show("Логин или пароль были введены неверно.");
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Using keyboard handling on the page level
            if (e.Key == Key.Enter)
                button_login_Click(null, null);
        }

    }
}
