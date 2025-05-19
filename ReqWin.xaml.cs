using _19._05._25ContolW.Models;
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
using System.Windows.Shapes;

namespace _19._05._25ContolW
{
    /// <summary>
    /// Логика взаимодействия для ReqWin.xaml
    /// </summary>
    public partial class ReqWin : Window
    {
        public ReqWin()
        {
            InitializeComponent();
            using (CwdbContext context = new CwdbContext()) 
            {
                TypeReqBox.ItemsSource = context.TypeRequests.ToList();
                TypeReqBox.DisplayMemberPath = "Type";
                TypeReqBox.SelectedValuePath = "Type";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(DescriptionBox.Text)) || (!string.IsNullOrEmpty(FulDescriptionnBox.Text)) || (TypeReqBox.SelectedValue!=null))
            {
                using (CwdbContext context = new CwdbContext())
                {

                    Request newUs = new Request { Description = DescriptionBox.Text, FulDescription = FulDescriptionnBox.Text,StatusReq = "На рассмотрении", TypeReq = TypeReqBox.SelectedValue.ToString(), DateRegistration = DateOnly.FromDateTime(DateTime.Now) };
                    context.Requests.Add(newUs);
                    context.SaveChanges();
                    MessageBox.Show("Вы добавили заявку", "Добавление");
                    this.Close();
                }
            }
            else MessageBox.Show("Заполните все поля", "Ошибка");
        }
    }
}
