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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public List<Client> Clients { get; set; }
        public ClientPage()
        {
            InitializeComponent();
            DataClient.ItemsSource = null;
            Clients = ImediaEntities.GetContext().Clients.ToList();
            DataContext = this;
            DataClient.ItemsSource = Clients;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientAddPage((Client)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientAddPage(null));
        }
    }
}
