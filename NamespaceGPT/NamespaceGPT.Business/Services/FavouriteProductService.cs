using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class FavouriteProductService : IFavouriteProductService
    {
        private readonly IFavouriteProductRepository _favouriteProductRepository;

        public FavouriteProductService(IFavouriteProductRepository favouriteProductRepository)
        {
            _favouriteProductRepository = favouriteProductRepository ?? throw new ArgumentNullException(nameof(favouriteProductRepository));
        }

        public int AddFavouriteProduct(FavouriteProduct favouriteProduct)
        {
            return _favouriteProductRepository.AddFavouriteProduct(favouriteProduct);
        }

        public bool DeleteFavouriteProductFromUser(FavouriteProduct favouriteProduct)
        {
            return _favouriteProductRepository.DeleteFavouriteProductFromUser(favouriteProduct);
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProducts()
        {
            return _favouriteProductRepository.GetAllFavouriteProducts();
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProductsOfUser(int userId)
        {
            return _favouriteProductRepository.GetAllFavouriteProductsOfUser(userId);
        }

        public IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId)
        {
            return _favouriteProductRepository.GetAllUserIdsWhoMarkedProductAsFavourite(productId);
        }

        public FavouriteProduct? GetFavouriteProduct(int id)
        {
            return _favouriteProductRepository.GetFavouriteProduct(id);
        }
    }
}
