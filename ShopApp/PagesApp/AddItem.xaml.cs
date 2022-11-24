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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public Byte[] image;

        public AddItem()
        {
            InitializeComponent();
        }

        private void EventSelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
            }
        }

        private void EventAddItem(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtPrice.Text != "" && image != null)
                {
                    Items newItem = new Items()
                    {
                        Name = txtName.Text,
                        Price = int.Parse(txtPrice.Text),
                        Image = image,
                        Count = 1
                    };

                    DBConnection.Connection.Items.Add(newItem);
                    DBConnection.Connection.SaveChanges();
                    MessageBox.Show("Успешно!");
                }
                else
                {
                    MessageBox.Show("Заполните все поля!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
