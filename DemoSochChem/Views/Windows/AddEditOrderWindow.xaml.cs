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
    /// Логика взаимодействия для AddEditOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : Window
    {
        private readonly Order _currentOrder;
        public AddEditOrderWindow()
        {
            InitializeComponent();
            Title = "Добавление заказа";
            AddOrderBtn.Visibility = Visibility.Visible;
            EditOrderBtn.Visibility = Visibility.Collapsed;

        }

        public AddEditOrderWindow(Order selectedOrder)
        {
            InitializeComponent();
            _currentOrder = selectedOrder;
            Title = "Редактирование данных заказа";
            EditOrderBtn.Visibility = Visibility.Visible;
            AddOrderBtn.Visibility = Visibility.Collapsed;

            DataContext = _currentOrder;
        }
      

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())


                MessageBox.Show("Данные заказа успешно обновлены");


            {
                Order newOrder = new Order()
                {
                    Number = Convert.ToInt32(NumTb.Text),
                    Date = DateDp.SelectedDate.Value,
                    TotalPrice = Convert.ToInt32(AmountTb.Text)

                };
                App.context.Order.Add(newOrder);
                App.context.SaveChanges();
                MessageBox.Show("Заказ успешно добавлен");
                DialogResult = true;
            }

        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(NumTb.Text))
            {
                MessageBox.Show("Введите номер заказа");
                NumTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DateDp.Text))
            {
                MessageBox.Show("Введите дату");
                DateDp.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(AmountTb.Text))
            {
                MessageBox.Show("Введите сумму");
                AmountTb.Focus();
                return false;
            }
            return true;
        }
        }
}
