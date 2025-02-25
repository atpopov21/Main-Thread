using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IStockRepository
{
    public Task CreateStockAsync(Stock newStock);
    public Task UpdateStockAsync(Stock newStock);
    public Task DeleteStockAsync(Stock newStock);
}