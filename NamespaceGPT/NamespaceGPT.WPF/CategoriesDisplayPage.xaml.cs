using GalaSoft.MvvmLight.CommandWpf;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using NamespaceGPT.WPF.ProductPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class CategoriesDisplayPage : UserControl
    {
        public ICommand DisplayProductsByCategoryButtonCommand { get; set; } = new RelayCommand<string>(DisplayProductsByCategoryButton_Click);
        private readonly ProductController _productController;
        public List<string> Categories { get; set; }

        public CategoriesDisplayPage()
        {
            InitializeComponent();
            _productController = Controller.GetInstance().ProductController;
            Categories = GetCategories().ToList();
            DataContext = this;
        }

        private List<string> GetCategories()
        {
            var products = _productController.GetAllProducts().ToList();

            HashSet<string> categories = [];
            foreach (Product product in products)
            {
                categories.Add(product.Category);
            }

            return categories.ToList();
        }

        private static void DisplayProductsByCategoryButton_Click(string category)
        {
            ProductsByCategoryPage productsfilteredPage = new(category);
            Session.GetInstance().Frame.NavigationService.Navigate(productsfilteredPage);
        }
    }
}
