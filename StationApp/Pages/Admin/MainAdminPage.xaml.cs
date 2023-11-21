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
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
        }

        private void BtnPassengers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PassengersPage());
        }

        private void BtnRoute_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new RoutePage());
        }

        private void BtnDelayedTrips_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new DelayedTripPage());
        }

        private void BtnTrain_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TrainPage());
        }

        private void BtnPassedTickets_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PassedTicketsPage());
        }

        private void BtnUnboughtTickets_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UnboughtTicketsPage());
        }

        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TicketsPage());
        }

        private void BtnInspection_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new InspectionPage());
        }

        private void BtnLocomotive_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LocomotivePage());
        }

        private void BtnDrivers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LocomotiveDriversPage());
        }

        private void BtnBrigade_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new BrigadePage());
        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new EmployeePage());
        }

        private void BtnCancelledTrips_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new CancelledTripsPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AuthorizationPage());
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UsersPage());
        }
    }
}
