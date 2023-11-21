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
    /// Логика взаимодействия для AddRoutePage.xaml
    /// </summary>
    public partial class AddRoutePage : Page
    {
        public AddRoutePage()
        {
            InitializeComponent();

            CmbCategory.SelectedValuePath = "Id";
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.ItemsSource = DbConnect.entObj.RouteCategory.ToList();
        }

        private void BtnAddRoute_Click(object sender, RoutedEventArgs e)
        {
            if (CmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbDeparture.Text == null)
            {
                MessageBox.Show("Введите место",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbArrival.Text == null)
            {
                MessageBox.Show("Введите текст",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Route routeObj = new Route()
                    {
                        DeparturePlace = TxbDeparture.Text,
                        ArrivalPlace=TxbArrival.Text,
                        IdRouteCategory=CmbCategory.SelectedIndex+1
                    };

                    DbConnect.entObj.Route.Add(routeObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Маршрут добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new RoutePage());
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
