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
    /// Interaction logic for AddRecept.xaml
    /// </summary>
    public partial class AddRecept : Page
    {
        byte[] image;

        public AddRecept()
        {
            InitializeComponent();
            cbProducts.ItemsSource = DBConnection.Connection.Items.ToList();
        }

        private void EventAddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbProducts.SelectedItem != null)
                {
                    if (!lvProducts.Items.Contains((cbProducts.SelectedItem) as Items))
                    {
                        lvProducts.Items.Add((cbProducts.SelectedItem) as Items);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void EventCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvProducts.Items.Count != 0 && txtName.Text != "" && image != null)
                {
                    Recepts newRecept = new Recepts()
                    {
                        Name = txtName.Text,
                        Image = image
                    };

                    DBConnection.Connection.Recepts.Add(newRecept);
                    DBConnection.Connection.SaveChanges();

                    foreach (var item in lvProducts.Items)
                    {
                        DBConnection.Connection.Recept_Items.Add(new Recept_Items()
                        {
                            Recept_ID = newRecept.Recept_ID,
                            Item_ID = (item as Items).Item_ID
                        });
                    }

                    DBConnection.Connection.SaveChanges();
                    MessageBox.Show("Успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EventSelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
            }
        }
    }
}
