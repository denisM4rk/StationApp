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
    /// Логика взаимодействия для AddTicketsPage.xaml
    /// </summary>
    public partial class AddTicketsPage : Page
    {
        public AddTicketsPage()
        {
            InitializeComponent();

            CmbPassenger.SelectedValuePath = "Id";
            CmbPassenger.DisplayMemberPath = "Name";
            CmbPassenger.ItemsSource = DbConnect.entObj.Passenger.ToList();

            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "Id";
            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbPrice.Text == null)
            {
                MessageBox.Show("Введите цену",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Введите дату",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbPassenger.SelectedItem == null)
            {
                MessageBox.Show("Выберите пассажира",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbRoute.SelectedItem == null)
            {
                MessageBox.Show("Выберите маршрут",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Ticket ticketObj = new Ticket()
                    {
                        Date = Convert.ToDateTime(DatePicker.SelectedDate),
                        Price = Convert.ToDecimal(TxbPrice.Text),
                        IdPassenger= CmbPassenger.SelectedIndex+1,
                        IdRoute=CmbRoute.SelectedIndex+1,
                        ArePassed = CmbPassed.Text,
                        AreUnbought = CmbUnbought.Text
                    };

                    DbConnect.entObj.Ticket.Add(ticketObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Билет добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new TicketsPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                    "Критический сбой работы приложения",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }
    }
}