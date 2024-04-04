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
    internal class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository ?? throw new ArgumentNullException(nameof(listingRepository));
        }

        public int AddListing(Listing listing)
        {
            return _listingRepository.AddListing(listing);
        }

        public bool DeleteListing(int id)
        {
            return (_listingRepository.DeleteListing(id));
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _listingRepository.GetAllListings();
        }

        public Listing? GetListing(int id)
        {
            return _listingRepository.GetListing(id);
        }

        public bool UpdateListing(int id, Listing listing)
        {
            return _listingRepository.UpdateListing(id, listing);
        }
    }
}
