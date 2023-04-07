using IMediaApp.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMediaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyAdvAddPage.xaml
    /// </summary>
    public partial class BuyAdvAddPage : Page
    {
        public BuyAdv Buy { get; set; }
        public BuyAdvAddPage(BuyAdv buy)
        {
            InitializeComponent();
            Buy = buy ?? new BuyAdv();
            ClientCb.ItemsSource = ImediaEntities.GetContext().Clients.ToList();
            ServiceCb.ItemsSource = ImediaEntities.GetContext().Services.ToList();
            DataContext = Buy;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buy.ClientID = (ClientCb.SelectedItem as Client).ClientID;
                Buy.ServiceID = (ServiceCb.SelectedItem as Service).ServiceID;
                if (Buy.BuyID == 0)
                {
                    ImediaEntities.GetContext().BuyAdvs.Add(Buy);
                }
                ImediaEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
