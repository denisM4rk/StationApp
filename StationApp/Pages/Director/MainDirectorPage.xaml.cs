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
    /// Логика взаимодействия для MainDirectorPage.xaml
    /// </summary>
    public partial class MainDirectorPage : Page
    {
        public MainDirectorPage()
        {
            InitializeComponent();
        }

        private void BtnRoute_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new RouteCheckPage());
        }

        private void BtnEmployeeCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new EmployeeCheckPage());
        }

        private void BtnBrigadeCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new BrigadeCheckPage());
        }

        private void BtnDriversCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LocomotiveDriversCheckPage());
        }

        private void BtnInspectionCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new InspectionCheckPage());
        }

        private void BtnLocomotiveCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new LocomotiveCheckPage());
        }

        private void BtnTicketsCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TicketsCheckPage());
        }

        private void BtnUnboughtTicketsCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UnboughtTicketsCheckPage());
        }

        private void BtnTrainCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TrainCheckPage());
        }

        private void BtnDelayedTripsCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new DelayedTripCheckPage()); ;
        }

        private void BtnCancelledTripsCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new CancelledTripPage());
        }

        private void BtnPassengersCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PassengersCheckPage());
        }

        private void BtnPassedTicketsCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PassedTicketsCheckPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AuthorizationPage());
        }
    }
}
