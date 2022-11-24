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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void EventLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLogin.Text != "" && txtPassword.Password != "")
                {
                    var DataLogin = DBConnection.Connection.Logins.Where(x => x.Login == txtLogin.Text
                                                                    && x.Password == txtPassword.Password).FirstOrDefault();
                    if(DataLogin != null)
                    {
                        if (DataLogin.Role_id == 1)
                        {
                            NavigationService.Navigate(new Order(DataLogin.Users));
                        }
                        else
                        {
                            NavigationService.Navigate(new AdminFunctions());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void EventRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registartion());
        }
    }
}
