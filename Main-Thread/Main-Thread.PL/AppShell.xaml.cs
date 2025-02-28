using Main_Thread.PL.Pages;
using Main_Thread.PL.Pages.Resources;
using System.Threading.Channels;

namespace Main_Thread.PL
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public void OnLanguageChanged(string language)
        {
            if (language == "English")
            {
                InsideHomeTitle.Title = "Home";
                InsideRAETitle.Title = "Revenues and Expenses";
                InsideEmployeesManagementTitle.Title = "Employees Management";
                InsideStockManagementTitle.Title = "Stock Management";
            }
            else if (language == "Bulgarian")
            {
                InsideHomeTitle.Title = "Главна страница";
                InsideRAETitle.Title = "Приходи и доходи";
                InsideEmployeesManagementTitle.Title = "Управление на служители";
                InsideStockManagementTitle.Title = "Управление на стока";
            }
            else
            {
                InsideHomeTitle.Title = "Home";
                InsideRAETitle.Title = "Revenues and Expenses";
                InsideEmployeesManagementTitle.Title = "Employees Management";
                InsideStockManagementTitle.Title = "Stock Management";
            }
        }
    }
}
