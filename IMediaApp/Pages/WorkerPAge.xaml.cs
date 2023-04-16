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
    /// Логика взаимодействия для WorkerPAge.xaml
    /// </summary>
    public partial class WorkerPAge : Page
    {
        public List<Worker> Workers { get; set; }
        public WorkerPAge()
        {
            InitializeComponent();
            DataWork.ItemsSource = null;
            Workers = ImediaEntities.GetContext().Workers.ToList();
            DataContext = this;
            DataWork.ItemsSource = Workers;
            
        }

    }
}
