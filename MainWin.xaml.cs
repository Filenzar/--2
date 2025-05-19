using _19._05._25ContolW.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public User user;
        public MainWin(User _user)
        {
            InitializeComponent();
            this.user = _user;
            UserNameLabel.Content += user.Fio;
            using (CwdbContext context = new CwdbContext())
            {
                RequestList.ItemsSource = context.Requests.Include(o=>o.UserReqNavigation)
                    .Include(o => o.TypeReqNavigation)
                    .Include(o => o.StatusReqNavigation)
                    .ToList();
            }
        }

        private void ReqButton_Click(object sender, RoutedEventArgs e)
        {
            var logwin = new ReqWin();
            logwin.ShowDialog();
            using (CwdbContext context = new CwdbContext())
            {
                RequestList.ItemsSource = context.Requests.Include(o => o.UserReqNavigation)
                    .Include(o => o.TypeReqNavigation)
                    .Include(o => o.StatusReqNavigation)
                    .ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RequestList.SelectedItem is Request selectedRequest)
            {
                using (CwdbContext context = new CwdbContext())
                {
                    // получаем первый объект
                    Request Request = context.Requests.FirstOrDefault(o => o.Article == selectedRequest.Article);
                    if (Request != null)
                    {
                        var newwin = new ReqChangeWin(Request);
                        newwin.ShowDialog();
                        RequestList.ItemsSource = context.Requests.Include(o => o.UserReqNavigation)
                     .Include(o => o.TypeReqNavigation)
                     .Include(o => o.StatusReqNavigation)
                     .ToList();
                    }
                    
                }
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestList.SelectedItem is Request selectedRequest)
            {
                using (CwdbContext context = new CwdbContext())
                {
                    // получаем первый объект
                    Request Request = context.Requests.FirstOrDefault(o => o.Article == selectedRequest.Article);
                    if (Request.UserReq == null)
                    {
                        Request.UserReq = user.Login;
                        context.Requests.Update(Request);
                        context.SaveChanges();
                        
                    }
                    else if (Request.UserReq == user.Login)
                    {
                        Request.UserReq = null;
                        context.Requests.Update(Request);
                        context.SaveChanges();
                    }
                    else if ((Request.UserReq != null)&&(Request.UserReq != user.Login))
                    {
                        MessageBox.Show("Это заявка уже занята", "Предупреждение");
                    }
                    RequestList.ItemsSource = context.Requests.Include(o => o.UserReqNavigation)
                     .Include(o => o.TypeReqNavigation)
                     .Include(o => o.StatusReqNavigation)
                     .ToList();
                }
            }
        }
    }
}
