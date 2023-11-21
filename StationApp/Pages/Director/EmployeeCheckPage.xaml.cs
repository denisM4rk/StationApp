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

namespace StationApp.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для EmployeeCheckPage.xaml
    /// </summary>
    public partial class EmployeeCheckPage : Page
    {
        private List<Employee> allItems;
        public EmployeeCheckPage()
        {
            InitializeComponent();

            EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
            allItems = DbConnect.entObj.Employee.ToList();

            CmbDepartment.ItemsSource = DbConnect.entObj.Department.ToList();
            CmbDepartment.SelectedValuePath = "Id";
            CmbDepartment.DisplayMemberPath = "Name";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = DbConnect.entObj.Employee.ToList();
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

        private void TxbExperience_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeGrid.ItemsSource = null;
            string selectedExperience = TxbExperience.Text;
            var filteredData = DbConnect.entObj.Employee.AsEnumerable().Where(row => row.WorkExperience.ToString().Contains(selectedExperience));
            EmployeeGrid.ItemsSource = filteredData;
        }

        private void CmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbDepartment.SelectedItem as Department;
            var items = (select != null) ? allItems.Where(x => x.IdDepartment == select.Id) : allItems;
            EmployeeGrid.ItemsSource = items;
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
    }
}
