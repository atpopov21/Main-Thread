using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IStockRepository
{
    public Task CreateStockAsync(Stock newStock);
    public Task UpdateStockAsync(Stock updatedStock);
    public Task DeleteStockAsync(Stock deletedStock);
}