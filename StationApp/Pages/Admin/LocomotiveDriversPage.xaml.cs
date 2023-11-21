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
    /// Логика взаимодействия для LocomotiveDriversPage.xaml
    /// </summary>
    public partial class LocomotiveDriversPage : Page
    {
        private List<LocomotiveDriver> allDrivers;
        public LocomotiveDriversPage()
        {
            InitializeComponent();
            
            LocomotiveDriversGrid.ItemsSource = DbConnect.entObj.LocomotiveDriver.ToList();
            allDrivers = DbConnect.entObj.LocomotiveDriver.ToList();  
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            LocomotiveDriversGrid.ItemsSource = DbConnect.entObj.LocomotiveDriver.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddDriverPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void MedicalPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LocomotiveDriversGrid.ItemsSource = null;
            string selectedDate = MedicalPicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.LocomotiveDriver.AsEnumerable().Where(row => row.MedicalInspection.ToString().Contains(selectedDate));
            LocomotiveDriversGrid.ItemsSource = filteredData;
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbGender.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(LocomotiveDriversGrid.ItemsSource);
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

        private void TxbSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            LocomotiveDriversGrid.ItemsSource = null;
            string selectedSalary = TxbSalary.Text;
            var filteredData = DbConnect.entObj.LocomotiveDriver.AsEnumerable().Where(row => row.Salary.ToString().Contains(selectedSalary));
            LocomotiveDriversGrid.ItemsSource = filteredData;
        }
    }
}
