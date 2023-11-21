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
    /// Логика взаимодействия для AddDriverPage.xaml
    /// </summary>
    public partial class AddDriverPage : Page
    {
        public AddDriverPage()
        {
            InitializeComponent();
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (CmbGender.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол",
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
            else if (TxbSalary.Text == null)
            {
                MessageBox.Show("Введите зарплату",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (MedicalDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату медосмотра",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    LocomotiveDriver driverObj = new LocomotiveDriver()
                    {
                        Name=TxbName.Text,
                        MedicalInspection=Convert.ToDateTime(MedicalDatePicker.SelectedDate),
                        Gender=CmbGender.Text,
                        Salary=Convert.ToDecimal(TxbSalary.Text)
                    };

                    DbConnect.entObj.LocomotiveDriver.Add(driverObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Водитель добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new LocomotiveDriversPage());
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
