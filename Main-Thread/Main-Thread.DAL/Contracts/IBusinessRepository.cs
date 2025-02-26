using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IBusinessRepository
{
    public Task CreateBusinessAsync(Business newBusiness);
    public Task UpdateBusinessAsync(Business updatedBusiness);
    public Task DeleteBusinessAsync(Business deletedBusiness);
}