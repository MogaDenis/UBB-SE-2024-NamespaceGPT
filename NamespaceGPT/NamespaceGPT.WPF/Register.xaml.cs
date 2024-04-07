using Microsoft.IdentityModel.Tokens;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows;

namespace NamespaceGPT.WPF
{ 
    public partial class Register : Window
    {
        private UserController _userController;

        public Register(UserController userController)
        {
            _userController = userController;

            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
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

            _userController.AddUser(newUser);

            this.Close();
        }
    }
}
