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
    /// Логика взаимодействия для ReportAddPage.xaml
    /// </summary>
    public partial class ReportAddPage : Page
    {
        public Report Report { get; set; }
        public ReportAddPage(Report report)
        {
            InitializeComponent();
            Report = report ?? new Report();
            AdvRepCb.ItemsSource = ImediaEntities.GetContext().AdvestingReports.ToList();
            ServiceCb.ItemsSource = ImediaEntities.GetContext().Services.ToList();
            WorkCb.ItemsSource = ImediaEntities.GetContext().Workers.ToList();
            DataContext = Report;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Report.AdvRepID = (AdvRepCb.SelectedItem as AdvestingReport).AdvRepID;
                Report.WorkerID = (WorkCb.SelectedItem as Worker).WorkerID;
                Report.ServiceID = (ServiceCb.SelectedItem as Service).ServiceID;
                if (Report.ReportID == 0)
                {
                    ImediaEntities.GetContext().Reports.Add(Report);
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
