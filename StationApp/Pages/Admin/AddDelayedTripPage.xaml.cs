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
    /// Логика взаимодействия для AddDelayedTripPage.xaml
    /// </summary>
    public partial class AddDelayedTripPage : Page
    {
        public AddDelayedTripPage()
        {
            InitializeComponent();

            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";
            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbQuantity.Text == null)
            {
                MessageBox.Show("Введите количество",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            if (TxbReason.Text == null)
            {
                MessageBox.Show("Введите причину",
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
                    DelayedTrip delayedTripObj = new DelayedTrip()
                    {
                        IdRoute = CmbRoute.SelectedIndex + 1,
                        Reason = TxbReason.Text,
                        TicketsQuantity = Convert.ToInt32(TxbQuantity.Text)
                    };

                    DbConnect.entObj.DelayedTrip.Add(delayedTripObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Задержанный маршрут добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new DelayedTripPage());
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