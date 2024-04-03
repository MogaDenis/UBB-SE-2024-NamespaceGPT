using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class SaleController
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        }

        public int AddSale(Sale sale)
        {
            return _saleService.AddSale(sale);
        }

        public bool DeleteSale(int id)
        {
            return _saleService.DeleteSale(id);
        }

        public IEnumerable<Sale> GetAllPurchasesOfUser(int userId)
        {
            return _saleService.GetAllPurchasesOfUser(userId);
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _saleService.GetAllSales();
        }

        public IEnumerable<Sale> GetAllSalesOfListing(int listingId)
        {
            return _saleService.GetAllSalesOfListing(listingId);
        }

        public Sale? GetSale(int id)
        {
            return _saleService.GetSale(id);
        }

        public bool UpdateSale(int id, Sale sale)
        {
            return _saleService.UpdateSale(id, sale);
        }
    }
}
