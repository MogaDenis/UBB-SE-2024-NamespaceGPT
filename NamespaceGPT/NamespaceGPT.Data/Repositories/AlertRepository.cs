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
    public class AlertRepository : IAlertRepository
    {

        private readonly string _connectionString = "Data Source=MATEI-PC\\SQLEXPRESS;Initial Catalog=ISS_Alert;Integrated Security=True;Encrypt=false;TrustServerCertificate=true;";


        public AlertRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public int AddAlert(IAlert alert)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            switch (alert)
            {
                case BackInStockAlert backInStockAlert:
                    command.CommandText = @"
                INSERT INTO BackInStockAlerts (UserId, ProductId, MarketplaceId) 
                VALUES (@UserId, @ProductId, @MarketplaceId); 
                SELECT SCOPE_IDENTITY();";
                    command.Parameters.AddWithValue("@UserId", backInStockAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", backInStockAlert.ProductId);
                    command.Parameters.AddWithValue("@MarketplaceId", backInStockAlert.MarketplaceId);
                    break;

                case NewProductAlert newProductAlert:
                    command.CommandText = @"
                INSERT INTO NewProductAlerts (UserId, ProductId) 
                VALUES (@UserId, @ProductId); 
                SELECT SCOPE_IDENTITY();";
                    command.Parameters.AddWithValue("@UserId", newProductAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", newProductAlert.ProductId);
                    break;

                case PriceDropAlert priceDropAlert:
                    command.CommandText = @"
                INSERT INTO PriceDropAlerts (UserId, ProductId, OldPrice, NewPrice) 
                VALUES (@UserId, @ProductId, @OldPrice, @NewPrice); 
                SELECT SCOPE_IDENTITY();";
                    command.Parameters.AddWithValue("@UserId", priceDropAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", priceDropAlert.ProductId);
                    command.Parameters.AddWithValue("@OldPrice", priceDropAlert.OldPrice);
                    command.Parameters.AddWithValue("@NewPrice", priceDropAlert.NewPrice);
                    break;

                default:
                    throw new NotImplementedException("Unsupported alert type.");
            }

            int newAlertId = Convert.ToInt32(command.ExecuteScalar());
            return newAlertId;
        }


        public bool DeleteAlert(int id, IAlert alert)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            
            switch(alert)
            {
                case BackInStockAlert backInStockAlert:
                    command.CommandText = "DELETE FROM BackInStockAlerts WHERE BackInStockAlerts.id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    break;

                case NewProductAlert newProductAlert:
                    command.CommandText = "DELETE FROM NewProductAlerts WHERE NewProductAlerts.id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    break;

                case PriceDropAlert priceDropAlert:
                    command.CommandText = "DELETE FROM PriceDropAlerts WHERE PriceDropAlerts.id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    break;

                default:
                    throw new NotImplementedException("Unsupported alert type.");
            }

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public IAlert? getAlert(int alertId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAlert> GetAllAlerts()
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command1 = connection.CreateCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = "SELECT * FROM BackInStockAlerts";

            SqlDataReader reader1 = command1.ExecuteReader();
            List<IAlert> alerts = [];

            while (reader1.Read())
            {
                BackInStockAlert alert = new()
                {
                    Id = reader1.GetInt32(0),
                    UserId = reader1.GetInt32(1),
                    ProductId = reader1.GetInt32(2),
                    MarketplaceId = reader1.GetInt32(3),
                };

                alerts.Add(alert);
            }

            SqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "SELECT * FROM NewProductAlerts";
            command2.CommandType = CommandType.Text;
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                NewProductAlert alert = new()
                {
                    Id = reader2.GetInt32(0),
                    UserId = reader2.GetInt32(1),
                    ProductId = reader2.GetInt32(2),
                };

                alerts.Add(alert);
            }

            SqlCommand command3 = connection.CreateCommand();
            command3.CommandText = "SELECT * FROM PriceDropAlerts";
            SqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                PriceDropAlert alert = new()
                {
                    Id = reader3.GetInt32(0),
                    UserId = reader3.GetInt32(1),
                    ProductId = reader3.GetInt32(2),
                    OldPrice = reader3.GetInt32(3),
                    NewPrice = reader3.GetInt32(4),
                };

                alerts.Add(alert);
            }

            return alerts;
        }

        public IEnumerable<IAlert> GetAllProductAlerts(int productId)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command1 = connection.CreateCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = "SELECT * FROM BackInStockAlerts WHERE ProductId = @productId";
            command1.Parameters.AddWithValue("@productId", productId);

            SqlDataReader reader1 = command1.ExecuteReader();
            List<IAlert> alerts = [];

            while (reader1.Read())
            {
                BackInStockAlert alert = new()
                {
                    Id = reader1.GetInt32(0),
                    UserId = reader1.GetInt32(1),
                    ProductId = reader1.GetInt32(2),
                    MarketplaceId = reader1.GetInt32(3),
                };

                alerts.Add(alert);
            }

            SqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "SELECT * FROM NewProductAlerts WHERE ProductId = @productId";
            SqlDataReader reader2 = command2.ExecuteReader();
            command2.Parameters.AddWithValue("@productId", productId);

            while (reader2.Read())
            {
                NewProductAlert alert = new()
                {
                    Id = reader2.GetInt32(0),
                    UserId = reader2.GetInt32(1),
                    ProductId = reader2.GetInt32(2),
                };

                alerts.Add(alert);
            }

            SqlCommand command3 = connection.CreateCommand();
            command3.CommandText = "SELECT * FROM PriceDropAlerts WHERE ProductId = @productId";
            SqlDataReader reader3 = command3.ExecuteReader();
            command3.Parameters.AddWithValue("@productId", productId);

            while (reader3.Read())
            {
                PriceDropAlert alert = new()
                {
                    Id = reader3.GetInt32(0),
                    UserId = reader3.GetInt32(1),
                    ProductId = reader3.GetInt32(2),
                    OldPrice = reader3.GetInt32(3),
                    NewPrice = reader3.GetInt32(4),
                };

                alerts.Add(alert);
            }

            return alerts;
        }

        public IEnumerable<IAlert> GetAllUserAlerts(int userId)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command1 = connection.CreateCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = "SELECT * FROM BackInStockAlerts WHERE UserId = @userId";
            command1.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader1 = command1.ExecuteReader();
            List<IAlert> alerts = [];

            while (reader1.Read())
            {
                BackInStockAlert alert = new()
                {
                    Id = reader1.GetInt32(0),
                    UserId = reader1.GetInt32(1),
                    ProductId = reader1.GetInt32(2),
                    MarketplaceId = reader1.GetInt32(3),
                };

                alerts.Add(alert);
            }

            SqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "SELECT * FROM NewProductAlerts WHERE UserId = @userId";
            SqlDataReader reader2 = command2.ExecuteReader();
            command2.Parameters.AddWithValue("@UserId", userId);

            while (reader2.Read())
            {
                NewProductAlert alert = new()
                {
                    Id = reader2.GetInt32(0),
                    UserId = reader2.GetInt32(1),
                    ProductId = reader2.GetInt32(2),
                };

                alerts.Add(alert);
            }

            SqlCommand command3 = connection.CreateCommand();
            command3.CommandText = "SELECT * FROM PriceDropAlerts WHERE UserId = @userId";
            SqlDataReader reader3 = command3.ExecuteReader();
            command3.Parameters.AddWithValue("@UserId", userId);

            while (reader3.Read())
            {
                PriceDropAlert alert = new()
                {
                    Id = reader3.GetInt32(0),
                    UserId = reader3.GetInt32(1),
                    ProductId = reader3.GetInt32(2),
                    OldPrice = reader3.GetInt32(3),
                    NewPrice = reader3.GetInt32(4),
                };

                alerts.Add(alert);
            }

            return alerts;
        }

        public bool UpdateAlert(int id, IAlert alert)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (alert is BackInStockAlert backInStockAlert)
                {
                    command.CommandText = "UPDATE BackInStockAlerts " +
                                          "SET UserId = @UserId, " +
                                          "ProductId = @ProductId, " +
                                          "MarketplaceId = @MarketplaceId " +
                                          "WHERE id = @Id";
                    command.Parameters.AddWithValue("@UserId", backInStockAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", backInStockAlert.ProductId);
                    command.Parameters.AddWithValue("@MarketplaceId", backInStockAlert.MarketplaceId);
                    command.Parameters.AddWithValue("@Id", id);
                }
                else if (alert is NewProductAlert newProductAlert)
                {
                    command.CommandText = "UPDATE NewProductAlerts " +
                                          "SET UserId = @UserId, " +
                                          "ProductId = @ProductId " +
                                          "WHERE id = @Id";
                    command.Parameters.AddWithValue("@UserId", newProductAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", newProductAlert.ProductId);
                    command.Parameters.AddWithValue("@Id", id);
                }
                else if (alert is PriceDropAlert priceDropAlert)
                {
                    command.CommandText = "UPDATE PriceDropAlerts " +
                                          "SET UserId = @UserId, " +
                                          "ProductId = @ProductId, " +
                                          "OldPrice = @OldPrice, " +
                                          "NewPrice = @NewPrice " +
                                          "WHERE id = @Id";
                    command.Parameters.AddWithValue("@UserId", priceDropAlert.UserId);
                    command.Parameters.AddWithValue("@ProductId", priceDropAlert.ProductId);
                    command.Parameters.AddWithValue("@OldPrice", priceDropAlert.OldPrice);
                    command.Parameters.AddWithValue("@NewPrice", priceDropAlert.NewPrice);
                    command.Parameters.AddWithValue("@Id", id);
                }
                else
                {
                    throw new NotImplementedException("Unsupported alert type.");
                }

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}
