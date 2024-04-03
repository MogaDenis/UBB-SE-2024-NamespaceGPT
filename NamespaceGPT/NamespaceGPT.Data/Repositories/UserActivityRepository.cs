using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Data.Repositories
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly List<UserActivity> _userActivities;

        public UserActivityRepository()
        {
            _userActivities = [];
        }

        public int AddUserActivity(UserActivity userActivity)
        {
            _userActivities.Add(userActivity);

            return userActivity.Id;
        }

        public bool DeleteUserActivity(int id)
        {
            int index = _userActivities.FindIndex(user => user.Id == id);

            if (index == -1)
            {
                return false;
            }

            _userActivities.RemoveAt(index);
            return true;
        }

        public IEnumerable<UserActivity> GetAllUserActivities()
        {
            return _userActivities;
        }

        public IEnumerable<UserActivity> GetUserActivitiesOfUser(int userId)
        {
            return _userActivities.Where(userActivity => userActivity.UserId == userId);
        }

        public bool UpdateUserActivity(int id, UserActivity userActivity)
        {
            int index = _userActivities.FindIndex(user => user.Id == id);

            if (index == -1)
            {
                return false;
            }

            _userActivities[index] = userActivity;  
            return true;
        }
    }
}
