using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Collections.ObjectModel;
using UserControl = System.Windows.Controls.UserControl;


namespace NamespaceGPT.WPF
{
    public partial class ProductPage : UserControl
    {
        public Product Product { get; set; }
        private readonly ListingController _listingController;
        private readonly ProductController _productController;
        private readonly MarketplaceController _marketplaceController;

        public ObservableCollection<Marketplace> Marketplaces { get; set; } = [];

        public ProductPage(int productId)
        {
            _listingController = Controller.GetInstance().ListingController;
            _productController = Controller.GetInstance().ProductController;
            _marketplaceController = Controller.GetInstance().MarketplaceController;
            Product = _productController.GetProduct(productId);

            DataContext = this;
            InitializeComponent();
            InitializeProductDetails();
        }

        private void InitializeProductDetails()
        {
            this.ProductName.Text = Product.Name;
            //this.ProductDescription.Text = Product.Description;


            //Get price
            int min_price = 100000000;
            IEnumerable<Listing> listings = _listingController.GetAllListings();
            foreach(Listing listing in listings)
            {
                if(listing.ProductId == Product.Id)
                {
                    if(listing.Price < min_price)
                        min_price = listing.Price; break;
                }
            }
            this.ProductMinPrice.Text = min_price.ToString();

            //available on list
            //select name from marketplace inner join listing on marketplace.id = listing.marketplace
            //inner join product on listing.product = product.id
            HashSet<Marketplace> marketplaceNames = 
                (
            from marketplace in _marketplaceController.GetAllMarketplaces()
            join listing in _listingController.GetAllListings() on marketplace.Id equals listing.MarketplaceId
            join product in _productController.GetAllProducts() on listing.ProductId equals product.Id
            select marketplace)
            .ToHashSet();

            foreach (Marketplace marketplace in marketplaceNames)
            {
                Marketplaces.Add(marketplace);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ReviewButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProductReviewsPage productReviewsPage = new(Product.Id);
            Session.GetInstance().Frame.NavigationService.Navigate(productReviewsPage);
        }
    }
}
