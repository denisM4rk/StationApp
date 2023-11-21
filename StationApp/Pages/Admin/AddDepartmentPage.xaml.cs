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
    /// Логика взаимодействия для AddDepartmentPage.xaml
    /// </summary>
    public partial class AddDepartmentPage : Page
    {
        public AddDepartmentPage()
        {
            InitializeComponent();
        }

        private void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null)
            {
                MessageBox.Show("Введите название",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DbConnect.entObj.Department.Count(x => x.Name == TxbName.Text) > 0)
                {
                    MessageBox.Show("Такая бригада уже есть!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        Department departmentObj = new Department()
                        {
                            Name = TxbName.Text
                        };

                        DbConnect.entObj.Department.Add(departmentObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Новый отдел добавлен!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new BrigadePage());
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
