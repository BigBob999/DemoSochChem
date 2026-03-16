using DemoSochChem.Model;
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
using System.Windows.Shapes;

namespace DemoSochChem.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCompany.xaml
    /// </summary>
    public partial class AddEditCompany : Window
    {
        private readonly Company _currentCompany;
        // контруктор для режима "добавление компании"
        public AddEditCompany()
        {
            InitializeComponent();
            Title = "Добавление компании";
            AddCompanyBtn.Visibility=Visibility.Visible;
            EditCompanyBtn.Visibility=Visibility.Collapsed;
        }
        // контруктор для режима "редактирование компании"
        public AddEditCompany(Company selectedCompany)
        {
            InitializeComponent();
            _currentCompany = selectedCompany;
            Title = "Редактирование данных компании";
            EditCompanyBtn.Visibility=Visibility.Visible;
            AddCompanyBtn.Visibility=Visibility.Collapsed;

            DataContext = _currentCompany;
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
          if(Validate())

            {
                Company newCompany = new Company()
                {
                    Name= NameTb.Text,
                    Insurance = IncuranceTb.Text,
                    Phone = PhoneTb.Text,
                    Adress= AddressTb.Text,
                    IsCustomer = IsCustomerCb.IsChecked.Value,
                    IsManufacture = IsManufactureCb.IsChecked.Value
                  
                };
            }



        }
        private bool Validate()
        {
            if(string.IsNullOrWhiteSpace(NameTb.Text) )
            {
                MessageBox.Show("Введите название компании");
                NameTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(IncuranceTb.Text))
            {
                MessageBox.Show("Введите ИНН");
                IncuranceTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                MessageBox.Show("Введите телефон");
                PhoneTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(AddressTb.Text))
            {
                MessageBox.Show("Введите адрес");
                AddressTb.Focus();
                return false;
            }
            if(!IsCustomerCb.IsChecked.Value && !IsManufactureCb.IsChecked.Value)
            {
                MessageBox.Show("Выберите хотя бы один пункт");
                IsCustomerCb.Focus();
                return false;
            }
            return true;
        }
    }
}
