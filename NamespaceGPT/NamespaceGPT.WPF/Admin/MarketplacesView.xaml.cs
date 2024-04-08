using NamespaceGPT.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace NamespaceGPT.WPF.Admin
{
    public partial class MarketplacesView : UserControl
    {
        private readonly MarketplaceController _marketplaceController;

        public MarketplacesView()
        {
            _marketplaceController = Controller.GetInstance().MarketplaceController;
            InitializeComponent();

            MarketplacesDataGrid.ItemsSource = _marketplaceController.GetAllMarketplaces();
        }
    }
}
