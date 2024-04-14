using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class ListingController
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService));
        }

        public int Addlisting(Listing listing)
        {
            return _listingService.AddListing(listing);
        }

        public bool Deletelisting(int id)
        {
            return _listingService.DeleteListing(id);
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _listingService.GetAllListings();
        }

        public IEnumerable<Listing> GetAllListingsOfProduct(int productId)
        {
            return _listingService.GetAllListingsOfProduct(productId);
        }

        public Listing? Getlisting(int id)
        {
            return _listingService.GetListing(id);
        }

        public bool Updatelisting(int id, Listing listing)
        {
            return _listingService.UpdateListing(id, listing);
        }
    }
}
