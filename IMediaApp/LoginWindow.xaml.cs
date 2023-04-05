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
using System.Windows.Shapes;
using IMediaApp.Modules;

namespace IMediaApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Worker user = ImediaEntities.GetContext().Workers.FirstOrDefault(p => p.Login == LoginTb.Text && p.Password == PasswordPb.Password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль, пожалуйста попробуйте ещё раз");
                return;
            }

            LoginData.Role = user.RoleID;
            LoginData.isAuth = true;
            MainWindow hrWindow = new MainWindow();
            hrWindow.Show();

            this.Close();
        }
    }
}
