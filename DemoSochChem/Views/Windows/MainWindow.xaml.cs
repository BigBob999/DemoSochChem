using DemoSochChem.Views.Pages;
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

namespace DemoSochChem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CompaniesPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CompaniesPage());
        }

        private void ManufacturePage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturePage());
        }

        private void OrdersPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderPage());
        }

        private void Page_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SpecificationPage());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if(e.Content is Page page)
            {
             

                Title = $"Главное окно - {page.Title}";
            }
        }
    }
}
