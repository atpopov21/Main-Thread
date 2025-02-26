using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.Shared.Resources;

namespace Main_Thread.BLL.Services.PageHandlers
{
    public class HomePageService : IHomePageService
    {
        public (float[], string[]) GetRevenuesAndExpensesChartData(string language)
        {
            // Retireve data from DAL/DTO
            // Revenues and Incomes chart parameters
            float[] RIAChartValues = { 212f, 248f, 128f, 514f };
            string[] RIALabelValues;

            switch(language)
            {
                case "English":
                    RIALabelValues = new string[]{ "First Month", "Second Month", "Third Month", "Fourth Month" };
                    break;

                case "Bulgarian":
                    RIALabelValues = new string[] { "Първи месец", "Втори месец", "Трети месец", "Четвърти месец" };
                    break;

                default:
                    RIALabelValues = new string[] { "First Month", "Second Month", "Third Month", "Fourth Month" };
                    break;
            }

            return (RIAChartValues, RIALabelValues);
        }

        public (float[], string[]) GetProfitChartData(string language)
        {
            // Retireve data from DAL/DTO
            // Profit / Month Chart(Latest 4)[4 months]
            float[] pointValues = { 0, 200, 150, 350 };
            string[] RIALabelValuesChartTwo;

            switch (language)
            {
                case "English":
                    RIALabelValuesChartTwo = new string[] { "First Month", "Second Month", "Third Month", "Fourth Month" };
                    break;

                case "Bulgarian":
                    RIALabelValuesChartTwo = new string[] { "Първи месец", "Втори месец", "Трети месец", "Четвърти месец" };
                    break;

                default:
                    RIALabelValuesChartTwo = new string[] { "First Month", "Second Month", "Third Month", "Fourth Month" };
                    break;
            }

            return (pointValues, RIALabelValuesChartTwo);
        }

        public (float[], string[]) GetEmployeesChartData()
        {
            // Retireve data from DAL/DTO
            // Employees chart parameters
            float[] EMChartValues = { 514f, 392f, 368f, 271f, 201f };
            string[] topFiveEmployeesNames = { "Ivan\nGeorgiev", "Ivan\nAngelov", "Ioanna\nZheleva", "Patrisia\nPetrova", "Lubomir\nDimitrov" };

            return (EMChartValues, topFiveEmployeesNames);
        }

        public async Task<(float[], string[])> GetStockChartData(string language)
        {
            // Retireve data from DAL/DTO
            // Stock chart parameters
            float[] SMChartValues = { 231f, 204f, 182f, 162f, 82f };
            string[] topFiveStockNames = { "Dark chocolate|", "Larry's Chips|", "Popcorn|", "Beef meat|", "Orange Juice|" };
            string translatedStockNames;

            switch (language)
            {
                case "English":
                    topFiveStockNames = new string[] { "Dark chocolate", "Larry's Chips", "Popcorn", "Beef meat", "Orange Juice" };
                    break;

                case "Bulgarian":
                    AutoTranslation translation = new AutoTranslation();

                    string temp = "";
                    foreach (var stock in topFiveStockNames)
                    {
                        temp += stock;
                    }
                    translatedStockNames = await translation.TranslateAsync(temp, "en", "bg");

                    topFiveStockNames = translatedStockNames.Split("|");
                    break;

                default:
                    topFiveStockNames = new string[] { "Dark chocolate", "Larry's Chips", "Popcorn", "Beef meat", "Orange Juice" };
                    break;
            }

            return (SMChartValues, topFiveStockNames);
        }
    }
}
