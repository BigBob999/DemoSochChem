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
    /// Логика взаимодействия для AddEditManufacture.xaml
    /// </summary>
    public partial class AddEditManufacture : Window
    {
        private readonly Manufacture _currentManufacture;
        public AddEditManufacture()
        {
            InitializeComponent();
            Title = "Добавление производства";
            AddManufactureBtn.Visibility = Visibility.Visible;
            EditManufactureBtn.Visibility = Visibility.Collapsed;

            MaterialCmb.SelectedValuePath = "Id";
            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.ItemsSource = App.context.Material.ToList();

        }
        public AddEditManufacture(Manufacture selectedManufacure)
        {
            InitializeComponent();
            _currentManufacture = selectedManufacure;
            Title = "Редактирование данных компании";
            EditManufactureBtn.Visibility = Visibility.Visible;
            AddManufactureBtn.Visibility = Visibility.Collapsed;

            MaterialCmb.SelectedValuePath = "Id";
            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.ItemsSource = App.context.Material.ToList();

            DataContext = _currentManufacture;
        }
        private void AddManufactureBtn_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())


                MessageBox.Show("Данные компании успешно обновлены");


            {
                Manufacture newManufacture = new Manufacture()
                {
                    Material = MaterialCmb.SelectedItem as Material,
                    Code = CodeTb.Text,
                    
                    IsProduct = IsProductCb.IsChecked.Value

                };
                App.context.Manufacture.Add(newManufacture);
                App.context.SaveChanges();
                MessageBox.Show("Производство успешно добавлено");
                DialogResult = true;
            }



        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(MaterialCmb.Text))
            {
                MessageBox.Show("Введите название компании");
                MaterialCmb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(CodeTb.Text))
            {
                MessageBox.Show("Введите артикула");
                CodeTb.Focus();
                return false;
            }
           
          
            return true;
        }

        private void EditManufactureBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
