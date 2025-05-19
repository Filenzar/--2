using _19._05._25ContolW.Models;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _19._05._25ContolW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(LoginBox.Text))&& (!string.IsNullOrEmpty(PasswBox.Password)))
            {
                using (CwdbContext context = new CwdbContext())
                {
                    User foundUs = context.Users.FirstOrDefault(o => o.Login == LoginBox.Text && o.Password == PasswBox.Password);
                    if (foundUs != null)
                    {
                        MessageBox.Show("Вы успешно авторизовались", "Авторизация");
                        var mainwin = new MainWin(foundUs);
                        mainwin.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Такого пользователя не существует", "Авторизация");
                }
            }
            else MessageBox.Show("Заполните все поля","Ошибка");
            
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var regwin = new RegistrationWn();
            regwin.Show();
            this.Close();
        }
    }
}