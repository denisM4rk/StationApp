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
    /// Логика взаимодействия для BrigadePage.xaml
    /// </summary>
    public partial class BrigadePage : Page
    {
        public BrigadePage()
        {
            InitializeComponent();

            BrigadeGrid.ItemsSource = DbConnect.entObj.Brigade.ToList();
            DepartmentGrid.ItemsSource = DbConnect.entObj.Department.ToList();
        }

        private void BtnAddBrigade_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddBrigadePage());
        }

        private void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddDepartmentPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }

        private void TxbBrigade_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartmentGrid.ItemsSource = null;
            string selectedPrice = TxbDepartment.Text;
            var filteredData = DbConnect.entObj.Department.AsEnumerable().Where(row => row.Name.ToString().Contains(selectedPrice));
            DepartmentGrid.ItemsSource = filteredData;
        }

        private void TxbDepartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrigadeGrid.ItemsSource = null;
            string selectedPrice = TxbBrigade.Text;
            var filteredData = DbConnect.entObj.Brigade.AsEnumerable().Where(row => row.Name.ToString().Contains(selectedPrice));
            BrigadeGrid.ItemsSource = filteredData;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentGrid.SelectedItem != null)
            {
                var filesForRemoving = DepartmentGrid.SelectedItems.Cast<Department>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Department.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        DepartmentGrid.ItemsSource = DbConnect.entObj.Department.ToList();
                    }
                    else
                    {
                        DepartmentGrid.ItemsSource = DbConnect.entObj.Department.ToList();
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
            else if(BrigadeGrid.SelectedItem!=null)
            {
                var filesForRemoving = BrigadeGrid.SelectedItems.Cast<Brigade>().ToList();
                try
                {
                    var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        DbConnect.entObj.Brigade.RemoveRange(filesForRemoving);
                        DbConnect.entObj.SaveChanges();
                        MessageBox.Show("Данные удалены!",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                        BrigadeGrid.ItemsSource = DbConnect.entObj.Brigade.ToList();
                    }
                    else
                    {
                        BrigadeGrid.ItemsSource = DbConnect.entObj.Brigade.ToList();
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
