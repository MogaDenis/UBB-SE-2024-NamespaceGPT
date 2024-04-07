using NamespaceGPT.Business.Services;
using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class FavouriteProductController
    {
        private readonly IFavouriteProductService _favouriteProductService;

        public FavouriteProductController(IFavouriteProductService favouriteProductService)
        {
            _favouriteProductService = favouriteProductService;
        }

        public int AddFavouriteProduct(FavouriteProduct favouriteProduct)
        {
            return _favouriteProductService.AddFavouriteProduct(favouriteProduct);
        }

        public bool DeleteFavouriteProductFromUser(FavouriteProduct favouriteProduct)
        {
            return _favouriteProductService.DeleteFavouriteProductFromUser(favouriteProduct);
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProducts()
        {
            return _favouriteProductService.GetAllFavouriteProducts();
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProductsOfUser(int userId)
        {
            return _favouriteProductService.GetAllFavouriteProductsOfUser(userId);
        }

        public IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId)
        {
            return _favouriteProductService.GetAllUserIdsWhoMarkedProductAsFavourite(productId);
        }

        public FavouriteProduct? GetFavouriteProduct(int id)
        {
            return _favouriteProductService.GetFavouriteProduct(id);
        }
    }
}
