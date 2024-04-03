using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales;

        public SaleRepository()
        {
            _sales = [];
        }

        public int AddSale(Sale sale)
        {
            _sales.Add(sale);

            return sale.Id;
        }

        public bool DeleteSale(int id)
        {
            int index = _sales.FindIndex(sale => sale.Id == id);

            if (index == -1) 
            {
                return false;
            }

            _sales.RemoveAt(index);
            return true;
        }

        public IEnumerable<Sale> GetAllPurchasesOfUser(int userId)
        {
            return _sales.Where(sale => sale.BuyerId == userId);    
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _sales;
        }

        public IEnumerable<Sale> GetAllSalesOfListing(int listingId)
        {
            return _sales.Where(sale => sale.ListingId == listingId);
        }

        public Sale? GetSale(int id)
        {
            return _sales.FirstOrDefault(sale => sale.Id == id);
        }

        public bool UpdateSale(int id, Sale sale)
        {
            int index = _sales.FindIndex(sale => sale.Id == id);

            if (index == -1)
            {
                return false;
            }

            _sales[index] = sale;
            return true;
        }
    }
}
