using NamespaceGPT.Business.Services;
using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Api.Controllers
{
    public class AlertController
    {
        private readonly IAlertService _alertService;

        public AlertController(IAlertService alertService)
        {
            _alertService = alertService ?? throw new ArgumentNullException(nameof(alertService));
        }

        public int AddAlert(IAlert alert)
        {
            return _alertService.AddAlert(alert);
        }

        public bool DeleteAlert(int id, IAlert alert)
        {
            return _alertService.DeleteAlert(id, alert);
        }

        public IAlert? getAlert(int alertId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAlert> GetAllAlerts()
        {
            return _alertService.GetAllAlerts();
        }

        public IEnumerable<IAlert> GetAllProductAlerts(int productId)
        {
            return _alertService.GetAllProductAlerts(productId);
        }

        public IEnumerable<IAlert> GetAllUserAlerts(int userId)
        {
            return _alertService.GetAllUserAlerts(userId);
        }

        public bool UpdateAlert(int id, IAlert alert)
        {
            return _alertService.UpdateAlert(id, alert);
        }

    }
}
