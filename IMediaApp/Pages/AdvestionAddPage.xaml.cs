using IMediaApp.Modules;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для AdvestionAddPage.xaml
    /// </summary>
    public partial class AdvestionAddPage : Page
    {
        public AdvestingReport Advesting { get; set; }
        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Reports\";

        private string _photoPath;
        private string _photoName;
        public AdvestionAddPage(AdvestingReport advesting)
        {
            InitializeComponent();
            Advesting = advesting ?? new AdvestingReport();
            AddressCb.ItemsSource = ImediaEntities.GetContext().Addresses.ToList();
            WorkerCb.ItemsSource = ImediaEntities.GetContext().Workers.ToList();
            DataContext = Advesting;
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

            if (fileInfo.Length > 8 * 1024 * 1024 * 6)
            {
                MessageBox.Show("Размер фото не должен превышать 6 мб");
                return;
            }

            _photoName = Guid.NewGuid().ToString();
            _photoPath = fileInfo.FullName;
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Advesting.AddressID = (AddressCb.SelectedItem as Address).AddressID;
                Advesting.WorkerID = (WorkerCb.SelectedItem as Worker).WorkerID;
                if (_photoPath != null)
                {
                    Advesting.Photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Advesting.AdvRepID == 0)
                {
                    ImediaEntities.GetContext().AdvestingReports.Add(Advesting);
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
