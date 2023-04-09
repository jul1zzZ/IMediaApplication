using IMediaApp.Modules;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMediaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        public Client Client { get; set; }
        public ClientAddPage(Client client)
        {
            InitializeComponent();
            Client = client ?? new Client();
            DataContext = Client;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Client.ClientID == 0)
                {
                    ImediaEntities.GetContext().Clients.Add(Client);
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
