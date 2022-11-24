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
    /// Interaction logic for AdminFunctions.xaml
    /// </summary>
    public partial class AdminFunctions : Page
    {
        public AdminFunctions()
        {
            InitializeComponent();
        }

        private void EventAddNewItem(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItem());
        }

        private void EventAddItemCount(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItemCount());
        }

        private void EventAddNewRecept(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRecept());
        }

        private void EventAddNewMeal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMeal());
        }
    }
}
