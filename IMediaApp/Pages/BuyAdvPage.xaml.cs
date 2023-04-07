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
    /// Логика взаимодействия для BuyAdvPage.xaml
    /// </summary>
    public partial class BuyAdvPage : Page
    {
        public List<BuyAdv> Buys { get; set; }
        public BuyAdvPage()
        {
            InitializeComponent();
            DataAdvest.ItemsSource = null;
            Buys = ImediaEntities.GetContext().BuyAdvs.ToList();
            DataContext = this;
            DataAdvest.ItemsSource = Buys;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.BuyAdvAddPage((BuyAdv)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.BuyAdvAddPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<BuyAdv> buys = ImediaEntities.GetContext().BuyAdvs.ToList();
            DataAdvest.ItemsSource = buys;
        }
    }
}
