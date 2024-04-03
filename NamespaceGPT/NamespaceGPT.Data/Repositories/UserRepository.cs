using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<User> _users;

        public UserRepository()
        {
            _users =
            [
                new User()
                {
                    Id = 1,
                    Username = "Test1",
                },
                new User()
                {
                    Id = 2,
                    Username = "Test2",
                },
                new User()
                {
                    Id = 3,
                    Username = "Test3",
                },
            ];
        }

        public int AddUser(User user)
        {
            _users.Add(user);

            // Here some logic to figure the id...

            return user.Id;
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUser(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);    
        }

        public bool UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
