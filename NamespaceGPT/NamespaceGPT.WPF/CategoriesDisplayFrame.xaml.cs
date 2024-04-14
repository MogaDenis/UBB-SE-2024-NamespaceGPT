using GalaSoft.MvvmLight.CommandWpf;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class CategoriesDisplayFrame : UserControl
    {
        public ICommand DisplayProductsByCategory { get; set; } = new RelayCommand<string>(DisplayProducts);
        private readonly ProductController _productController;
        public List<string> Categories { get; set; }
        public CategoriesDisplayFrame()
        {
            InitializeComponent();
            _productController = Controller.GetInstance().ProductController;
            Categories = getCategories().ToList();
            DataContext = this;
        }
        public List<String> getCategories()
        {
            var products = _productController.GetAllProducts().ToList();
            HashSet<string> categories = [];
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
