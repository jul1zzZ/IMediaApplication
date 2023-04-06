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
    /// Логика взаимодействия для AddressPage.xaml
    /// </summary>
    public partial class AddressPage : Page
    {
        public List<Address> Addresses { get; set; }
        public AddressPage()
        {
            InitializeComponent();
            DataAddress.ItemsSource = null;
            Addresses = ImediaEntities.GetContext().Addresses.ToList();
            DataContext = this;
            DataAddress.ItemsSource = Addresses;
            if (LoginData.Role == 2)
            {
                AddBtn.Visibility= Visibility.Visible;
                EditDGT.Visibility= Visibility.Visible;
                DataAddress.MinColumnWidth = 135;
            }
            else
            {
                AddBtn.Visibility = Visibility.Hidden;
                EditDGT.Visibility = Visibility.Hidden;
                DataAddress.MinColumnWidth = 165;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<Address> addresses = ImediaEntities.GetContext().Addresses.ToList();
            DataAddress.ItemsSource = addresses;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddAddressPage(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddAddressPage((Address)(sender as Button).DataContext));
        }
    }
}
