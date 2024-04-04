using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Repositories.Interfaces
{
    public interface IMarketplaceRepository
    {
        int AddMarketplace(Marketplace marketplace);
        bool DeleteMarketplace(int id);
        bool UpdateMarketplace(int id, Marketplace marketplace);
        IEnumerable<Marketplace> GetAllMarketplaces();
        Marketplace? GetMarketplace(int id);
    }
}
