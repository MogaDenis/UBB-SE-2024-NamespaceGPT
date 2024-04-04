using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Repositories.Interfaces
{
    public interface IListingRepository
    {
        int AddListing(Listing listing);
        bool DeleteListing(int id);
        bool UpdateListing(int id, Listing listing);
        IEnumerable<Listing> GetAllListings();
        Listing? GetListing(int id);
    }
}
