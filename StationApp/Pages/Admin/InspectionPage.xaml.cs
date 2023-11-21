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
    /// Логика взаимодействия для InspectionPage.xaml
    /// </summary>
    public partial class InspectionPage : Page
    {
        private List<Inspection> allInspections;

        public InspectionPage()
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddInspectionPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void TxbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            InspectionGrid.ItemsSource = null;
            string selectedPrice = TxbAge.Text;
            var filteredData = DbConnect.entObj.Inspection.AsEnumerable().Where(row => row.LocomotiveAge.ToString().Contains(selectedPrice));
            InspectionGrid.ItemsSource = filteredData;
        }

        private void CmbLocomotive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbLocomotive.SelectedItem as Locomotive;
            var items = (select != null) ? allInspections.Where(x => x.IdLocomotive == select.Id) : allInspections;
            InspectionGrid.ItemsSource = items;
        }

        private void InspectionDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            InspectionGrid.ItemsSource = null;
            string selectedDate = InspectionDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Inspection.AsEnumerable().Where(row => row.DateOfInspection.ToString().Contains(selectedDate));
            InspectionGrid.ItemsSource = filteredData;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (InspectionGrid.SelectedItem != null)
            {
                var filesForRemoving = InspectionGrid.SelectedItems.Cast<Inspection>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Inspection.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        InspectionGrid.ItemsSource = DbConnect.entObj.Inspection.ToList();
                    }
                    else
                    {
                        InspectionGrid.ItemsSource = DbConnect.entObj.Inspection.ToList();
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
