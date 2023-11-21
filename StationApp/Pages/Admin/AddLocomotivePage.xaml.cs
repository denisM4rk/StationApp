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
    /// Логика взаимодействия для AddLocomotivePage.xaml
    /// </summary>
    public partial class AddLocomotivePage : Page
    {
        public AddLocomotivePage()
        {
            InitializeComponent();

            CmbDriver.SelectedValuePath = "Id";
            CmbDriver.DisplayMemberPath = "Name";
            CmbDriver.ItemsSource = DbConnect.entObj.LocomotiveDriver.ToList();
        }

        private void BtnAddLocomotive_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDriver.SelectedItem == null)
            {
                MessageBox.Show("Выберите водителя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbQuantity.Text == null)
            {
                MessageBox.Show("Введите количество маршрутов",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (ArrivalPicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (DeparturePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Locomotive locomotiveObj = new Locomotive()
                    {
                        DepartureDate = Convert.ToDateTime(DeparturePicker.SelectedDate),
                        ArrivalDate = Convert.ToDateTime(ArrivalPicker.SelectedDate),
                        RouteQuantity = Convert.ToInt32(TxbQuantity.Text),
                        IdLocomotiveDriver = CmbDriver.SelectedIndex+1
                    };

                    DbConnect.entObj.Locomotive.Add(locomotiveObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Локомотив добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new LocomotivePage());
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
