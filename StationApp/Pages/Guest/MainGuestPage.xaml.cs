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

namespace StationApp.Pages.Guest
{
    /// <summary>
    /// Логика взаимодействия для MainGuestPage.xaml
    /// </summary>
    public partial class MainGuestPage : Page
    {
        public MainGuestPage()
        {
            InitializeComponent();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AuthorizationPage());
        }

        private void BtnTrainCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Director.TrainCheckPage());
        }

        private void BtnRouteCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Director.RouteCheckPage());
        }
    }
}
