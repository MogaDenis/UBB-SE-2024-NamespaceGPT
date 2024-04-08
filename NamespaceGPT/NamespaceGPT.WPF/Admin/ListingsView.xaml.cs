using NamespaceGPT.Api.Controllers;
using System.Windows.Controls;

namespace NamespaceGPT.WPF.Admin
{
    public partial class ListingsView : UserControl
    {
        private readonly ListingController _listingController;

        public ListingsView()
        {
            _listingController = Controller.GetInstance().ListingController;
            InitializeComponent();

            ListingsDataGrid.ItemsSource = _listingController.GetAllListings();
        }
    }
}
