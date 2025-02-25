using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IUserRepository
{
    public Task CreateUserAsync(User newUser);
    public Task UpdateUserAsync(User newUser);
    public Task DeleteUserAsync(User newUser);
}