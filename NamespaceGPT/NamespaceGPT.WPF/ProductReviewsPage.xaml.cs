using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public partial class ProductReviewsPage : UserControl
    {
        private readonly ProductController _productController;
        private readonly ReviewController _reviewController;
        private readonly UserController _userController;
        private readonly int _productId;
        public Product? Product { get; set; }

        public ObservableCollection<dynamic> Reviews { get; set; } = new ObservableCollection<dynamic>();

        public ProductReviewsPage(int productId)
        {
            _productId = productId;
            _productController = Controller.GetInstance().ProductController;
            _reviewController = Controller.GetInstance().ReviewController;
            _userController = Controller.GetInstance().UserController;
            InitializeReviewsList();
            InitializeComponent();
            DataContext = this;
            Product = _productController.GetProduct(productId);
        }

        private void InitializeReviewsList()
        {
            var reviews = _reviewController.GetReviewsForProduct(_productId);
            var users=_userController.GetAllUsers();
            var updatedReviews = from review in reviews
                                 where review.ProductId == _productId
                                 join user in users
                                 on review.UserId equals user.Id
                                 select new
                                 {
                                     Username = user.Username,
                                     Title = review.Title,
                                     Description = review.Description
                                 };
            Reviews.Clear();
            foreach (var review in updatedReviews)
            {
                Reviews.Add(review);
            }
        }
    }
}
