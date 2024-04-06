﻿using Microsoft.Data.SqlClient;
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
    public class ListingRepository : IListingRepository
    {
        private readonly string _connectionString;

        ListingRepository()
        {
            _connectionString = "Server=DESKTOP-DASUQ97\\SQLEXPRESS;Database=NamespaceGPT;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public int AddListing(Listing listing)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Listing (product, marketplace,price) VALUES (@product, @marketplace, @price); SELECT SCOPE_IDENTITY()";

            command.Parameters.AddWithValue("@product", listing.ProductId);
            command.Parameters.AddWithValue("@marketplace", listing.MarketplaceId);
            command.Parameters.AddWithValue("@price", listing.Price);

            int newListingId = Convert.ToInt32(command.ExecuteScalar());

            return newListingId;
        }

        public bool DeleteListing(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM Listing WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Listing";

            SqlDataReader reader = command.ExecuteReader();
            List<Listing> listings = [];

            while (reader.Read())
            {
                Listing listing = new()
                {
                    Id = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    MarketplaceId = reader.GetInt32(2),
                    Price = reader.GetFloat(3)
                };

                listings.Add(listing);
            }

            return listings;
        }

        public Listing? GetListing(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Listing WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Listing listing = new()
                {
                    Id = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    MarketplaceId = reader.GetInt32(2),
                    Price = reader.GetFloat(3)
                };

                return listing;
            }

            return null;
        }

        public bool UpdateListing(int id, Listing listing)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Listing " +
                                    "SET product = @product, marketplace = @marketplace, price=@price " +
                                    "WHERE id = @id";

            command.Parameters.AddWithValue("@product", listing.ProductId);
            command.Parameters.AddWithValue("@marketplace", listing.MarketplaceId);
            command.Parameters.AddWithValue("@price", listing.Price);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }
}