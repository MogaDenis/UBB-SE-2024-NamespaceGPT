using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Business.Services;
using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class MainWindow : Window
    {
        private readonly UserController _userController;
        private readonly MarketplaceController _marketplaceController;
        private readonly ListingController _listingController;

        public MainWindow()
        {
            InitializeComponent();

            var userService = new UserService(new UserRepository());
            _userController = new UserController(userService);

            var marketplaceService = new MarketplaceService(new MarketplaceRepository());
            _marketplaceController = new MarketplaceController(marketplaceService);

            var listingService = new ListingService(new ListingRepository());
            _listingController = new ListingController(listingService);
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
    }
}