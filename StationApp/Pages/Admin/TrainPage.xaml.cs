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
    /// Логика взаимодействия для TrainPage.xaml
    /// </summary>
    public partial class TrainPage : Page
    {
        private List<Train> allItems;

        public TrainPage()
        {
            InitializeComponent();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";

            TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
            allItems = DbConnect.entObj.Train.ToList();

        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTrainPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void RouteDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TrainGrid.ItemsSource = null;
            string selectedDate = RouteDatePicker.SelectedDate.Value.ToString();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TrainGrid.SelectedItem != null)
            {
                var filesForRemoving = TrainGrid.SelectedItems.Cast<Train>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Train.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
                    }
                    else
                    {
                        TrainGrid.ItemsSource = DbConnect.entObj.Train.ToList();
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
