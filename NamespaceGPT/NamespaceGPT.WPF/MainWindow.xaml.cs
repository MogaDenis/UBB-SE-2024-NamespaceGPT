using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Business.Services;
using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Repositories;
using NamespaceGPT.Data.Repositories.Interfaces;
using System.Windows;

namespace NamespaceGPT.WPF
{
    public partial class MainWindow : Window
    {
        private readonly UserController _userController;
        private readonly MarketplaceController _marketplaceController;
        private readonly ListingController _listingController;
        private readonly FavouriteProductController _favouriteProductController;
        private readonly ReviewController _reviewController;
        private readonly ProductController _productController;

        public MainWindow()
        {
            InitializeComponent();

            var userService = new UserService(new UserRepository());
            _userController = new UserController(userService);

            var marketplaceService = new MarketplaceService(new MarketplaceRepository());
            _marketplaceController = new MarketplaceController(marketplaceService);

            var listingService = new ListingService(new ListingRepository());
            _listingController = new ListingController(listingService);

            var favouriteProductService = new FavouriteProductService(new FavouriteProductRepository());
            _favouriteProductController = new FavouriteProductController(favouriteProductService);

            var reviewService= new ReviewService(new ReviewRepository());
            _reviewController = new ReviewController(reviewService);

            var productService = new ProductService(new ProductRepository());
            _productController = new ProductController(productService);
        }

        private void ShowUsers_Click(object sender, RoutedEventArgs e) 
        {
            UsersView usersView = new(_userController);
            MainFrame.NavigationService.Navigate(usersView);
        }

        private void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsView productsView = new();
            MainFrame.NavigationService.Navigate(productsView);
        }

        private void ShowListings_Click(object sender, RoutedEventArgs e)
        {
            ListingsView listingsView = new(_listingController);
            MainFrame.NavigationService.Navigate(listingsView);
        }

        private void ShowMarketplaces_Click(object sender, RoutedEventArgs e)
        {
            MarketplacesView marketplacesView = new(_marketplaceController);
            MainFrame.NavigationService.Navigate(marketplacesView);
        }

        private void ShowRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new(_userController);

            register.Show();

            //MainFrame.NavigationService.Navigate(register);
        }

        private void ShowLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new(_userController);

            login.Show();

            //MainFrame.NavigationService.Navigate(login);
        }

        private void ShowFavouriteProducts_Click(object sender, RoutedEventArgs e)
        {
            FavouriteProductsView favouriteProductsView = new(7, _productController, _favouriteProductController);
            MainFrame.NavigationService.Navigate(favouriteProductsView);
        }


    }
}