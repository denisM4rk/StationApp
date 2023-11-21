using StationApp.AppFiles;
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

namespace StationApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = DbConnect.entObj.User.FirstOrDefault(x => x.Email == TxbLogin.Text && x.Password == PsbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден.",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, администратор " + userObj.Email,
                                            "Уведомление",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Information);

                            FrameApp.frmObj.Navigate(new Admin.MainAdminPage());

                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте, начальник " + userObj.Email,
                                           "Уведомление",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);

                            FrameApp.frmObj.Navigate(new Director.MainDirectorPage());

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }
    }
}
