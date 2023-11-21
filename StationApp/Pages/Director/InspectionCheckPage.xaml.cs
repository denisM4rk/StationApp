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

namespace StationApp.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для InspectionCheckPage.xaml
    /// </summary>
    public partial class InspectionCheckPage : Page
    {
        private List<Inspection> allInspections;

        public InspectionCheckPage()
        {
            InitializeComponent();

            InspectionGrid.ItemsSource = DbConnect.entObj.Inspection.ToList();
            allInspections = DbConnect.entObj.Inspection.ToList();

            CmbLocomotive.ItemsSource = DbConnect.entObj.Locomotive.ToList();
            CmbLocomotive.SelectedValuePath = "Id";
            CmbLocomotive.DisplayMemberPath = "Id";
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            InspectionGrid.ItemsSource = DbConnect.entObj.Inspection.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void CmbLocomotive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbLocomotive.SelectedItem as Locomotive;
            var items = (select != null) ? allInspections.Where(x => x.IdLocomotive == select.Id) : allInspections;
            InspectionGrid.ItemsSource = items;
        }

        private void TxbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            InspectionGrid.ItemsSource = null;
            string selectedPrice = TxbAge.Text;
            var filteredData = DbConnect.entObj.Inspection.AsEnumerable().Where(row => row.LocomotiveAge.ToString().Contains(selectedPrice));
            InspectionGrid.ItemsSource = filteredData;
        }

        private void InspectionDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            InspectionGrid.ItemsSource = null;
            string selectedDate = InspectionDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Inspection.AsEnumerable().Where(row => row.DateOfInspection.ToString().Contains(selectedDate));
            InspectionGrid.ItemsSource = filteredData;
        }
    }
}
