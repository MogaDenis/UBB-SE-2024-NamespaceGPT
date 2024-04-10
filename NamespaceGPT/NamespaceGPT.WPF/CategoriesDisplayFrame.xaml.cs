using GalaSoft.MvvmLight.CommandWpf;
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
    /// Interaction logic for CategoriesDisplayFrame.xaml
    /// </summary>
    public partial class CategoriesDisplayFrame : UserControl
    {
        public ICommand DisplayProductsByCategory { get; set; } = new RelayCommand<string>(DisplayProducts);
        ProductController productController;
        public List<String> Categories { get; set; }
        public CategoriesDisplayFrame()
        {
            InitializeComponent();
            productController = Controller.GetInstance().ProductController;
            Categories = getCategories().ToList();
            DataContext = this;
        }
        public List<String> getCategories()
        {
            List<Product> products = new List<Product>();
            products = productController.GetAllProducts().ToList();
            HashSet<String> categories = new HashSet<String>();
            foreach (Product product in products)
            {
                categories.Add(product.Category);
            }
            return categories.ToList();
        }
        private static void DisplayProducts(string category)
        {
            ProductsByCategoryPage productsfilteredPage = new(category);
            Session.GetInstance().Frame.NavigationService.Navigate(productsfilteredPage);
        }
    }
}
