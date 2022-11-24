using Microsoft.Win32;
using ShopApp.ADOApp;
using ShopApp.ClassApp;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddMeal.xaml
    /// </summary>
    public partial class AddMeal : Page
    {
        public AddMeal()
        {
            InitializeComponent();
            cbRecepts.ItemsSource = DBConnection.Connection.Recepts.ToList();
        }

        private void EventReceptChange(object sender, SelectionChangedEventArgs e)
        {
            if (cbRecepts.SelectedItem != null)
            {
                var recept = cbRecepts.SelectedItem as Recepts;
                var products = DBConnection.Connection.Recept_Items.Where(x => x.Recept_ID == recept.Recept_ID);

                List<Items> listProduct = new List<Items>();

                foreach (var item in products)
                {
                    listProduct.Add(DBConnection.Connection.Items.FirstOrDefault(x => x.Item_ID == item.Item_ID));
                }

                lvProducts.ItemsSource = listProduct;
            }        
        }

        private void EventCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text != "" && cbRecepts.SelectedItem != null)
                {
                    foreach (var item in lvProducts.Items)
                    {
                        if ((item as Items).Count == 0)
                        {
                            MessageBox.Show($"Не хватает {(item as Items).Name}");
                            return;
                        }
                    }

                    DBConnection.Connection.Meals.Add(new Meals()
                    {
                        Name = txtName.Text,
                        Recept_ID = (cbRecepts.SelectedItem as Recepts).Recept_ID
                    });

                    foreach (var item in lvProducts.Items)
                    {
                        (item as Items).Count--;
                    }

                    DBConnection.Connection.SaveChanges();
                    MessageBox.Show("Успешно!");
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}