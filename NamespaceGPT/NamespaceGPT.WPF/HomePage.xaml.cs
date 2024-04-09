using GalaSoft.MvvmLight.Command;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class HomePage : UserControl
    {

        public List<Product> Products { get; set; } = [];
        private readonly ProductController _productController;
        public ICommand ButtonCommand { get; set; } = new RelayCommand<int>(ButtonClicked);

        public HomePage()
        {
            _productController = Controller.GetInstance().ProductController;
            Products = _productController.GetAllProducts().ToList();

            DataContext = this;
            InitializeComponent();
        }

        private void ClickedFavoritesButton(object sender, RoutedEventArgs e)
        {
            FavouriteProductsView favouriteProductsView = new(Session.GetInstance().UserId);
            Session.GetInstance().Frame.NavigationService.Navigate(favouriteProductsView);
        }

        private static void ButtonClicked(int itemId)
        {
            
        }
    }
}
