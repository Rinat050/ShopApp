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
    /// Interaction logic for AddItemCount.xaml
    /// </summary>
    public partial class AddItemCount : Page
    {
        public AddItemCount()
        {
            InitializeComponent();
            cbProducts.ItemsSource = DBConnection.Connection.Items.ToList();
        }

        private void EventSave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbProducts.SelectedItem != null && txtCount.Text != "")
                {
                    var product = cbProducts.SelectedItem as Items;
                    product.Count += Convert.ToInt32(txtCount.Text);
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