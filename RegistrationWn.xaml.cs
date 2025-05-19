using _19._05._25ContolW.Models;
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
using System.Windows.Shapes;

namespace _19._05._25ContolW
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWn.xaml
    /// </summary>
    public partial class RegistrationWn : Window
    {
        public RegistrationWn()
        {
            InitializeComponent();
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(LoginBox.Text)) || (!string.IsNullOrEmpty(PasswBox.Text)) || (!string.IsNullOrEmpty(FioBox.Text)) || (!string.IsNullOrEmpty(PhoneBox.Text)))
            {
                using (CwdbContext context = new CwdbContext())
                {

                    User newUs = new User { Login = LoginBox.Text, Password = PasswBox.Text, Fio = FioBox.Text, PhoneNumber = PhoneBox.Text };
                    context.Users.Add(newUs);
                    context.SaveChanges();
                    MessageBox.Show("Вы зарегестрированы", "Регистрация");
                    var logwin = new LoginWin();
                    logwin.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Заполните все поля", "Ошибка");

        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var logwin = new LoginWin();
            logwin.Show();
            this.Close();
        }
    }
}
