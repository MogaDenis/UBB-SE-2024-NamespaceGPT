using Microsoft.IdentityModel.Tokens;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using System.Windows;

namespace NamespaceGPT.WPF.Authentication
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void OpenLogin()
        {
            Login login = new();
            login.Show();
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

            Controller.GetInstance().UserController.AddUser(newUser);

            OpenLogin();
            Close();
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            OpenLogin();
        }
    }
}
