using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Contracts;

public interface IRevenuesAndExpensesRepository
{
    public Task CreateRevenuesAndExpensesAsync(RevenuesAndExpenses newRevenuesAndExpenses);
    public Task UpdateRevenuesAndExpensesAsync(RevenuesAndExpenses newRevenuesAndExpenses);
    public Task DeleteRevenuesAndExpensesAsync(RevenuesAndExpenses newRevenuesAndExpenses);
}