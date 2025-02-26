using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Data;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Implementations
{
    public class ProfitRepository : IProfitRepository
    {
        private readonly DbContext _context = new DbContext();

        // CREATE
        public async Task CreateProfitAsync(Profit newProfit)
        {
            if (newProfit is not null)
            {
                _context.Profits.Add(newProfit);

                string query = $"INSERT INTO [Profits] (DailyProfit, Date) VALUES (@DailyProfit, @Date)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@DailyProfit", newProfit.DailyProfit);
                    command.Parameters.AddWithValue("@Date", newProfit.Date);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateProfitAsync(Profit updatedProfit)
        {
            Profit profit = _context.Profits.FirstOrDefault(x => x.Id == updatedProfit.Id);

            if (profit is not null)
            {
                profit.DailyProfit = updatedProfit.DailyProfit;
                profit.Date = updatedProfit.Date;
                
                string query = $"UPDATE [Profits] SET [DailyProfit] = @DailyProfit, [Date] = @Date WHERE [ProfitId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@DailyProfit", updatedProfit.DailyProfit);
                    command.Parameters.AddWithValue("@Date", updatedProfit.Date);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteProfitAsync(Profit deletedProfit)
        {
            if (deletedProfit is not null)
            {
                string query = $"DELETE FROM [Profits] WHERE [ProfitId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@Id", deletedProfit.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}