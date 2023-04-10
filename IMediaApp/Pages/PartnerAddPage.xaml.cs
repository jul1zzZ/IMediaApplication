using IMediaApp.Modules;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PartnerAddPage.xaml
    /// </summary>
    public partial class PartnerAddPage : Page
    {
        public Partner Partner { get; set; }
        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;
        public PartnerAddPage(Partner partner)
        {
            InitializeComponent();
            Partner = partner ?? new Partner();
            DataContext = Partner;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_photoPath != null)
                {
                    Partner.Photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Partner.PartnerID == 0)
                {
                    ImediaEntities.GetContext().Partners.Add(Partner);
                }
                ImediaEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
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
    }
}
