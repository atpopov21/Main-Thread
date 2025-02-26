using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IProfitRepository
{
    public Task CreateProfitAsync(Profit newProfit);
    public Task UpdateProfitAsync(Profit newProfit);
    public Task DeleteProfitAsync(Profit deletedProfit);
}