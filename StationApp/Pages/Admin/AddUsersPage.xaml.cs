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
    /// Логика взаимодействия для AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        public AddUsersPage()
        {
            InitializeComponent();

            CmbRole.ItemsSource = DbConnect.entObj.Role.ToList();
            CmbRole.SelectedValuePath = "Id";
            CmbRole.DisplayMemberPath = "Name";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UsersPage());
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (TxbLogin.Text == null)
            {
                MessageBox.Show("Введите логин",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbPassword.Text == null)
            {
                MessageBox.Show("Введите пароль",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DbConnect.entObj.User.Count(x => x.Email == TxbLogin.Text) > 0)
                {
                    MessageBox.Show("Такой пользователь уже есть!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        User userObj = new User()
                        {
                            Email = TxbLogin.Text,
                            Password = TxbPassword.Text,
                            IdRole = CmbRole.SelectedIndex + 1
                        };

                        DbConnect.entObj.User.Add(userObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Новый пользователь добавлен!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new UsersPage());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                        "Критический сбой работы приложения",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
