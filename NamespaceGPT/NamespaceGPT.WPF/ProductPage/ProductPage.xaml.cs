using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows.Controls;
using System.Windows.Forms;


namespace NamespaceGPT.WPF.ProductPage
{
    public partial class ProductPage : UserControl
    {
        private readonly int _userId;
        private readonly int _productId;
        Product product;
        private readonly ListingController _listingController;
        private readonly ProductController _productController;
        private readonly MarketplaceController _marketplaceController;

        public ProductPage(int productId)
        {
            _userId = userId;
            _productId = productId;
            _listingController = Controller.GetInstance().ListingController;
            _productController = Controller.GetInstance().ProductController;
            _marketplaceController = Controller.GetInstance().MarketplaceController;
            product = _productController.GetProduct(_userId);

            InitializeComponent();
            InitializeProductDetails();
        }

        private void InitializeProductDetails()
        {
            this.ProductName.Text = product.Name;
            this.ProductDescription.Text = product.Description;


            //Get price
            double min_price = 100000000;
            IEnumerable<Listing> lisitngs = _listingController.GetAllListings();
            foreach(Listing listing in lisitngs)
            {
                if(listing.ProductId == _productId)
                {
                    if(listing.Price < min_price)
                        min_price = listing.Price; break;
                }
            }
            this.ProductPrice.Text = min_price.ToString();

            //available on list
            //select name from marketplace inner join listing on marketplace.id = listing.marketplace
            //inner join product on listing.product = product.id
            List<string> marketplaceNames = 
                (
            from marketplace in _marketplaceController.GetAllMarketplaces()
            join listing in _listingController.GetAllListings() on marketplace.Id equals listing.MarketplaceId
            join product in _productController.GetAllProducts() on listing.ProductId equals product.Id
            select marketplace.Name)
            .ToList();

            this.AvailableList.AddRange(marketplaceNames); 
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
