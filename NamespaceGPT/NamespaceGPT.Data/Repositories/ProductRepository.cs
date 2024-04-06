using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using System.Data;

namespace NamespaceGPT.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        //Pentru product attributes am ales ca in baza de date sa fie reprezentat ca string
        //e.g. in DB: attributes(str): attr1;attr2;attr3; 

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
            command.CommandText = "INSERT INTO Product (name,category,description,brand,imageURL, attributes); SELECT SCOPE_INDENTITIY()";

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@category", product.Category);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@imageURL", product.ImageURL);
            command.Parameters.AddWithValue("@attributes", product.Attributes); 


            int newProductID = Convert.ToInt32(command.ExecuteScalar());
            return newProductID;
        }

        public bool DeleteProduct(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM Product WHERE AppProduct.id = @id";

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
            command.CommandText = "SELECT * FROM Product";

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
                    Attributes = ConvertAttributesFromStringToDict(reader.GetString(6))
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
            command.CommandText = "SELECT * FROM Product WHERE AppProduct.id = @id";

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
                    Attributes = ConvertAttributesFromStringToDict(reader.GetString(6))
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
            command.CommandText = "UPDATE Product " +
                                  "SET name = @name, category = @category, description = @description, brand = @brand, imageURL = @imageURL " +
                                  "attributes = @attributes WHERE id = @id";

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@category", product.Category);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@imageURL", product.ImageURL);
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@attribues", product.Attributes); 

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }


        public static IDictionary<string, string> ConvertAttributesFromStringToDict(string string_attributes)
        {
            if(string.IsNullOrEmpty(string_attributes)) throw new ArgumentException("string_attributes cannot be null or empty");


            // string attributes will be represented in the following way: "color:red;weight:200g;height:100mm; ...
            int KEY = 0,
                VALUE = 1;
            IDictionary<string, string> attributes = new Dictionary<string, string>();
            IEnumerable<string> split_attributes = string_attributes.Split(';');


            foreach (string split_attribute in split_attributes)
            {
                string[] keyValue = split_attribute.Split(':');
                if (keyValue.Length == 2)
                {
                    attributes[keyValue[KEY]] = attributes[keyValue[VALUE]];
                }
            }

            return attributes;
        }

        public static string ConvertAttributesFromStringToDict(IDictionary<string,string> dictionary_attributes)
        {
            string attributes = string.Empty;
            
            foreach(KeyValuePair<string,string> pair in dictionary_attributes)
            {
                attributes += pair.Key + ':' + pair.Value + ';'; //e.g. ///;color:black'...
            }

            return attributes;

        }
    }
}
