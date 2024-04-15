using NamespaceGPT.Api.Controllers;
using GalaSoft.MvvmLight.Command;
using NamespaceGPT.Data.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF.ProductPages
{
    public partial class ProductsByCategoryPage : UserControl
    {
        public List<Product> Products { get; set; }
        private readonly ProductController _productController;
        public ICommand ProductButtonCommand { get; set; } = new RelayCommand<int>(ProductButton_Click);
        public ProductsByCategoryPage(string category)
        {
            _productController = Controller.GetInstance().ProductController;
            Products = _productController.GetAllProducts().Where(product => product.Category == category).ToList();
            
            DataContext = this;
            InitializeComponent();
        }

        private static void ProductButton_Click(int itemId)
        {
            ProductPage productPage = new(itemId);
            Session.GetInstance().Frame.NavigationService.Navigate(productPage);
        }
    }
}
