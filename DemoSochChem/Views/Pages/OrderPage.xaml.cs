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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        string selectedOrderType;
        private List<Order> _order;
        public OrderPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            OrderLv.ItemsSource = App.context.Order.ToList();

        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrderWindow addOrder = new AddEditOrderWindow();
            if (addOrder.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = (Order)OrderLv.SelectedItem;
            if (selectedOrder != null)
            {
                AddEditOrderWindow addOrder = new AddEditOrderWindow(selectedOrder);
                addOrder.ShowDialog();
            }

            else
            {
                MessageBox.Show("Сначала выберите компанию");
            }
        }

        private void Removeorder_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = (Order)OrderLv.SelectedItem;
            if (selectedOrder != null)
            {
                try
                {

                    App.context.Order.Remove(selectedOrder);
                    App.context.SaveChanges();
                    MessageBox.Show("Заказ успешно удалено.");
                    LoadData();
                }
                catch

                {
                    MessageBox.Show("Невозможно удалить заказ");
                }

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

            //if (string.IsNullOrEmpty(SearchTb.Text))
            //{
            //    OrderLv.ItemsSource = App.context.Order.ToList();
            //}
            //else
            //{
            //    var query = App.context.Order.AsQueryable();
            //    if (!string.IsNullOrEmpty(SearchTb.Text) && int.TryParse(SearchTb.Text, out int price))
            //        query = query.Where(n => n.Number.Contains(SearchTb.Text.ToLower()));
            //    if (!string.IsNullOrEmpty(PriceTb.Text) && decimal.TryParse(PriceTb.Text, out decimal price))
            //    {
            //        query = query.Where(p => p.Price == price);
            //    }
            //    OrderLv.ItemsSource = query.ToList();
            //}
        }


        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
