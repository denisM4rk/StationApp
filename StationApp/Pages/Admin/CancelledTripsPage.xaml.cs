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
    /// Логика взаимодействия для CancelledTripsPage.xaml
    /// </summary>
    public partial class CancelledTripsPage : Page
    {
        private List<CancelledTrip> allCancelledTrips;

        public CancelledTripsPage()
        {
            InitializeComponent();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";

            CmbTrain.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbTrain.SelectedValuePath = "Id";
            CmbTrain.DisplayMemberPath = "TrainNumber";

            CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
            allCancelledTrips = DbConnect.entObj.CancelledTrip.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddCancelledTripPage());
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allCancelledTrips.Where(x => x.IdRoute == select.Id) : allCancelledTrips;
            CancelledTripsGrid.ItemsSource = items;
        }

        private void CmbTrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbTrain.SelectedItem as Train;
            var items = (select != null) ? allCancelledTrips.Where(x => x.IdTrain == select.Id) : allCancelledTrips;
            CancelledTripsGrid.ItemsSource = items;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CancelledTripsGrid.SelectedItem != null)
            {
                var filesForRemoving = CancelledTripsGrid.SelectedItems.Cast<CancelledTrip>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.CancelledTrip.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
                    }
                    else
                    {
                        CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
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
