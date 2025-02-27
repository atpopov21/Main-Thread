using Main_Thread.PL.Pages;
using Main_Thread.PL.Pages.Resources;
using System.Threading.Channels;

namespace Main_Thread.PL
{
    public partial class AppShell : Shell
    {
        private static readonly Lazy<AppShell> _instance = new Lazy<AppShell>(() => new AppShell());
        public static AppShell Instance => _instance.Value;

        public AppShell()
        {
            InitializeComponent();
            OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
        }

        public void OnLanguageChanged(string language)
        {
            if (language == "English")
            {
                // Surface layer
                MainThreadHomeTitle.Title = "Main Thread | Welcome";
                MainThreadRegisterACompanyTitle.Title = "Main Thread | Register a company";
                MainThreadLoginTitle.Title = "Main Thread | Login to a company";

                // Inside layer
                InsideHomeTitle.Title = "Home";
                InsideRAETitle.Title = "Revenues and Expenses";
                InsideEmployeesManagementTitle.Title = "Employees Management";
                InsideStockManagementTitle.Title = "Stock Management";
            }
            else if (language == "Bulgarian")
            {
                // Surface layer
                MainThreadHomeTitle.Title = "Главна нишка | Добре Дошли";
                MainThreadRegisterACompanyTitle.Title = "Главна нишка | Регистрирайте компания";
                MainThreadLoginTitle.Title = "Главна нишка | Влезте в компания";

                // Inside layer
                InsideHomeTitle.Title = "Главна страница";
                InsideRAETitle.Title = "Приходи и доходи";
                InsideEmployeesManagementTitle.Title = "Управление на служители";
                InsideStockManagementTitle.Title = "Управление на стока";
            }
            else
            {
                // Surface layer
                MainThreadHomeTitle.Title = "Main Thread | Welcome";
                MainThreadRegisterACompanyTitle.Title = "Main Thread | Register a company";
                MainThreadLoginTitle.Title = "Main Thread | Login to a company";

                // Inside layer
                InsideHomeTitle.Title = "Home";
                InsideRAETitle.Title = "Revenues and Expenses";
                InsideEmployeesManagementTitle.Title = "Employees Management";
                InsideStockManagementTitle.Title = "Stock Management";
            }
        }
    }
}
