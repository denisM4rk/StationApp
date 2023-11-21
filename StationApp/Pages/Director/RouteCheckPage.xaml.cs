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
    /// Логика взаимодействия для RouteCheckPage.xaml
    /// </summary>
    public partial class RouteCheckPage : Page
    {
        public RouteCheckPage()
        {
            InitializeComponent();

            RouteGrid.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
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
            if(CmbRouteCategory.Text != null)
            {
                string searchText = Convert.ToString(CmbRouteCategory.SelectedIndex + 1);
                var filteredItems = DbConnect.entObj.Route.Where(item => item.IdRouteCategory.ToString().Contains(searchText));
                RouteGrid.ItemsSource = filteredItems.ToList();
            }
        }
    }
}
