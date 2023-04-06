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

namespace IMediaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (LoginData.isAuth == true)
            {
                UserSP.Visibility = Visibility.Hidden;
                AdminSP.Visibility = Visibility.Visible;
            }
            else
            {
                UserSP.Visibility = Visibility.Visible;
                AdminSP.Visibility = Visibility.Hidden;
            }
            if (LoginData.Role == 2)
            {
                BuyAdvBtn.Visibility = Visibility.Visible;
                ClientBtn.Visibility = Visibility.Visible;
                ReportBtn.Visibility = Visibility.Visible;
                WorkerBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BuyAdvBtn.Visibility = Visibility.Hidden;
                ClientBtn.Visibility = Visibility.Hidden;
                ReportBtn.Visibility = Visibility.Hidden;
                WorkerBtn.Visibility = Visibility.Hidden;
            }
        }

        private void AboutUsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AboutUsPage());
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TeamBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.TeamPage());

        }

        private void PartnerBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PartnerPage());
        }

        private void ContactBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ContactPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void AddressBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddressPage());
        }

        private void AdvRepBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuyAdvBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PartnerBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void PartnersBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WorkerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
