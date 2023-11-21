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
    /// Логика взаимодействия для LocomotiveCheckPage.xaml
    /// </summary>
    public partial class LocomotiveCheckPage : Page
    {
        private List<Locomotive> allDrivers;

        public LocomotiveCheckPage()
        {
            InitializeComponent();

            LocomotiveGrid.ItemsSource = DbConnect.entObj.Locomotive.ToList();
            allDrivers = DbConnect.entObj.Locomotive.ToList();

            CmbDriver.ItemsSource = DbConnect.entObj.LocomotiveDriver.ToList();
            CmbDriver.SelectedValuePath = "Id";
            CmbDriver.DisplayMemberPath = "Name";
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = DbConnect.entObj.Locomotive.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void DeparturePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedDate = DeparturePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.DepartureDate.ToString().Contains(selectedDate));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void ArrialPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedDate = ArrialPicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.ArrivalDate.ToString().Contains(selectedDate));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void TxbQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedPrice = TxbQuantity.Text;
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.RouteQuantity.ToString().Contains(selectedPrice));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void CmbDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbDriver.SelectedItem as LocomotiveDriver;
            var items = (select != null) ? allDrivers.Where(x => x.IdLocomotiveDriver == select.Id) : allDrivers;
            LocomotiveGrid.ItemsSource = items;
        }
    }
}
