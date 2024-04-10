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
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class MainHomeWindow : Window
    {
        private readonly ProductController _productController;
        public List<string> Categories { get; set; }
        public ICommand DisplayProductsByCategory { get; set; } = new RelayCommand<string>(ButtonClicked);
        public MainHomeWindow()
        {
            InitializeComponent();
            SearchListbox.Visibility = Visibility.Collapsed;
            _productController = Controller.GetInstance().ProductController;
            Categories = GetCategories().Take(3).ToList();

            DataContext = this;

            HomePage homepage = new();
            MainFrame.NavigationService.Navigate(homepage);
        }

        public List<string> GetCategories()
        {
            List<Product> products = _productController.GetAllProducts().ToList();
            HashSet<string> categories = [];
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
            var filteredProducts = _productController.GetAllProducts().ToList().Where(p => p.Name.ToLower().Contains(searchText)).ToList();
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
                if (filteredProducts.Count != 0)
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
