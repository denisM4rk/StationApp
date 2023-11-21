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
    /// Логика взаимодействия для PassengersCheckPage.xaml
    /// </summary>
    public partial class PassengersCheckPage : Page
    {
        private List<Passenger> allPassengers;

        public PassengersCheckPage()
        {
            InitializeComponent();

            PassengersGrid.ItemsSource = DbConnect.entObj.Passenger.ToList();
            allPassengers = DbConnect.entObj.Passenger.ToList();
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            PassengersGrid.ItemsSource = DbConnect.entObj.Passenger.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void CmbBaggage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbBaggage.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(PassengersGrid.ItemsSource);
            if (selectedGender == "Да")
            {
                dataView.Filter = item => ((Passenger)item).Baggage == "Да";
            }
            else if (selectedGender == "Нет")
            {
                dataView.Filter = item => ((Passenger)item).Baggage == "Нет";
            }
            else
            {
                dataView.Filter = null;
            }
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)CmbGender.SelectedItem).Content.ToString();

            ICollectionView dataView = CollectionViewSource.GetDefaultView(PassengersGrid.ItemsSource);
            if (selectedGender == "Мужской")
            {
                dataView.Filter = item => ((Passenger)item).Gender == "Мужской";
            }
            else if (selectedGender == "Женский")
            {
                dataView.Filter = item => ((Passenger)item).Gender == "Женский";
            }
            else
            {
                dataView.Filter = null;
            }
        }

        private void BirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PassengersGrid.ItemsSource = null;
            string selectedDate = BirthDatePicker.SelectedDate.Value.ToString();
            var filteredData = DbConnect.entObj.Passenger.AsEnumerable().Where(row => row.BirthDate.ToString().Contains(selectedDate));
            PassengersGrid.ItemsSource = filteredData;
        }
    }
}
