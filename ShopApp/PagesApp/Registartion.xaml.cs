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
    /// Interaction logic for Registartion.xaml
    /// </summary>
    public partial class Registartion : Page
    {
        public Registartion()
        {
            InitializeComponent();
        }

        private void EventLoginRevers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void EventRegistration(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLogin.Text != "" && txtName.Text != "" && txtPassword.Password != "")
                {
                    if (DBConnection.Connection.Logins.Where(x => x.Login == txtLogin.Text).FirstOrDefault() == null)
                    {
                        Users newUser = new Users()
                        {
                            Name = txtName.Text
                        };

                        Logins newLogin = new Logins()
                        {
                            Login = txtLogin.Text,
                            Password = txtPassword.Password,
                            Role_id = Convert.ToInt32(txtRole.Text)
                        };

                        newUser.Logins.Add(newLogin);   
                        DBConnection.Connection.Users.Add(newUser);
                        DBConnection.Connection.SaveChanges();
                        MessageBox.Show("Успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
