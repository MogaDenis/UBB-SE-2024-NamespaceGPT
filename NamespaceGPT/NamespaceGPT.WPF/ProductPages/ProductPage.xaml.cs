﻿using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NamespaceGPT.WPF.ProductPages
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
            int lowestPrice = int.MaxValue;
            List<Listing> listings = _listingController.GetAllListingsOfProduct(_productId).ToList();


            foreach (Listing listing in listings)
            {
                if (listing.Price < lowestPrice)
                {
                    lowestPrice = listing.Price;
                    break;
                }
            }
            if (lowestPrice < int.MaxValue)
            {
                ProductMinPrice.Text = lowestPrice.ToString();
            }
            else
            {
                ProductMinPrice.Text = "Unknown";
            }

            var marketplaces = _marketplaceController.GetAllMarketplaces().Where(marketplace =>
            {
                foreach (Listing listing in listings)
                {
                    if (listing.MarketplaceId == marketplace.Id)
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

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }

            ProductReviewsPage productReviewsPage = new(Product.Id);
            Session.GetInstance().Frame.NavigationService.Navigate(productReviewsPage);
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            // For demonstration purpose only...
            Product? secondProduct = _productController.GetProduct(2);

            if (Product == null || secondProduct == null)
            {
                return;
            }

            CompareProductsView compareProductsView = new(Product, secondProduct);
            Session.GetInstance().Frame.NavigationService.Navigate(compareProductsView);
        }

        private void FavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            var favouriteProductsOfUser = Controller.GetInstance().FavouriteProductController
                .GetAllFavouriteProductsOfUser(Session.GetInstance().UserId);

            foreach (FavouriteProduct existingFavouriteProduct in favouriteProductsOfUser)
            {
                if (existingFavouriteProduct.ProductId == _productId)
                {
                    MessageBox.Show("That product is already marked as favourite!");
                    return;
                }
            }

            FavouriteProduct newFavouriteProduct = new()
            {
                UserId = Session.GetInstance().UserId,
                ProductId = _productId
            };

            Controller.GetInstance().FavouriteProductController.AddFavouriteProduct(newFavouriteProduct);
            MessageBox.Show("Successfully added to favourites!");
        }
    }
}
