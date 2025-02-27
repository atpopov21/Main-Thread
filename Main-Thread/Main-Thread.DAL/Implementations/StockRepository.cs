using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Data;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Implementations
{
    public class StockRepository : IStockRepository
    {
        private readonly DbContext _context = new DbContext();

        // CREATE
        public async Task CreateStockAsync(Stock newStock)
        {
            if (newStock is not null)
            {
                _context.Stocks.Add(newStock);

                string query = $"INSERT INTO [Stocks] (ProductName, Price, Quantity, Category, Rating, BusinessId) VALUES (@ProductName, @Price, @Quantity, @Category, @Rating, @BusinessId)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@ProductName", newStock.ProductName);
                    command.Parameters.AddWithValue("@Price", newStock.Price);
                    command.Parameters.AddWithValue("@Quantity", newStock.Quantity);
                    command.Parameters.AddWithValue("@Category", newStock.Category);
                    command.Parameters.AddWithValue("@Rating", newStock.Rating);
                    command.Parameters.AddWithValue("@BusinessId", newStock.BusinessId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateStockAsync(Stock updatedStock)
        {
            Stock stock = _context.Stocks.FirstOrDefault(x => x.Id == updatedStock.Id);

            if (stock is not null)
            {
                stock.ProductName = updatedStock.ProductName;
                stock.Price = updatedStock.Price;
                stock.Quantity = updatedStock.Quantity;
                stock.Rating = updatedStock.Rating;
                stock.BusinessId = updatedStock.BusinessId;
                
                string query = $"UPDATE [Stocks] SET [ProductName] = @ProductName, [Price] = @Price, [Quantity] = @Quantity, [Category] = @Category, [Rating] = @Rating, [BusinessId] = @BusinessId WHERE [StockId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@ProductName", updatedStock.ProductName);
                    command.Parameters.AddWithValue("@Price", updatedStock.Price);
                    command.Parameters.AddWithValue("@Quantity", updatedStock.Quantity);
                    command.Parameters.AddWithValue("@Category", updatedStock.Category);
                    command.Parameters.AddWithValue("@Rating", updatedStock.Rating);
                    command.Parameters.AddWithValue("@BusinessId", updatedStock.BusinessId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteStockAsync(Stock deletedStock)
        {
            if (deletedStock is not null)
            {
                string query = $"DELETE FROM [Stocks] WHERE [StockId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@Id", deletedStock.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}