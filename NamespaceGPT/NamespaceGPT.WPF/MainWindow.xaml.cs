using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Business.Services;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NamespaceGPT.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserController _userController;

        public MainWindow()
        {
            var repository = new UserRepository();
            var service = new UserService(repository);

            _userController = new UserController(service);
            InitializeComponent();

            var users = _userController.GetAllUsers();

            label1.Content = users.ElementAt(0).Username;
            label2.Content = users.ElementAt(1).Username;
            label3.Content = users.ElementAt(2).Username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}