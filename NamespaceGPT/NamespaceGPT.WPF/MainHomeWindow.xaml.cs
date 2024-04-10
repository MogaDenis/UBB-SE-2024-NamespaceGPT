using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class MainHomeWindow : Window
    {
        private readonly ProductController _productController;
        public List<string> Categories { get; set; }
        public MainHomeWindow()
        {
            InitializeComponent();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
