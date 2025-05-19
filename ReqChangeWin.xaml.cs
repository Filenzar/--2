using _19._05._25ContolW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ReqChangeWin.xaml
    /// </summary>
    public partial class ReqChangeWin : Window
    {
        public Request req;
        public ReqChangeWin(Request _req)
        {
            InitializeComponent();
            this.req = _req;
            DescriptionBox.Text = req.Description;
            FulDescriptionnBox.Text = req.FulDescription;

            using (CwdbContext context = new CwdbContext())
            {
                TypeReqBox.ItemsSource = context.TypeRequests.ToList();
                TypeReqBox.DisplayMemberPath = "Type";
                TypeReqBox.SelectedValuePath = "Type";
                TypeReqBox.SelectedValue = req.TypeReq;
                StatusReqBox.ItemsSource = context.StatusRequests.ToList();
                StatusReqBox.DisplayMemberPath = "Status";
                StatusReqBox.SelectedValuePath = "Status";
                StatusReqBox.SelectedValue = req.StatusReq;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (CwdbContext db = new CwdbContext())
            {
                //удаляем объект
                db.Requests.Remove(req);
                db.SaveChanges();

                MessageBox.Show("Заявка удалёна","Удаление" );
                this.Close();
            }
            
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

            using (CwdbContext context = new CwdbContext())
            {
                req.Description = DescriptionBox.Text;
                req.FulDescription = FulDescriptionnBox.Text;
                req.TypeReq = TypeReqBox.SelectedValue.ToString();
                req.StatusReq = StatusReqBox.SelectedValue.ToString();
                //обновляем объект
                context.Requests.Update(req);
                context.SaveChanges();
                MessageBox.Show("Заявка изменена", "Редактирование");
                this.Close();
            }
        }
    }
}
