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
    /// Логика взаимодействия для PartnerListPage.xaml
    /// </summary>
    public partial class PartnerListPage : Page
    {
        public List<Partner> Partners { get; set; }
        public PartnerListPage()
        {
            InitializeComponent();
            DataPart.ItemsSource = null;
            Partners = ImediaEntities.GetContext().Partners.ToList();
            DataContext = this;
            DataPart.ItemsSource = Partners;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PartnerAddPage(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PartnerAddPage((Partner)(sender as Button).DataContext));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<Partner> partners = ImediaEntities.GetContext().Partners.ToList();
            DataPart.ItemsSource = partners;
        }
    }
}
