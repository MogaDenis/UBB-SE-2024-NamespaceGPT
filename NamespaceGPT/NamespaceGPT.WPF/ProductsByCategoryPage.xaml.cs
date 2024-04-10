using NamespaceGPT.Api.Controllers;
using GalaSoft.MvvmLight.Command;
using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NamespaceGPT.WPF
{
    /// <summary>
    /// Interaction logic for ProductsByCategoryPage.xaml
    /// </summary>
    public partial class ProductsByCategoryPage : UserControl
    {
        public List<Product> Products { get; set; }
        private readonly ProductController _productController;
        public ICommand ButtonCommand { get; set; } = new RelayCommand<int>(ButtonClicked);
        public ProductsByCategoryPage(string category)
        {
            Products=new List<Product>();
            _productController = Controller.GetInstance().ProductController;
            List<Product> allproducts = _productController.GetAllProducts().ToList();
            allproducts.RemoveAll(x => x.Category != category);
            Products=allproducts;
            DataContext = this;
            InitializeComponent();
        }

        private static void ButtonClicked(int itemId)
        {
            ProductPage productPage = new(itemId);
            Session.GetInstance().Frame.NavigationService.Navigate(productPage);
        }
    }
}
