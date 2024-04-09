using NamespaceGPT.Data.Models;
using System.Windows;

namespace NamespaceGPT.WPF
{
    public partial class WindowTemplate : Window
    {
        public WindowTemplate()
        {
            InitializeComponent();
        }

        public void ShowFavouriteProductsView()
        {


            //FavouriteProductsView favouriteProductsView = new(Session.GetInstance().UserId);
            //MainFrame.NavigationService.Navigate(favouriteProductsView);

            //CompareProductsView compareView = new CompareProductsView(p1, p2);
            //MainFrame.NavigationService.Navigate(compareView);

            ProductReviewsPage productReviews = new ProductReviewsPage(1);
            MainFrame.NavigationService.Navigate(productReviews);
        }
    }
}
