using NamespaceGPT.Business.Services;
using NamespaceGPT.Common.ConfigurationManager;
using NamespaceGPT.Data.Repositories;

namespace NamespaceGPT.Api.Controllers
{
    public class Controller
    {
        public UserController UserController { get; }
        public MarketplaceController MarketplaceController { get; }
        public ListingController ListingController { get; }
        public FavouriteProductController FavouriteProductController { get; }
        public ReviewController ReviewController { get; }
        public ProductController ProductController { get; }

        private static readonly Controller instance = new();

        private Controller()
        {
            IConfigurationManager configurationManager = new ConfigurationManager();

            UserController = new UserController(new UserService(new UserRepository(configurationManager)));
            MarketplaceController = new MarketplaceController(new MarketplaceService(new MarketplaceRepository(configurationManager)));
            ListingController = new ListingController(new ListingService(new ListingRepository(configurationManager)));
            FavouriteProductController = new FavouriteProductController(new FavouriteProductService(new FavouriteProductRepository(configurationManager)));
            ReviewController = new ReviewController(new ReviewService(new ReviewRepository(configurationManager)));
            ProductController = new ProductController(new ProductService(new ProductRepository(configurationManager)));
        }

        public static Controller GetInstance()
        {
            return instance;
        }
    }
}
