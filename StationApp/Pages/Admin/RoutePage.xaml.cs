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
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Page
    {
        public RoutePage()
        {
            InitializeComponent();

            RouteGrid.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddRoutePage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            RouteGrid.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void TxbPlace_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbPlace.Text != null)
            {
                string searchText = TxbPlace.Text;

                var filteredItems = DbConnect.entObj.Route.Where(item => item.ArrivalPlace.ToString().Contains(searchText));

                RouteGrid.ItemsSource = filteredItems.ToList();
            }
        }

        private void CmbRouteCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbRouteCategory.Text != null)
            {
                string searchText = Convert.ToString(CmbRouteCategory.SelectedIndex + 1);
                var filteredItems = DbConnect.entObj.Route.Where(item => item.IdRouteCategory.ToString().Contains(searchText));
                RouteGrid.ItemsSource = filteredItems.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (RouteGrid.SelectedItem != null)
            {
                var filesForRemoving = RouteGrid.SelectedItems.Cast<Route>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Route.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        RouteGrid.ItemsSource = DbConnect.entObj.Route.ToList();
                    }
                    else
                    {
                        RouteGrid.ItemsSource = DbConnect.entObj.Route.ToList();
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
}
