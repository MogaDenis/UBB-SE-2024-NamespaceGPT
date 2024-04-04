using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Business.Services
{
    internal class MarketplaceService : IMarketplaceService
    {
        private readonly IMarketplaceRepository _marketplacerepository;

        public MarketplaceService(IMarketplaceRepository marketplacerepository)
        {
            _marketplacerepository = marketplacerepository ?? throw new ArgumentNullException(nameof(marketplacerepository));
        }

        public int AddMarketplace(Marketplace marketplace)
        {
           return _marketplacerepository.AddMarketplace(marketplace);
        }

        public bool DeleteMarketplace(int id)
        {
            return _marketplacerepository.DeleteMarketplace(id);
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            return _marketplacerepository.GetAllMarketplaces();
        }

        public Marketplace? GetMarketplace(int id)
        {
            return _marketplacerepository.GetMarketplace(id);
        }

        public bool UpdateMarketplace(int id, Marketplace marketplace)
        {
            return _marketplacerepository.UpdateMarketplace(id, marketplace);   
        }
    }
}
