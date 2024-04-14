using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class MarketplaceController
    {
        private readonly IMarketplaceService _marketplaceService;

        public MarketplaceController(IMarketplaceService marketplaceService)
        {
            _marketplaceService = marketplaceService ?? throw new ArgumentNullException(nameof(marketplaceService));
        }

        public int Addmarketplace(Marketplace marketplace)
        {
            return _marketplaceService.AddMarketplace(marketplace);
        }

        public bool Deletemarketplace(int id)
        {
            return _marketplaceService.DeleteMarketplace(id);
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            return _marketplaceService.GetAllMarketplaces();
        }

        public Marketplace? Getmarketplace(int id)
        {
            return _marketplaceService.GetMarketplace(id);
        }

        public bool Updatemarketplace(int id, Marketplace marketplace)
        {
            return _marketplaceService.UpdateMarketplace(id, marketplace);
        }
    }
}
