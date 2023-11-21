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
    /// Логика взаимодействия для AddBrigadePage.xaml
    /// </summary>
    public partial class AddBrigadePage : Page
    {
        public AddBrigadePage()
        {
            InitializeComponent();

            CmbLocomotive.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbLocomotive.SelectedValuePath = "Id";
            CmbLocomotive.DisplayMemberPath = "Id";
        }

        private void BtnAddBrigade_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null)
            {
                MessageBox.Show("Введите название",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbLocomotive.SelectedItem == null)
            {
                MessageBox.Show("Выберите локомотив",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DbConnect.entObj.Brigade.Count(x => x.Name == TxbName.Text) > 0)
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
                        Brigade brigadeObj = new Brigade()
                        {
                            Name = TxbName.Text,
                            IdLocomotive = CmbLocomotive.SelectedIndex+1
                        };

                        DbConnect.entObj.Brigade.Add(brigadeObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Новая бригада добавлена!",
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
