using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Data;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Implementations
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly DbContext _context = new DbContext();

        // CREATE
        public async Task CreateRevenueAsync(Revenue newRevenue)
        {
            if (newRevenue is not null)
            {
                _context.Revenues.Add(newRevenue);

                string query = $"INSERT INTO [Revenues] (DailyRevenue, Date, BusinessId) VALUES (@DailyRevenue, @Date, @BusinessId)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@DailyRevenue", newRevenue.DailyRevenue);
                    command.Parameters.AddWithValue("@Date", newRevenue.Date);
                    command.Parameters.AddWithValue("@BusinessId", newRevenue.BusinessId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateRevenueAsync(Revenue updatedRevenue)
        {
            Revenue revenue = _context.Revenues.FirstOrDefault(x => x.Id == updatedRevenue.Id);

            if (revenue is not null)
            {
                revenue.DailyRevenue = updatedRevenue.DailyRevenue;
                revenue.Date = updatedRevenue.Date;
                revenue.BusinessId = updatedRevenue.BusinessId;
                
                string query = $"UPDATE [Revenues] SET [DailyRevenue] = @DailyRevenue, [Date] = @Date, [BusinessId] = @BusinessId WHERE [RevenueId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@DailyProfit", updatedRevenue.DailyRevenue);
                    command.Parameters.AddWithValue("@Date", updatedRevenue.Date);
                    command.Parameters.AddWithValue("@BusinessId", updatedRevenue.BusinessId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteRevenueAsync(Revenue deletedRevenue)
        {
            if (deletedRevenue is not null)
            {
                string query = $"DELETE FROM [Revenues] WHERE [RevenueId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@Id", deletedRevenue.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}