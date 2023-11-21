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
    /// Логика взаимодействия для BrigadeCheckPage.xaml
    /// </summary>
    public partial class BrigadeCheckPage : Page
    {
        public BrigadeCheckPage()
        {
            InitializeComponent();

            BrigadeGrid.ItemsSource = DbConnect.entObj.Brigade.ToList();
            DepartmentGrid.ItemsSource = DbConnect.entObj.Department.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void TxbDepartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartmentGrid.ItemsSource = null;
            string selectedPrice = TxbDepartment.Text;
            var filteredData = DbConnect.entObj.Department.AsEnumerable().Where(row => row.Name.ToString().Contains(selectedPrice));
            DepartmentGrid.ItemsSource = filteredData;
        }

        private void TxbBrigade_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrigadeGrid.ItemsSource = null;
            string selectedPrice = TxbBrigade.Text;
            var filteredData = DbConnect.entObj.Brigade.AsEnumerable().Where(row => row.Name.ToString().Contains(selectedPrice));
            BrigadeGrid.ItemsSource = filteredData;
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            BrigadeGrid.ItemsSource = DbConnect.entObj.Brigade.ToList();
            DepartmentGrid.ItemsSource = DbConnect.entObj.Department.ToList();
        }
    }
}
