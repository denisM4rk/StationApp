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
    /// Логика взаимодействия для AddTrainPage.xaml
    /// </summary>
    public partial class AddTrainPage : Page
    {
        public AddTrainPage()
        {
            InitializeComponent();

            CmbLocomotive.SelectedValuePath = "Id";
            CmbLocomotive.DisplayMemberPath = "Id";
            CmbLocomotive.ItemsSource = DbConnect.entObj.Locomotive.ToList();

            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "Id";
            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
        }

        private void BtnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            if (TxbPrice.Text == null)
            {
                MessageBox.Show("Введите цену",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (DeparturePicker.SelectedDate == null)
            {
                MessageBox.Show("Введите дату прибытия",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (ArrivalPicker.SelectedDate == null)
            {
                MessageBox.Show("Введите дату отправления",
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
            else if (TxbNumber.Text == null)
            {
                MessageBox.Show("Введите номер поезда",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Train trainObj = new Train()
                    {
                        TrainNumber = TxbNumber.Text,
                        DepartureDate = Convert.ToDateTime(DeparturePicker.SelectedDate),
                        ArrivalDate = Convert.ToDateTime(ArrivalPicker.SelectedDate),
                        Price = Convert.ToDecimal(TxbPrice.Text),
                        IdLocomotive = CmbLocomotive.SelectedIndex + 1,
                        IdRoute = CmbRoute.SelectedIndex + 1
                    };

                    DbConnect.entObj.Train.Add(trainObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Поезд добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new TrainPage());
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
