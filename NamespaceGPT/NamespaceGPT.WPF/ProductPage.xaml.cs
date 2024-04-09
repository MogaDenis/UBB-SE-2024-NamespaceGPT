using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class ProductPage : UserControl
    {
        private readonly int _productId;
        public Product? Product { get; set; }
        private readonly ListingController _listingController;
        private readonly ProductController _productController;
        private readonly MarketplaceController _marketplaceController;

        public ObservableCollection<Marketplace> Marketplaces { get; set; } = [];

        public ProductPage(int productId)
        {
            _productId = productId;
            _listingController = Controller.GetInstance().ListingController;
            _productController = Controller.GetInstance().ProductController;
            _marketplaceController = Controller.GetInstance().MarketplaceController;
            Product = _productController.GetProduct(_productId);

            DataContext = this;
            InitializeComponent();
            InitializeProductDetails();
        }

        private void InitializeProductDetails()
        {
            //Get price
            int min_price = 100000000;
            List<Listing> listings = _listingController.GetAllListings()
                .Where(listing => listing.ProductId == _productId).ToList();

            foreach (Listing listing in listings)
            {
                if (listing.ProductId == _productId)
                {
                    if (listing.Price < min_price)
                        min_price = listing.Price; break;
                }
            }
            ProductMinPrice.Text = min_price.ToString();

            //available on list
            //select name from marketplace inner join listing on marketplace.id = listing.marketplace
            //inner join product on listing.product = product.id
            //HashSet<Marketplace> marketplaceNames =
            //    (
            //from marketplace in _marketplaceController.GetAllMarketplaces()
            //join listing in _listingController.GetAllListings() on marketplace.Id equals listing.MarketplaceId
            //join product in _productController.GetAllProducts() on listing.ProductId equals product.Id
            //select marketplace)
            //.ToHashSet();

            var marketplaces = _marketplaceController.GetAllMarketplaces().Where(marketplace =>
            {
                foreach (Listing listing in listings)
                {
                    if (listing.MarketplaceId == marketplace.Id && listing.ProductId == _productId)
                    {
                        return true;
                    }
                }

                return false;
            });

            foreach (Marketplace marketplace in marketplaces)
            {
                Marketplaces.Add(marketplace);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ReviewButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }

            ProductReviewsPage productReviewsPage = new(Product.Id);
            Session.GetInstance().Frame.NavigationService.Navigate(productReviewsPage);
        }

        private void CompareButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Product? secondProduct = _productController.GetProduct(2);

            if (Product == null || secondProduct == null)
            {
                return;
            }

            CompareProductsView compareProductsView = new(Product, secondProduct);
            Session.GetInstance().Frame.NavigationService.Navigate(compareProductsView);
        }
    }
}
