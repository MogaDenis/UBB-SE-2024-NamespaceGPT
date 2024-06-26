﻿using GalaSoft.MvvmLight.Command;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using NamespaceGPT.WPF.ProductPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamespaceGPT.WPF
{
    public partial class HomePage : UserControl
    {
        public List<Product> Products { get; set; } = [];
        private readonly ProductController _productController;
        public ICommand ProductButtonCommand { get; set; } = new RelayCommand<int>(ProductButton_Click);

        public HomePage()
        {
            _productController = Controller.GetInstance().ProductController;
            Products = _productController.GetAllProducts().ToList();

            DataContext = this;
            InitializeComponent();
        }

        private static void ProductButton_Click(int itemId)
        {
            ProductPage productPage = new(itemId);
            Session.GetInstance().Frame.NavigationService.Navigate(productPage);
        }
    }
}
