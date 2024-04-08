using NamespaceGPT.Api.Controllers;
using System.Windows.Controls;

namespace NamespaceGPT.WPF.Admin
{
    public partial class UsersView : UserControl
    {
        private readonly UserController _userController;

        public UsersView()
        {
            _userController = Controller.GetInstance().UserController;
            InitializeComponent();

            UsersDataGrid.ItemsSource = _userController.GetAllUsers();
        }
    }
}
