using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IUserActivityRepository _userActivityRepository;

        public UserActivityService(IUserActivityRepository userActivityRepository) 
        {
            _userActivityRepository = userActivityRepository ?? throw new ArgumentNullException(nameof(userActivityRepository));
        }

        public int AddUserActivity(UserActivity userActivity)
        {
            return _userActivityRepository.AddUserActivity(userActivity);
        }

        public bool DeleteUserActivity(int id)
        {
            return _userActivityRepository.DeleteUserActivity(id);
        }

        public IEnumerable<UserActivity> GetAllUserActivities()
        {
            return _userActivityRepository.GetAllUserActivities();
        }

        public IEnumerable<UserActivity> GetUserActivitiesOfUser(int userId)
        {
            return _userActivityRepository.GetUserActivitiesOfUser(userId);
        }

        public bool UpdateUserActivity(int id, UserActivity userActivity)
        {
            return _userActivityRepository.UpdateUserActivity(id, userActivity);
        }
    }
}
