using NamespaceGPT.Api.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NamespaceGPT.WPF
{
    /// <summary>
    /// Interaction logic for ReviewsView.xaml
    /// </summary>
    public partial class ReviewsView : UserControl
    {
        private readonly ReviewController _reviewController;

        public ReviewsView(ReviewController reviewController)
        {
            _reviewController = reviewController;
            InitializeComponent();
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id))
            {
                ReviewsDataGrid.ItemsSource = _reviewController.GetReviewsForProduct(id);
            }
            else
            {
                return;
            }
        }
    }
}
