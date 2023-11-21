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

namespace StationApp.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            UsersGrid.ItemsSource = DbConnect.entObj.User.ToList();
        }

        private void TxbUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersGrid.ItemsSource = null;
            string selectedLogin = TxbUser.Text;
            var filteredData = DbConnect.entObj.User.AsEnumerable().Where(row => row.Email.ToString().Contains(selectedLogin));
            UsersGrid.ItemsSource = filteredData;
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = DbConnect.entObj.User.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUsersPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                var filesForRemoving = UsersGrid.SelectedItems.Cast<User>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.User.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        UsersGrid.ItemsSource = DbConnect.entObj.User.ToList();
                    }
                    else
                    {
                        UsersGrid.ItemsSource = DbConnect.entObj.User.ToList();
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }
    }
}
