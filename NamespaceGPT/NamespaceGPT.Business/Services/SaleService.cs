using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository) 
        {
            _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));    
        }

        public int AddSale(Sale sale)
        {
            return _saleRepository.AddSale(sale);
        }

        public bool DeleteSale(int id)
        {
            return _saleRepository.DeleteSale(id);
        }

        public IEnumerable<Sale> GetAllPurchasesOfUser(int userId)
        {
            return _saleRepository.GetAllPurchasesOfUser(userId);
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _saleRepository.GetAllSales();
        }

        public IEnumerable<Sale> GetAllSalesOfListing(int listingId)
        {
            return _saleRepository.GetAllSalesOfListing(listingId);
        }

        public Sale? GetSale(int id)
        {
            return _saleRepository.GetSale(id);
        }

        public bool UpdateSale(int id, Sale sale)
        {
            return _saleRepository.UpdateSale(id, sale);
        }
    }
}
