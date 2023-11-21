using StationApp.AppFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private List<Employee> allItems;

        public EmployeePage()
        {
            InitializeComponent();

            EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
            allItems = DbConnect.entObj.Employee.ToList();

            CmbDepartment.ItemsSource = DbConnect.entObj.Department.ToList();
            CmbDepartment.SelectedValuePath = "Id";
            CmbDepartment.DisplayMemberPath = "Name";
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddEmployeePage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void CmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbDepartment.SelectedItem as Department;
            var items = (select != null) ? allItems.Where(x => x.IdDepartment == select.Id) : allItems;
            EmployeeGrid.ItemsSource = items;
        }

        private void TxbExperience_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeGrid.ItemsSource = null;
            string selectedExperience = TxbExperience.Text;
            var filteredData = DbConnect.entObj.Employee.AsEnumerable().Where(row => row.WorkExperience.ToString().Contains(selectedExperience));
            EmployeeGrid.ItemsSource = filteredData;
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbGender.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(EmployeeGrid.ItemsSource);
            if (selectedGender == "Мужской")
            {
                dataView.Filter = item => ((Employee)item).Gender == "Мужской";
            }
            else if (selectedGender == "Женский")
            {
                dataView.Filter = item => ((Employee)item).Gender == "Женский";
            }
            else
            {
                dataView.Filter = null;
            }
        }

        private void DateOfBirthPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeGrid.ItemsSource = null;
            string selectedDate = DateOfBirthPicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Employee.AsEnumerable().Where(row => row.BirthDate.ToString().Contains(selectedDate));
            EmployeeGrid.ItemsSource = filteredData;
        }

        private void TxbSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeGrid.ItemsSource = null;
            string selectedSalary = TxbSalary.Text;
            var filteredData = DbConnect.entObj.Employee.AsEnumerable().Where(row => row.Salary.ToString().Contains(selectedSalary));
            EmployeeGrid.ItemsSource = filteredData;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var filesForRemoving = EmployeeGrid.SelectedItems.Cast<Employee>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Employee.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
                    }
                    else
                    {
                        EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }
    }
}
