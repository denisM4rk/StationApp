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
    /// Логика взаимодействия для DelayedTripPage.xaml
    /// </summary>
    public partial class DelayedTripPage : Page
    {
        private List<DelayedTrip> allDelayedTrips;

        public DelayedTripPage()
        {
            InitializeComponent();

            DelayedTripGrid.ItemsSource = DbConnect.entObj.DelayedTrip.ToList();
            allDelayedTrips = DbConnect.entObj.DelayedTrip.ToList();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            DelayedTripGrid.ItemsSource = DbConnect.entObj.DelayedTrip.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddDelayedTripPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allDelayedTrips.Where(x => x.IdRoute == select.Id) : allDelayedTrips;
            DelayedTripGrid.ItemsSource = items;
        }

        private void TxbTicketCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            DelayedTripGrid.ItemsSource = null;
            string selectedPrice = TxbTicketCount.Text;
            var filteredData = DbConnect.entObj.DelayedTrip.AsEnumerable().Where(row => row.TicketsQuantity.ToString().Contains(selectedPrice));
            DelayedTripGrid.ItemsSource = filteredData;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DelayedTripGrid.SelectedItem != null)
            {
                var filesForRemoving = DelayedTripGrid.SelectedItems.Cast<DelayedTrip>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.DelayedTrip.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        DelayedTripGrid.ItemsSource = DbConnect.entObj.DelayedTrip.ToList();
                    }
                    else
                    {
                        DelayedTripGrid.ItemsSource = DbConnect.entObj.DelayedTrip.ToList();
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
