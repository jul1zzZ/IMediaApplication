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
    /// Логика взаимодействия для AddAddressPage.xaml
    /// </summary>
    public partial class AddAddressPage : Page
    {
        public Address Address { get; set; }
        public AddAddressPage(Address address)
        {
            InitializeComponent();
            Address = address ?? new Address();
            RegionCb.ItemsSource = ImediaEntities.GetContext().Regions.ToList();
            TypeCb.ItemsSource = ImediaEntities.GetContext().FlyersTypes.ToList();
            DataContext = Address;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Address.RegionID = (RegionCb.SelectedItem as Region).RegionID;
                Address.FlyersTypeID = (TypeCb.SelectedItem as FlyersType).TypeID;
                if (Address.AddressID == 0)
                {
                    ImediaEntities.GetContext().Addresses.Add(Address);
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
