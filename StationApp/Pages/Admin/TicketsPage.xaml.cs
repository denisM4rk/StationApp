using StationApp.AppFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        private List<Ticket> allTickets;

        public TicketsPage()
        {
            InitializeComponent();

            TicketsGrid.ItemsSource = DbConnect.entObj.Ticket.ToList();
            allTickets = DbConnect.entObj.Ticket.ToList();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";

            CmbPassenger.ItemsSource = DbConnect.entObj.Passenger.ToList();
            CmbPassenger.SelectedValuePath = "Id";
            CmbPassenger.DisplayMemberPath = "Name";
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            TicketsGrid.ItemsSource = DbConnect.entObj.Ticket.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTicketsPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void TicketDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TicketsGrid.ItemsSource = null;
            string selectedDate = TicketDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Ticket.AsEnumerable().Where(row => row.Date.ToString().Contains(selectedDate));
            TicketsGrid.ItemsSource = filteredData;
        }

        private void TxbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            TicketsGrid.ItemsSource = null;
            string selectedPrice = TxbPrice.Text;
            var filteredData = DbConnect.entObj.Ticket.AsEnumerable().Where(row => row.Price.ToString().Contains(selectedPrice));
            TicketsGrid.ItemsSource = filteredData;
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allTickets.Where(x => x.IdRoute == select.Id) : allTickets;
            TicketsGrid.ItemsSource = items;
        }

        private void CmbUnbought_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbPassed.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(TicketsGrid.ItemsSource);
            if (selectedGender == "Да")
            {
                dataView.Filter = item => ((Ticket)item).ArePassed == "Да";
            }
            else if (selectedGender == "Нет")
            {
                dataView.Filter = item => ((Ticket)item).ArePassed == "Нет";
            }
            else
            {
                dataView.Filter = null;
            }
        }

        private void CmbPassed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbUnbought.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(TicketsGrid.ItemsSource);
            if (selectedGender == "Да")
            {
                dataView.Filter = item => ((Ticket)item).AreUnbought == "Да";
            }
            else if (selectedGender == "Нет")
            {
                dataView.Filter = item => ((Ticket)item).AreUnbought == "Нет";
            }
            else
            {
                dataView.Filter = null;
            }
        }

        private void CmbPassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbPassenger.SelectedItem as Passenger;
            var items = (select != null) ? allTickets.Where(x => x.IdPassenger == select.Id) : allTickets;
            TicketsGrid.ItemsSource = items;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TicketsGrid.SelectedItem != null)
            {
                var filesForRemoving = TicketsGrid.SelectedItems.Cast<Ticket>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Ticket.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        TicketsGrid.ItemsSource = DbConnect.entObj.Ticket.ToList();
                    }
                    else
                    {
                        TicketsGrid.ItemsSource = DbConnect.entObj.Ticket.ToList();
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
