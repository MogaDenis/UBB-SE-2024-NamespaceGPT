﻿using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class ListingService : IListingService
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

        public IEnumerable<Listing> GetAllListingsOfProduct(int productId)
        {
            return _listingRepository.GetAllListingsOfProduct(productId);
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
