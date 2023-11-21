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
    /// Логика взаимодействия для LocomotivePage.xaml
    /// </summary>
    public partial class LocomotivePage : Page
    {
        private List<Locomotive> allDrivers;

        public LocomotivePage()
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddLocomotivePage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void DepartureDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedDate = DepartureDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.DepartureDate.ToString().Contains(selectedDate));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void ArrivalDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedDate = ArrivalDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.ArrivalDate.ToString().Contains(selectedDate));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void TxbRouteQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            LocomotiveGrid.ItemsSource = null;
            string selectedPrice = TxbRouteQuantity.Text;
            var filteredData = DbConnect.entObj.Locomotive.AsEnumerable().Where(row => row.RouteQuantity.ToString().Contains(selectedPrice));
            LocomotiveGrid.ItemsSource = filteredData;
        }

        private void CmbDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbDriver.SelectedItem as LocomotiveDriver;
            var items = (select != null) ? allDrivers.Where(x => x.IdLocomotiveDriver == select.Id) : allDrivers;
            LocomotiveGrid.ItemsSource = items;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LocomotiveGrid.SelectedItem != null)
            {
                var filesForRemoving = LocomotiveGrid.SelectedItems.Cast<Locomotive>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Locomotive.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        LocomotiveGrid.ItemsSource = DbConnect.entObj.Locomotive.ToList();
                    }
                    else
                    {
                        LocomotiveGrid.ItemsSource = DbConnect.entObj.Locomotive.ToList();
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
