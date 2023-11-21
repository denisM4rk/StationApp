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
    /// Логика взаимодействия для AddCancelledTripPage.xaml
    /// </summary>
    public partial class AddCancelledTripPage : Page
    {
        public AddCancelledTripPage()
        {
            InitializeComponent();

            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "ArrivalPlace";
            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();

            CmbTrain.SelectedValuePath = "Id";
            CmbTrain.DisplayMemberPath = "TrainNumber";
            CmbTrain.ItemsSource = DbConnect.entObj.Train.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CmbRoute.SelectedItem == null)
            {
                MessageBox.Show("Выберите маршрут",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbTrain.SelectedItem == null)
            {
                MessageBox.Show("Выберите поезд",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    CancelledTrip cancelledTripObj = new CancelledTrip()
                    {
                        IdRoute = CmbRoute.SelectedIndex+1,
                        IdTrain=CmbTrain.SelectedIndex+1
                    };

                    DbConnect.entObj.CancelledTrip.Add(cancelledTripObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Отмененный маршрут добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new CancelledTripsPage());
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
