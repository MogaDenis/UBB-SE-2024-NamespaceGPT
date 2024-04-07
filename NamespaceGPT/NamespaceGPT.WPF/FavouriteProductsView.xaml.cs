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

        public ObservableCollection<Product> FavouriteProducts { get; set; }

        public FavouriteProductsView(int userId, ProductController productController, FavouriteProductController favouriteProductController)
        {
            _userId = userId;
            _productController = productController; 
            _favouriteProductController = favouriteProductController;

            InitializeFavouriteProductsList();

            InitializeComponent();

            //FavouriteProducts = new ObservableCollection<Product>() 
            //{ 
            //    new() { Id = 1, Name = "Product 1" },
            //    new() { Id = 2, Name = "Product 2" },
            //    new() { Id = 3, Name = "Product 3" }              
            //};

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
