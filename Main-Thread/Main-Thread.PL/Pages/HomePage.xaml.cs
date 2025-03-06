using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.PL.Pages.Resources;
using Main_Thread.Shared.ViewModels;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;
using System.Diagnostics;	// SHOULD be removed in production

namespace Main_Thread.PL.Pages;

public partial class HomePage : ContentPage
{
    // TEMPORARY declaration & initializaton; Info about the user must be retrieved from the database
    string[] userCredentials = { "Aleksandar Popov", "21", "ADMIN" };

    // Chart parameters
    static float[] RIAChartValues, pointValues, EMChartValues, SMChartValues;
    static string[] RIALabelValues, RIALabelValuesChartTwo, topFiveEmployeesNames, topFiveStockNames;
    ChartEntry[] RIAEntries, RIAEntriesChartTwo, EMEntries, SMEntries;    

    private readonly IHomePageService _homePageService;
    private readonly IDispatcherTimer _timer;

    public HomePage(IHomePageService homePageService)
    {
        _homePageService = homePageService;
        InitializeComponent();
        InitializePageComponents();

        // Initialize Timer
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += (s, e) => UpdateTime();
        _timer.Start();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        languageSelection.LanguageHanlder(ClientSettingsVisuals.Instance.SelectedLanguage);
        themeSelection.ThemeHandler(ClientSettingsVisuals.Instance.SelectedTheme);
    }

    private void InitializePageComponents()
    {
        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
        OnThemeChanged(ClientSettingsVisuals.Instance.SelectedTheme);
        InitializeCharts();
    }

    private void UpdateTime()
    {
        TimeStamp.Text = DateTime.Now.ToString("HH:mm"); // Format as HH:MM
    }

    private async void InitializeCharts()
    {
        // Initialize Charts
        (RIAChartValues, RIALabelValues) = _homePageService.GetRevenuesAndExpensesChartData(ClientSettingsVisuals.Instance.SelectedLanguage);  // Revenues and Incomes chart parameters initialization
        RIAEntries = new[]
        {
            new ChartEntry(RIAChartValues[0])
            {
                Label = RIALabelValues[0],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(RIAChartValues), RIAChartValues, 0))
            },
            new ChartEntry(RIAChartValues[1])
            {
                Label = RIALabelValues[1],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(RIAChartValues), RIAChartValues, 1))
            },
            new ChartEntry(RIAChartValues[2])
            {
                Label = RIALabelValues[2],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(RIAChartValues), RIAChartValues, 2))
            },
            new ChartEntry(RIAChartValues[3])
            {
                Label = RIALabelValues[3],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(RIAChartValues), RIAChartValues, 3))
            },
        };
        (pointValues, RIALabelValuesChartTwo) = _homePageService.GetProfitChartData(ClientSettingsVisuals.Instance.SelectedLanguage);  // Profit / Month Chart (Latest 4) [4 months] initialization
        RIAEntriesChartTwo = new[]
        {
            new ChartEntry(pointValues[0])
            {
                Label = RIALabelValuesChartTwo[0],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 0))
            },
            new ChartEntry(pointValues[1])
            {
                Label = RIALabelValuesChartTwo[1],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 1))
            },
            new ChartEntry(pointValues[2])
            {
                Label = RIALabelValuesChartTwo[2],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 2))
            },
            new ChartEntry(pointValues[3])
            {
                Label = RIALabelValuesChartTwo[3],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 3))
            },
        };
        (EMChartValues, topFiveEmployeesNames) = _homePageService.GetEmployeesChartData();  // Employees chart parameters initialization
        EMEntries = new[]
        {
            new ChartEntry(EMChartValues[0])
            {
                Label = " ",
                Color = SKColor.Parse("#87cefa")
            },
            new ChartEntry(EMChartValues[1])
            {
                Label = " ",
                Color = SKColor.Parse("#9de24f")
            },
            new ChartEntry(EMChartValues[2])
            {
                Label = " ",
                Color = SKColor.Parse("#eea990")
            },
            new ChartEntry(EMChartValues[3])
            {
                Label = " ",
                Color = SKColor.Parse("#ffbd55")
            },
            new ChartEntry(EMChartValues[4])
            {
                Label = " ",
                Color = SKColor.Parse("#ff6666")
            },
        };
        (SMChartValues, topFiveStockNames) = await _homePageService.GetStockChartData(ClientSettingsVisuals.Instance.SelectedLanguage);  // Stock chart parameters initialization
        SMEntries = new[]
        {
            new ChartEntry(SMChartValues[0])
            {
                Label = topFiveStockNames[0],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(SMChartValues), SMChartValues, 100))
            },
            new ChartEntry(SMChartValues[1])
            {
                Label = topFiveStockNames[1],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(SMChartValues), SMChartValues, 100))
            },
            new ChartEntry(SMChartValues[2])
            {
                Label = topFiveStockNames[2],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(SMChartValues), SMChartValues, 100))
            },
            new ChartEntry(SMChartValues[3])
            {
                Label = topFiveStockNames[3],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(SMChartValues), SMChartValues, 100))
            },
            new ChartEntry(SMChartValues[4])
            {
                Label = topFiveStockNames[4],
                Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(SMChartValues), SMChartValues, 100))
            },
        };

        // Create Charts
        RevenuesAndExpensesMiniChart.Chart = new LineChart
        {
            Entries = RIAEntries
        };
        RevenuesAndExpensesMiniChartTwo.Chart = new LineChart
        {
            Entries = RIAEntriesChartTwo,
            LineMode = LineMode.Straight,
        };
        EmployeesManagementChart.Chart = new PointChart
        {
            Entries = EMEntries,
            LabelOrientation = Orientation.Horizontal
        };
        StockManagementChart.Chart = new PieChart
        {
            Entries = SMEntries,
        };
    }

    private static float CalculateAverageProfitPerMonth(float[] profitsPerMonth)
    {
        int count = 0;
        float avgProfit = 0f;

        foreach (float profit in profitsPerMonth)
        {
            avgProfit += profit;
            count++;
        }

        Debug.WriteLine($"Avg profit: {avgProfit / count}");

        return avgProfit / count;
    }

    private static string GenerateColoursForProfitChart(float avgEarnings, float[] pointsValues, int index)
    {
        // Generate random warm/cold colours
        if (index == 100)
        {
            Random randomValue = new Random();

            int red = randomValue.Next(150, 235);
            int green = randomValue.Next(140, 235);
            int blue = randomValue.Next(150, 235);

            return $"#{red:X2}{green:X2}{blue:X2}"; // Convert RGB to HEX
        }
        else
        {
            // Generate a warm colour, representing a negative sequence
            if (pointsValues[index] < avgEarnings)
            {
                Random randomValue = new Random();

                int red = randomValue.Next(200, 255);
                int green = randomValue.Next(100, 200);
                int blue = randomValue.Next(50, 130);

                return $"#{red:X2}{green:X2}{blue:X2}"; // Convert RGB to HEX
            }
            // Generate a cold colour, representing a positive sequence
            else
            {
                Random randomValue = new Random();

                int red = randomValue.Next(50, 130);
                int green = randomValue.Next(100, 200);
                int blue = randomValue.Next(200, 255);

                return $"#{red:X2}{green:X2}{blue:X2}"; // Convert RGB to HEX
            }
        }
    }

    private void OnLanguageChanged(string language)
    {
        ClientSettingsVisuals.Instance.SelectedLanguage = language;
        string selectedLanguage = language;

        // Access AppShell
        if (Shell.Current is AppShell appShell)
        {
            appShell.OnLanguageChanged(language);
        }

        if (selectedLanguage == "English")
        {
            // Page title
            HomePageTitle.Title = "Home";

            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Revenues and Expenses Section
            RevenuesAndExpensesLabel.Text = "Revenues and Expenses";
            RevenueChangeChartTitle.Text = "Change in revenue by month";
            ProfitChartTitle.Text = "Profit / Month (Latest 4)";
            RAIButton.Text = "View";

            // Employess Management Section
            EmployessManagementLabel.Text = "Employees Management";
            TopEmployeesChartTitle.Text = "TOP 5 Best Employees";
            EMButton.Text = "View";

            // Stock Management Section
            StockManagementLabel.Text = "Stock Management";
            BestProductsChartTitle.Text = "Best Selling Products (by %)";
            SMButton.Text = "View";

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            // Page title
            HomePageTitle.Title = "Главна страница";

            // Page header
            UserGreeting.Text = "Добре дошли, " + userCredentials[0];
            TimeLabel.Text = "Време";
            TimeLabel.Margin = new Thickness(52, -5, 0, 0);
            LogoutButton.Text = "Излизане";

            // Revenues and Incomes Section
            RevenuesAndExpensesLabel.Text = "Приходи и разходи";
            RevenueChangeChartTitle.Text = "Промяна в приходите на месец";
            ProfitChartTitle.Text = "Приход / месец (Последните 4)";
            RAIButton.Text = "Погледнете";

            // Employess Management Section
            EmployessManagementLabel.Text = "Управление на служители";
            TopEmployeesChartTitle.Text = "ТОП 5 най-добри служители";
            EMButton.Text = "Погледнете";

            // Stock Management Section
            StockManagementLabel.Text = "Управление на стока";
            BestProductsChartTitle.Text = "Най-продавани продукти (в %)";
            SMButton.Text = "Погледнете";

            // Page Footer
            FooterENG.IsVisible = false;
            FooterBG.IsVisible = true;
        }
        else
        {
            // Page title
            HomePageTitle.Title = "Home";

            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Revenues and Expenses Section
            RevenuesAndExpensesLabel.Text = "Revenues and Expenses";
            RevenueChangeChartTitle.Text = "Change in revenue by month";
            ProfitChartTitle.Text = "Profit / Month (Latest 4)";
            RAIButton.Text = "View";

            // Employess Management Section
            EmployessManagementLabel.Text = "Employees Management";
            TopEmployeesChartTitle.Text = "TOP 5 Best Employees";
            EMButton.Text = "View";

            // Stock Management Section
            StockManagementLabel.Text = "Stock Management";
            BestProductsChartTitle.Text = "Best Selling Products (by %)";
            SMButton.Text = "View";

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }

        InitializeCharts();
        themeSelection.UpdateLanguage(language);
        EmployeeOneLabel.Text = topFiveEmployeesNames[0];
        EmployeeTwoLabel.Text = topFiveEmployeesNames[1];
        EmployeeThreeLabel.Text = topFiveEmployeesNames[2];
        EmployeeFourLabel.Text = topFiveEmployeesNames[3];
        EmployeeFiveLabel.Text = topFiveEmployeesNames[4];
    }

    private void OnThemeChanged(string theme)
    {
        ClientSettingsVisuals.Instance.SelectedTheme = theme;

        if (theme == "Light" || theme == "Светло")
        {
            // Revenues and Expenses section
            RevenuesAndExpensesFrame.BackgroundColor = Colors.White;
            RevenuesAndExpensesLabel.TextColor = Colors.Black;
            RAIButton.BackgroundColor = Colors.RoyalBlue;

            // Employees Management section
            EmployessManagementFrame.BackgroundColor = Colors.White;
            EmployessManagementLabel.TextColor = Colors.Black;
            EMButton.BackgroundColor = Colors.RoyalBlue;

            // Stock Management section
            StockManagementFrame.BackgroundColor = Colors.White;
            StockManagementLabel.TextColor = Colors.Black;
            SMButton.BackgroundColor = Colors.RoyalBlue;

            Background.BackgroundColor = Colors.AliceBlue;
        }
        else if (theme == "Dark" || theme == "Тъмно")
        {
            // Revenues and Expenses section
            RevenuesAndExpensesFrame.BackgroundColor = Color.FromArgb("#202124");
            RevenuesAndExpensesLabel.TextColor = Colors.White;
            RAIButton.BackgroundColor = Colors.BlueViolet;

            // Employees Management section
            EmployessManagementFrame.BackgroundColor = Color.FromArgb("#202124");
            EmployessManagementLabel.TextColor = Colors.White;
            EMButton.BackgroundColor = Colors.BlueViolet;

            // Stock Management section
            StockManagementFrame.BackgroundColor = Color.FromArgb("#202124");
            StockManagementLabel.TextColor = Colors.White;
            SMButton.BackgroundColor = Colors.BlueViolet;

            Background.BackgroundColor = Color.FromArgb("#28282B");
        }
        else
        {
            // Revenues and Expenses section
            RevenuesAndExpensesFrame.BackgroundColor = Colors.White;
            RevenuesAndExpensesLabel.TextColor = Colors.Black;
            RAIButton.BackgroundColor = Colors.RoyalBlue;

            // Employees Management section
            EmployessManagementFrame.BackgroundColor = Colors.White;
            EmployessManagementLabel.TextColor = Colors.Black;
            EMButton.BackgroundColor = Colors.RoyalBlue;

            // Stock Management section
            StockManagementFrame.BackgroundColor = Colors.White;
            StockManagementLabel.TextColor = Colors.Black;
            SMButton.BackgroundColor = Colors.RoyalBlue;

            Background.BackgroundColor = Colors.AliceBlue;
        }

        // Call page elements' methods to update their UI
        FooterENG.UpdateTheme(theme);
        FooterBG.UpdateTheme(theme);
        languageSelection.UpdateTheme(theme);
        themeSelection.UpdateTheme(theme);
    }

    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        bool userExits = await DisplayAlert("Exit", "Do you really want to exit?", "Exit", "Go Back");
        
        if (userExits)
        {
            // Clear the user credentials / Flush data
            foreach (string credential in userCredentials)
            {
                credential.Remove(0);
            }

            // Go back to the main page
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    private async void RAIButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RevenuesAndExpenses");
    }

    private async void EMButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//EmployeesManagement");
    }

    private async void SMButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StockManagement");
    }
}