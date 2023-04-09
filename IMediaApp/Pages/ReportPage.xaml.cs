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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public List<Report> Reports { get; set; }
        public ReportPage()
        {
            InitializeComponent();
            DataReport.ItemsSource = null;
            Reports = ImediaEntities.GetContext().Reports.ToList();
            DataContext = this;
            DataReport.ItemsSource = Reports;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ReportAddPage((Report)(sender as Button).DataContext));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ReportAddPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<Report> reports = ImediaEntities.GetContext().Reports.ToList();
            DataReport.ItemsSource = reports;
        }
    }
}
