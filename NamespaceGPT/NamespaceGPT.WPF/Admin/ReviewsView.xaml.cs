using NamespaceGPT.Api.Controllers;
using System.Windows.Controls;

namespace NamespaceGPT.WPF.Admin
{
    public partial class ReviewsView : UserControl
    {
        private readonly ReviewController _reviewController;

        public ReviewsView()
        {
            _reviewController = Controller.GetInstance().ReviewController;
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
