using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Thread.BLL.Contracts.IPageHandlers
{
    public interface IHomePageService
    {
        (float[], string[]) GetRevenuesAndExpensesChartData(string language);
        (float[], string[]) GetProfitChartData(string language);
        (float[], string[]) GetEmployeesChartData();
        Task<(float[], string[])> GetStockChartData(string language);
    }
}
