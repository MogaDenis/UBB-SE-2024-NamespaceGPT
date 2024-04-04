using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Business.Services
{
    public class ProductService : IProductService
    {
        public int AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product? GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
