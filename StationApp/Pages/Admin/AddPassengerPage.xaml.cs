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
    /// Логика взаимодействия для AddPassengerPage.xaml
    /// </summary>
    public partial class AddPassengerPage : Page
    {
        public AddPassengerPage()
        {
            InitializeComponent();
        }

        private void BtnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            if (CmbGender.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbBaggage.SelectedItem == null)
            {
                MessageBox.Show("Выберите состояние багажа",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbName.Text == null)
            {
                MessageBox.Show("Введите имя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (BirthDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Введите возраст",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Passenger passengerObj = new Passenger()
                    {
                        Name = TxbName.Text,
                        BirthDate = Convert.ToDateTime(BirthDatePicker.SelectedDate),
                        Baggage = CmbBaggage.Text,
                        Gender = CmbGender.Text
                    };

                    DbConnect.entObj.Passenger.Add(passengerObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Пассажир добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new PassengersPage());
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
