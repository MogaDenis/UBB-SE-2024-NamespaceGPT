using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        public int AddUser(User user)
        {
            return _userService.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }

        public User? GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        public bool UpdateUser(int id, User user)
        {
            return _userService.UpdateUser(id, user);
        }
    }
}
