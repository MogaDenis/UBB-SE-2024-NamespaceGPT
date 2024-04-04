using Microsoft.Data.SqlClient;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = "myConnectionString";
        }

        public int AddProduct(Product product)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO AppProduct (name,category,description,brand,imageURL); SELECT SCOPE_INDENTITIY()";

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@category", product.Category);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@imageURL", product.ImageURL);
            //product.Attributes ? 

            int newProductID = Convert.ToInt32(command.ExecuteScalar());

            return newProductID;
        }

        public bool DeleteProduct(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM AppProduct WHERE AppProduct.id = @id";

            command.Parameters.AddWithValue("@id", id);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;

        }

        public IEnumerable<Product> GetAllProducts()
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM AppProduct";

            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = [];

            while (reader.Read())
            {
                Product product = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Category = reader.GetString(2),
                    Description = reader.GetString(3),
                    Brand = reader.GetString(4),
                    ImageURL = reader.GetString(5),
                    Attributes = [] // ce fac aici?
                };

                products.Add(product);
            }

            return products;
        }

        public Product? GetProduct(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM AppProduct WHERE AppProduct.id = @id";

            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Product product = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Category = reader.GetString(2),
                    Description = reader.GetString(3),
                    Brand = reader.GetString(4),
                    ImageURL = reader.GetString(5),
                    Attributes = [] // ce fac aici?
                };

                return product;
            }

            return null;
        }

        public bool UpdateProduct(int id, Product product)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE AppProduct " +
                                  "SET name = @name, category = @category, description = @description, brand = @brand, imageURL = @imageURL " +
                                  "WHERE id = @id";

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@category", product.Category);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@imageURL", product.ImageURL);
            command.Parameters.AddWithValue("@id", product.Id); 
            // la attribues ce fac ?

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;

        }
    }
}
