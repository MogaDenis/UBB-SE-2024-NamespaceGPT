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
    public partial class ProductsView : UserControl
    {
        private readonly ProductController _productController;

        public ProductsView()
        {
            _productController = Controller.GetInstance().ProductController; 

            InitializeComponent();
        }
    }
}
