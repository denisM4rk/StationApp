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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent();

            CmbBrigade.SelectedValuePath = "Id";
            CmbBrigade.DisplayMemberPath = "Name";
            CmbBrigade.ItemsSource = DbConnect.entObj.Brigade.ToList();

            CmbDepartment.SelectedValuePath = "Id";
            CmbDepartment.DisplayMemberPath = "Name";
            CmbDepartment.ItemsSource = DbConnect.entObj.Department.ToList();
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (CmbBrigade.SelectedItem == null)
            {
                MessageBox.Show("Выберите бригаду",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbGender.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbBrigade.SelectedItem == null)
            {
                MessageBox.Show("Выберите отдел",
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
            else if (BirthPicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbName.Text == null)
            {
                MessageBox.Show("Выберите имя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbExperience.Text == null)
            {
                MessageBox.Show("Выберите опыт",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Employee employeeObj = new Employee()
                    {
                        Name = TxbName.Text,
                        BirthDate = Convert.ToDateTime(BirthPicker.SelectedDate),
                        Gender = CmbGender.Text,
                        Salary = Convert.ToInt32(TxbSalary.Text),
                        WorkExperience = Convert.ToInt32(TxbExperience.Text),
                        IdBrigade = CmbBrigade.SelectedIndex+1,
                        IdDepartment = CmbDepartment.SelectedIndex+1
                    };

                    DbConnect.entObj.Employee.Add(employeeObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Работник добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new EmployeePage());
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
