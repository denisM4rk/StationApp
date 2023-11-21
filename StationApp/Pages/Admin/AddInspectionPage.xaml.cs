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
    /// Логика взаимодействия для AddInspectionPage.xaml
    /// </summary>
    public partial class AddInspectionPage : Page
    {
        public AddInspectionPage()
        {
            InitializeComponent();

            CmbLocomotive.SelectedValuePath = "Id";
            CmbLocomotive.DisplayMemberPath = "Id";
            CmbLocomotive.ItemsSource = DbConnect.entObj.Locomotive.ToList();
        }

        private void BtnAddInspection_Click(object sender, RoutedEventArgs e)
        {
            if (CmbLocomotive.SelectedItem == null)
            {
                MessageBox.Show("Выберите локомотив",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbAge.Text == null)
            {
                MessageBox.Show("Введите возраст локомотива",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            if (InspectionPicker.SelectedDate == null)
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
                    Inspection inspectionObj = new Inspection()
                    {
                        LocomotiveAge = Convert.ToInt32(TxbAge.Text),
                        DateOfInspection = Convert.ToDateTime(InspectionPicker.SelectedDate),
                        IdLocomotive = CmbLocomotive.SelectedIndex+1
                    };

                    DbConnect.entObj.Inspection.Add(inspectionObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Техосмотр добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new InspectionPage());
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
