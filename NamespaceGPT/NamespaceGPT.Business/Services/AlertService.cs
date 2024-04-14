using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class AlertService : IAlertService
    {

        private readonly IAlertRepository _alertRepository;

        public AlertService(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository ?? throw new ArgumentNullException(nameof(alertRepository));
        }

        public int AddAlert(IAlert alert)
        {
            return _alertRepository.AddAlert(alert);
        }

        public bool DeleteAlert(int id, IAlert alert)
        {
            return _alertRepository.DeleteAlert(id, alert);
        }

        public IAlert? GetAlert(int alertId)
        {
            return _alertRepository.GetAlert(alertId);
        }

        public IEnumerable<IAlert> GetAllAlerts()
        {
            return _alertRepository.GetAllAlerts();
        }

        public IEnumerable<IAlert> GetAllProductAlerts(int productId)
        {
            return _alertRepository.GetAllProductAlerts(productId);
        }

        public IEnumerable<IAlert> GetAllUserAlerts(int userId)
        {
            return _alertRepository.GetAllUserAlerts(userId);
        }

        public bool UpdateAlert(int id, IAlert alert)
        {
            return _alertRepository.UpdateAlert(id, alert);
        }
    }
}
