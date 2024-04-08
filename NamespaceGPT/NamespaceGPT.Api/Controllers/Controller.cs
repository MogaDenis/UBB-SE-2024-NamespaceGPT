using NamespaceGPT.Business.Services;
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
            UserController = new UserController(new UserService(new UserRepository()));
            MarketplaceController = new MarketplaceController(new MarketplaceService(new MarketplaceRepository()));
            ListingController = new ListingController(new ListingService(new ListingRepository()));
            FavouriteProductController = new FavouriteProductController(new FavouriteProductService(new FavouriteProductRepository()));
            ReviewController = new ReviewController(new ReviewService(new ReviewRepository()));
            ProductController = new ProductController(new ProductService(new ProductRepository()));
        }

        public static Controller GetInstance()
        {
            return instance;
        }
    }
}
