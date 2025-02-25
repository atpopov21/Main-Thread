using Microsoft.Extensions.DependencyInjection;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Implementations;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.DependencyInjection;

public static class DependencyInjection
{
    public static void AddDalRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IBusinessRepository, BusinessRepository>();
        services.AddSingleton<IProfitRepository, ProfitRepository>();
        services.AddSingleton<IRevenueRepository, RevenueRepository>();
        services.AddSingleton<IRevenuesAndExpensesRepository, RevenuesAndExpensesRepository>();
        services.AddSingleton<IStockRepository, StockRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
    }
}