using DemoSochChem.Model;
using DemoSochChem.Views.Windows;
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

namespace DemoSochChem.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManufacturePage.xaml
    /// </summary>
    public partial class ManufacturePage : Page
    {
        string selectedManufactureType;
        private List<Manufacture> _manufacture;
        private List<string> _manufactureTypes = new List<string>()
        {
            "Все",
            "Товар",
            "Не товар"
        };
        public ManufacturePage()
        {
            InitializeComponent();

            FilterCmb.ItemsSource = _manufactureTypes;
            FilterCmb.SelectedIndex = 0;

            LoadData();
        }

        private void RemoveManufacture_Click(object sender, RoutedEventArgs e)
        {
            Manufacture selectedManufacture = (Manufacture)ManufactureLv.SelectedItem;
            if (selectedManufacture != null)
            {
                try
                {

                    App.context.Manufacture.Remove(selectedManufacture);
                    App.context.SaveChanges();
                    MessageBox.Show("Производство успешно удалено.");
                    LoadData();
                }
                catch

                {
                    MessageBox.Show("Невозможно удалить производство");
                }

            }
        }
        private void LoadData()
        {
            _manufacture = App.context.Manufacture.ToList();
            if (selectedManufactureType == "Все")
            {
                ManufactureLv.ItemsSource = _manufacture;
            }
            else
            {
                ManufactureLv.ItemsSource = _manufacture.Where(c => c.IsProduct1 == selectedManufactureType);
            }


        }
        private void EditManufacture_Click(object sender, RoutedEventArgs e)
        {
            Manufacture selectedManufacture = (Manufacture)ManufactureLv.SelectedItem;
            if (selectedManufacture != null)
            {
                AddEditManufacture addManufacture = new AddEditManufacture(selectedManufacture);
                addManufacture.ShowDialog();
            }

            else
            {
                MessageBox.Show("Сначала выберите компанию");
            }
        }

        private void AddManufacture_Click(object sender, RoutedEventArgs e)
        {
            AddEditManufacture addManufacture = new AddEditManufacture();
            if (addManufacture.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedManufactureType = FilterCmb.SelectedItem.ToString();

            LoadData();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            var filteredList = _manufacture.Where(Manufacture => Manufacture.Code.ToLower().Contains(searchString)).ToList();
            ManufactureLv.ItemsSource = filteredList;
        }
    }
}
