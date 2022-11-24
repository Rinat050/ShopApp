using ShopApp.ADOApp;
using ShopApp.ClassApp;
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

namespace ShopApp.PagesApp
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private Orders order;
        private Users currentUser;

        public Order(Users user)
        {
            InitializeComponent();
            lvItems.ItemsSource = DBConnection.Connection.Items.ToList();
            currentUser = user;

            order = DBConnection.Connection.Orders.FirstOrDefault(x => x.User_ID == currentUser.User_ID);

            if (order == null)
            {
                Orders newOrder = new Orders()
                {
                    Users = user
                };

                order = newOrder;

                DBConnection.Connection.Orders.Add(newOrder);
                DBConnection.Connection.SaveChanges();
            }
            else
            {
                var orderItems = DBConnection.Connection.Order_Items.Where(x => x.Order_ID == order.Order_ID).ToList();

                lvOrder.ItemsSource = orderItems.Select(x => x.Items).ToList();
            }
        }

        private void EventSelectItem(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lvItems.SelectedItem != null)
                {
                    var item = lvItems.SelectedItem as Items;

                    var orderItem = new Order_Items()
                    {
                        Orders = order,
                        Items = item
                    };

                    DBConnection.Connection.Order_Items.Add(orderItem);
                    DBConnection.Connection.SaveChanges();

                    var orderItems = DBConnection.Connection.Order_Items.Where(x => x.Order_ID == order.Order_ID).ToList();

                    lvOrder.ItemsSource = orderItems.Select(x => x.Items).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
