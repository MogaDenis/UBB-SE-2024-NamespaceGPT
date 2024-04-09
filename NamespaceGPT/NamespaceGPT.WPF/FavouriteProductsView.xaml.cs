using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class FavouriteProductsView : UserControl
    {
        private readonly ProductController _productController;
        private readonly FavouriteProductController _favouriteProductController;
        private readonly int _userId;

        public ObservableCollection<Product> FavouriteProducts { get; set; } = [];

        public FavouriteProductsView(int userId)
        {
            _userId = userId;
            //_productController = Controller.GetInstance().ProductController; 
            //_favouriteProductController = Controller.GetInstance().FavouriteProductController;

            //InitializeFavouriteProductsList();

            //InitializeComponent();

            DataContext = this;
        }

        private void InitializeFavouriteProductsList()
        {
            FavouriteProducts = [];

            var productsIds = new List<int>();

            foreach (var item in _favouriteProductController.GetAllFavouriteProductsOfUser(_userId))
            {
                productsIds.Add(item.ProductId);
            }

            foreach (var item in productsIds) 
            {
                Product? product = _productController.GetProduct(item);

                if (product != null) 
                {
                    FavouriteProducts.Add(product);
                }
            }
        }
    }
}
