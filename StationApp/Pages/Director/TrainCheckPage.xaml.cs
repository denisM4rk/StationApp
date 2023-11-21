using StationApp.AppFiles;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для TrainCheckPage.xaml
    /// </summary>
    public partial class TrainCheckPage : Page
    {
        private List<Train> allItems;
        public TrainCheckPage()
        {
            InitializeComponent();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";

            TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
            allItems = DbConnect.entObj.Train.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TrainGrid.ItemsSource = null;
            string selectedDate = DatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Train.AsEnumerable().Where(row => row.DepartureDate.ToString().Contains(selectedDate));
            TrainGrid.ItemsSource = filteredData;
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allItems.Where(x => x.IdRoute == select.Id) : allItems;
            TrainGrid.ItemsSource = items;
        }

        private void TxbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            TrainGrid.ItemsSource = null;
            string selectedPrice = TxbPrice.Text;
            var filteredData = DbConnect.entObj.Train.AsEnumerable().Where(row => row.Price.ToString().Contains(selectedPrice));
            TrainGrid.ItemsSource = filteredData;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
        }
    }
}
