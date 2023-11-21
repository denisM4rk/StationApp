﻿using StationApp.AppFiles;
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
    /// Логика взаимодействия для PassedTicketsCheckPage.xaml
    /// </summary>
    public partial class PassedTicketsCheckPage : Page
    {
        private List<Ticket> allTickets;
        public PassedTicketsCheckPage()
        {
            InitializeComponent();

            allTickets = DbConnect.entObj.Ticket.ToList();

            CmbRoute.ItemsSource = DbConnect.entObj.Route.ToList();
            CmbRoute.SelectedValuePath = "Id";
            CmbRoute.DisplayMemberPath = "Id";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainDirectorPage());
        }

        private void CmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbRoute.SelectedItem as Route;
            var items = (select != null) ? allTickets.Where(x => x.IdRoute == select.Id) : allTickets;
            int count = DbConnect.entObj.Ticket.Count(x => x.ArePassed == "Да");
            TxbQuantity.Text = count.ToString();
        }
    }
}
