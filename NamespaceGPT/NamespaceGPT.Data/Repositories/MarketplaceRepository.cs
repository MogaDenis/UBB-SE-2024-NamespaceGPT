using Microsoft.Data.SqlClient;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using System.Data;

namespace NamespaceGPT.Data.Repositories
{
    public class MarketplaceRepository : IMarketplaceRepository
    {
        private readonly string _connectionString;

        public MarketplaceRepository()
        {
            _connectionString = "Server=LAPTOP-EHFIU8C5\\SQLEXPRESS;Database=ISS;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public int AddMarketplace(Marketplace marketplace)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Marketplace (marketplacename,websiteurl,country) VALUES (@marketplacename, @websiteurl, @country); SELECT SCOPE_IDENTITY()";

            command.Parameters.AddWithValue("@marketplacename", marketplace.Name);
            command.Parameters.AddWithValue("@websiteurl", marketplace.Websiteurl);
            command.Parameters.AddWithValue("@country", marketplace.CountryOfOrigin);

            int newMarketplaceId = Convert.ToInt32(command.ExecuteScalar());

            return newMarketplaceId;
        }

        public bool DeleteMarketplace(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM Marketplace WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Marketplace";

            SqlDataReader reader = command.ExecuteReader();
            List<Marketplace> marketplaces = [];

            while (reader.Read())
            {
                Marketplace marketplace = new()
                {
                    Id = reader.GetInt32(0),
                    Name  = reader.GetString(1),
                    Websiteurl = reader.GetString(2),
                    CountryOfOrigin = reader.GetString(3)
                };

                marketplaces.Add(marketplace);
            }

            return marketplaces;
        }

        public Marketplace? GetMarketplace(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Marketplace WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Marketplace marketplace = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Websiteurl = reader.GetString(2),
                    CountryOfOrigin = reader.GetString(3)
                };

                return marketplace;
            }

            return null;
        }

        public bool UpdateMarketplace(int id, Marketplace marketplace)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Marketplace " +
                                    "SET websiteurl = @websiteurl, marketplacename = @marketplacename, country=@country " +
                                    "WHERE id = @id";

            command.Parameters.AddWithValue("@marketplacename", marketplace.Name);
            command.Parameters.AddWithValue("@websiteurl", marketplace.Websiteurl);
            command.Parameters.AddWithValue("@country", marketplace.CountryOfOrigin);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }
}
