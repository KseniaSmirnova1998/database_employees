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
using System.IO;


namespace Assignment
{
    /// <summary>
    /// Логика взаимодействия для Log_inPage.xaml
    /// </summary>
    
        public class Password_data
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }


        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Password_data(string login, string password)
        {
            _login = login;
            _password = password;
        }
    }
    public partial class Log_inPage : Page
    {
        List<Password_data> Password_info = new List<Password_data>();
        const string FilePassword = "passwords.txt";

        public Log_inPage()
        
        {
            InitializeComponent();
            textBox_login.Focus();
            PasswordLoad();
            
        }
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            int k=1;

            foreach (var pswd in Password_info)
            {

                //var hash = CalculateHash("legkaya");
                var hash = pswd.Password;
                

                if (textBox_login.Text == pswd.Login && CalculateHash(PasswordBox.Password) == hash)
                {
                    NavigationService.Navigate(Pages.MainPage);
                    k = 1;
                    break;
                }
                else k = 0;
            }

                if (k==0)
                {
                    MessageBox.Show("Логин или пароль были введены неверно.");
                    
                }

            
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
                button_login_Click(null, null);
        }
        private void PasswordLoad()
        {
            try
            {
                Password_info = new List<Password_data>();


                using (var str = new StreamReader(FilePassword))
                {
                    while (!str.EndOfStream)
                    {
                        var line = str.ReadLine();
                        var parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            var personal_data = new Password_data(parts[0], parts[1]);
                            Password_info.Add(personal_data);
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }

    }
}
