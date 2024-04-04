using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using System.Collections.Generic;

namespace NamespaceGPT.Api.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        public int AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        public Product? GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        public bool UpdateProduct(int id, Product product)
        {
            return _productService.UpdateProduct(id, product);
        }
    }
}
