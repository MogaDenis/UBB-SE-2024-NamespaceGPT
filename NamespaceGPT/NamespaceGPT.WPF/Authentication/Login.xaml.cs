﻿using Microsoft.IdentityModel.Tokens;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Data.Models;
using NamespaceGPT.WPF.Admin;
using System.Windows;

namespace NamespaceGPT.WPF.Authentication
{
    public partial class Login : Window
    {
        public Login()
        {
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

            if (username.Equals("admin", StringComparison.CurrentCultureIgnoreCase) && password.Equals("admin", StringComparison.CurrentCultureIgnoreCase)) 
            {
                // Navigate to admin dashboard
                AdminDashboard adminDashboard = new();
                adminDashboard.Show();
                Close();
            }

            User newUser = new()
            {
                Username = username,
                Password = password,
            };

            int loggedInUserID = Controller.GetInstance().UserController.LoginUser(newUser);
            if (loggedInUserID == -1)
            {
                return;
            }

            Session.GetInstance().UserId = loggedInUserID;

            // Navigate to the main window

            // Temporarly, for testing purposes...
            MainHomeWindow mainWindow = new();
            mainWindow.Show();

            Session.GetInstance().Frame = mainWindow.MainFrame;
            Close();
        }

        private void SingupButton_Click(object sender, RoutedEventArgs e)
        {
            Register register = new();
            register.Show();
            Close();   
        }
    }
}
