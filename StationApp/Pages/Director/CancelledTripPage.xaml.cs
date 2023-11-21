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

namespace StationApp.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для CancelledTripPage.xaml
    /// </summary>
    public partial class CancelledTripPage : Page
    {
        private List<CancelledTrip> allCancelledTrips;

        public CancelledTripPage()
        {
            InitializeComponent();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";

            CmbTrain.ItemsSource = DbConnect.entObj.Train.ToList();
            CmbTrain.SelectedValuePath = "Id";
            CmbTrain.DisplayMemberPath = "TrainNumber";

            CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
            allCancelledTrips = DbConnect.entObj.CancelledTrip.ToList();
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            CancelledTripsGrid.ItemsSource = DbConnect.entObj.CancelledTrip.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
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
    }
}
