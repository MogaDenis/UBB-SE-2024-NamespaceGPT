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
            FavouriteProductsView favouriteProductsView = new(Session.GetInstance().UserId);
            MainFrame.NavigationService.Navigate(favouriteProductsView);
        }
    }
}
