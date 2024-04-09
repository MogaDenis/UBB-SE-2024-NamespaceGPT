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
            _productController = Controller.GetInstance().ProductController;
            _favouriteProductController = Controller.GetInstance().FavouriteProductController;
            InitializeFavouriteProductsList();

            InitializeComponent();

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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Product p1 = new Product
            {
                Id = 1,
                Name = "Ultra HD 4K TV",
                Category = "Electronics",
                Description = "A 65-inch Ultra HD 4K television with HDR support and smart TV features.",
                Brand = "SuperVision",
                ImageURL = "https://www.shutterstock.com/image-photo/tv-flat-screen-lcd-plasma-260nw-314401364.jpg",
                Attributes = new Dictionary<string, string>
    {
        { "Screen Size", "65 inches" },
        { "Resolution", "3840 x 2160" },
        { "Refresh Rate", "120Hz" },
        { "HDMI Ports", "4" },
        { "Smart TV", "Yes" },
        { "Color", "White" },
        { "Display Technology", "OLED" },
        { "Energy Efficiency", "A+" },
        { "Connectivity", "Cabke" },
        { "Weight", "56 lbs" },
        { "Warranty", "2 years" },
        { "Price", "$1299" }
    }
            };
            Product p2 = new Product
            {
                Id = 2,
                Name = "Bluetooth Headphones",
                Category = "Audio",
                Description = "Wireless Bluetooth headphones with noise cancellation and 20 hours of battery life.",
                Brand = "ClearSound",
                ImageURL = "https://m.media-amazon.com/images/I/61-g7m+90eL._AC_SL1500_.jpg",
                Attributes = new Dictionary<string, string>
    {
        { "Connectivity", "Bluetooth 5.0" },
        { "Battery Life", "20 hours" },
        { "Refresh Rate", "N/A" },
        { "Wireless Range", "33 feet" },
        { "Noise Cancellation", "Active" },
        { "Color", "Black" },
        { "Weight", "0.64 lbs" },
        { "Warranty", "1 year" },
        { "Water Resistance", "IPX4" },
        { "Price", "$199" }
    }
            };

            CompareProductsView compareView = new CompareProductsView(p1, p2);
            Session.GetInstance().Frame.NavigationService.Navigate(compareView);
        }
    }
}
