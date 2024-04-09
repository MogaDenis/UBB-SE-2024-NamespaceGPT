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
        public MainHomeWindow()
        {
            InitializeComponent();
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
