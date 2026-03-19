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
    /// Логика взаимодействия для CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : Page
    {
        private List<Company> _companies;
        public CompaniesPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            AddEditCompany addCompany = new AddEditCompany();
            if (addCompany.ShowDialog() == true)
            {
                LoadData();
            }

        }

        private void EditCompany_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniesLv.SelectedItem;
            if (selectedCompany != null)
            {
                AddEditCompany addEditCompany = new AddEditCompany(selectedCompany);
                addEditCompany.ShowDialog();
            }

            else
            {
                MessageBox.Show("Сначала выберите компанию");
            }

        }

        private void RemoveCompany_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniesLv.SelectedItem;
            if (selectedCompany != null)
            {
                try
                {

                    App.context.Company.Remove(selectedCompany);
                    App.context.SaveChanges();
                    MessageBox.Show("Компания успешно удалена.");
                    LoadData();
                }
                catch

                {
                    MessageBox.Show("Невозможно удалить компанию");
                }
               
            }
        }
        private void LoadData()
        {
            _companies = App.context.Company.ToList();
            CompaniesLv.ItemsSource = _companies;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if(string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            var filteredList = _companies.Where(Company => Company.Name.ToLower().Contains(searchString) ||
          Company.Insurance.ToLower().Contains(searchString) ||
          Company.Adress.ToLower().Contains(searchString) ||
          Company.Phone.ToLower().Contains(searchString) ).ToList();
            CompaniesLv.ItemsSource =filteredList;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
