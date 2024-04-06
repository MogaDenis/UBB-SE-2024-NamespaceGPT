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
namespace NamespaceGPT.WPF
{
    public partial class UsersView : UserControl
    {
        private readonly UserController _userController;

        public UsersView(UserController userController)
        {
            _userController = userController;
            InitializeComponent();

            UsersDataGrid.ItemsSource = _userController.GetAllUsers();
        }
    }
}
