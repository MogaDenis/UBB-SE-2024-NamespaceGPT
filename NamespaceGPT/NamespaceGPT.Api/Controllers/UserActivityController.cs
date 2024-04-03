using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class UserActivityController
    {
        private readonly IUserActivityService _userActivityService;

        public UserActivityController(IUserActivityService userActivityService) 
        {
            _userActivityService = userActivityService ?? throw new ArgumentNullException(nameof(userActivityService));
        }

        public int AddUserActivity(UserActivity userActivity)
        {
            return _userActivityService.AddUserActivity(userActivity);
        }

        public bool DeleteUserActivity(int id)
        {
            return _userActivityService.DeleteUserActivity(id);
        }

        public IEnumerable<UserActivity> GetAllUserActivities()
        {
            return _userActivityService.GetAllUserActivities();
        }

        public IEnumerable<UserActivity> GetUserActivitiesOfUser(int userId)
        {
            return _userActivityService.GetUserActivitiesOfUser(userId);
        }

        public bool UpdateUserActivity(int id, UserActivity userActivity)
        {
            return _userActivityService.UpdateUserActivity(id, userActivity);
        }
    }
}
