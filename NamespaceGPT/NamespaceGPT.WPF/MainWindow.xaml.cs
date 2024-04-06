using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Business.Services;
using NamespaceGPT.Data.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class MainWindow : Window
    {
        private readonly UserController _userController;

        public MainWindow()
        {
            InitializeComponent();

            var userService = new UserService(new UserRepository());
            _userController = new UserController(userService);
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
            ListingsView listingsView = new();
            MainFrame.NavigationService.Navigate(listingsView);
        }

        private void ShowMarketplaces_Click(object sender, RoutedEventArgs e)
        {
            MarketplacesView marketplacesView = new();
            MainFrame.NavigationService.Navigate(marketplacesView);
        }
    }
}