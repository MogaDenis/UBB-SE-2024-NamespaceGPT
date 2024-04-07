using Microsoft.IdentityModel.Tokens;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows;

namespace NamespaceGPT.WPF
{
    public partial class Login : Window
    {
        private UserController _userController;

        public Login(UserController userController)
        {
            _userController = userController;   

            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return;
            }

            User newUser = new()
            {
                Username = username,
                Password = password,
            };

            int loggedInUserID = _userController.LoginUser(newUser);

            if (loggedInUserID != -1) 
            {
                LogInLabel.Content = "YESS!!!";
            }
        }
    }
}
