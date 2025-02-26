using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IRevenueRepository
{
    public Task CreateRevenueAsync(Revenue newRevenue);
    public Task UpdateRevenueAsync(Revenue newRevenue);
    public Task DeleteRevenueAsync(Revenue newRevenue);
}