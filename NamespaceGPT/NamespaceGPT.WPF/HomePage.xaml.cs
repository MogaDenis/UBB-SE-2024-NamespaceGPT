using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
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

namespace NamespaceGPT.WPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {

        public List<Product> Products { get; set; }
        ProductController productController;
        public HomePage()
        {
            productController = Controller.GetInstance().ProductController;
            Products = productController.GetAllProducts().ToList();
            DataContext = this;
            InitializeComponent();
        }

        private void ClickedFavoritesButton(object sender, RoutedEventArgs e)
        {
            FavouriteProductsView favouriteProductsView = new FavouriteProductsView(1);
            ((MainHomeWindow)App.Current.MainWindow).MainFrame.Navigate(favouriteProductsView);
        }
    }
}
