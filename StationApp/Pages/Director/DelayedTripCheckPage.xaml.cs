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
    /// Логика взаимодействия для DelayedTripCheckPage.xaml
    /// </summary>
    public partial class DelayedTripCheckPage : Page
    {
        private List<DelayedTrip> allDelayedTrips;

        public DelayedTripCheckPage()
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void TxbTicketQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            DelayedTripGrid.ItemsSource = null;
            string selectedPrice = TxbTicketQuantity.Text;
            var filteredData = DbConnect.entObj.DelayedTrip.AsEnumerable().Where(row => row.TicketsQuantity.ToString().Contains(selectedPrice));
            DelayedTripGrid.ItemsSource = filteredData;
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allDelayedTrips.Where(x => x.IdRoute == select.Id) : allDelayedTrips;
            DelayedTripGrid.ItemsSource = items;
        }
    }
}
