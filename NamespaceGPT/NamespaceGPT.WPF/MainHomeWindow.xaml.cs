using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using GalaSoft.MvvmLight.Command;
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
using System.Windows.Shapes;

namespace NamespaceGPT.WPF
{
    /// <summary>
    /// Interaction logic for MainHomeWindow.xaml
    /// </summary>
    public partial class MainHomeWindow : Window
    {
        ProductController productController;
        public List<String> Categories { get; set; }
        public ICommand DisplayProductsByCategory { get; set; } = new RelayCommand<string>(ButtonClicked);
        public MainHomeWindow()
        {
            InitializeComponent();
            SearchListbox.Visibility = Visibility.Collapsed;
            productController = Controller.GetInstance().ProductController;
            Categories = getCategories().Take(3).ToList();
            DataContext = this;
            HomePage homepage = new HomePage();
            MainFrame.NavigationService.Navigate(homepage);
        }

        public List<String> getCategories()
        {
            List<Product> products = new List<Product>();
            products=productController.GetAllProducts().ToList();
            HashSet<String> categories = new HashSet<String>();
            foreach (Product product in products)
            {
                categories.Add(product.Category);
            }
            return categories.ToList();
        }

        private static void ButtonClicked(string category)
        {
            ProductsByCategoryPage productsfilteredPage = new(category);
            Session.GetInstance().Frame.NavigationService.Navigate(productsfilteredPage);
        }

        private void CategoriesDisplay(object sender, RoutedEventArgs e)
        {
            CategoriesDisplayFrame categoriesDisplay = new();
            Session.GetInstance().Frame.NavigationService.Navigate(categoriesDisplay);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            var filteredProducts = productController.GetAllProducts().ToList().Where(p => p.Name.ToLower().Contains(searchText)).ToList();
            if (searchText != "")
            {
                SearchListbox.Items.Clear();

                // Populate the ListBox with the filtered products
                foreach (var product in filteredProducts)
                {
                    string itemstring = product.Name + " " + product.Brand;
                    SearchListbox.Items.Add(itemstring);
                }

                // Show or hide the ListBox based on whether there are filtered products
                if (filteredProducts.Any())
                {
                    SearchListbox.Visibility = Visibility.Visible;
                }
                else
                {
                    SearchListbox.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                SearchListbox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
