using NamespaceGPT.Api.Controllers;
using GalaSoft.MvvmLight.Command;
using NamespaceGPT.Data.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class ProductsByCategoryPage : UserControl
    {
        public List<Product> Products { get; set; }
        private readonly ProductController _productController;
        public ICommand ButtonCommand { get; set; } = new RelayCommand<int>(ButtonClicked);
        public ProductsByCategoryPage(string category)
        {
            _productController = Controller.GetInstance().ProductController;
            Products = _productController.GetAllProducts().Where(product => product.Category == category).ToList();
            
            DataContext = this;
            InitializeComponent();
        }

        private static void ButtonClicked(int itemId)
        {
            ProductPage productPage = new(itemId);
            Session.GetInstance().Frame.NavigationService.Navigate(productPage);
        }
    }
}
