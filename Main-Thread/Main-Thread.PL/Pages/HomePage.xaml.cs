using Main_Thread.PL.Pages.Resources;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;
using System.Diagnostics;	// SHOULD be removed in production

namespace Main_Thread.PL.Pages;

public partial class HomePage : ContentPage
{
    // TEMPORARY declaration & initializaton; Info about the user must be retrieved from the database
    string[] userCredentials = { "Aleksandar Popov", "21", "ADMIN" };

    // Revenues and Incomes chart parameters
    static float[] RIAChartValues = { 212f, 248f, 128f, 514f };
    static string[] RIALabelValues = { "First Month", "Second Month", "Third Month", "Fourth Month" };
    ChartEntry[] RIAEntries = new[]
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

    // Profit / Month Chart (Latest 4) [4 months]
    static float[] pointValues = { 0, 200, 150, 350 };
    ChartEntry[] RIAEntriesChartTwo = new[]
    {
        new ChartEntry(pointValues[0])
        {
            Label = RIALabelValues[0],
            Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 0))
        },
        new ChartEntry(pointValues[1])
        {
            Label = RIALabelValues[1],
            Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 1))
        },
        new ChartEntry(pointValues[2])
        {
            Label = RIALabelValues[2],
            Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 2))
        },
        new ChartEntry(pointValues[3])
        {
            Label = RIALabelValues[3],
            Color = SKColor.Parse(GenerateColoursForProfitChart(CalculateAverageProfitPerMonth(pointValues), pointValues, 3))
        },
    };

    // Employees chart parameters
    static float[] EMChartValues = { 514f, 392f, 368f, 271f, 201f };
    string[] topFiveEmployeesNames = { "Ivan\nGeorgiev", "Ivan\nAngelov", "Ioanna\nZheleva", "Patrisia\nPetrova", "Lubomir\nDimitrov" };
    ChartEntry[] EMEntries = new[]
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

    // Stock chart parameters
    static float[] SMChartValues = { 231f, 204f, 182f, 162f, 82f };
    static string[] topFiveStockNames = { "Dark chocolate", "Larry's Chips", "Popcorn", "Beef meat", "Orange Juice" };
    ChartEntry[] SMEntries = new[]
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

    private readonly IDispatcherTimer _timer;

    public HomePage()
	{
		InitializeComponent();
        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);


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

        // Initialize Timer
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += (s, e) => UpdateTime();
        _timer.Start();
    }

    private void UpdateTime()
    {
        TimeStamp.Text = DateTime.Now.ToString("HH:mm"); // Format as HH:MM:SS
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

        if (selectedLanguage == "English")
        {
            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Revenues and Expenses Section
            RevenuesAndExpensesLabel.Text = "Revenues and Expenses";
            RAIButtonLabel.Text = "View";

            // Employess Management Section
            EmployessManagementLabel.Text = "Employees Management";
            EMButtonLabel.Text = "View";

            // Stock Management Section
            StockManagementLabel.Text = "Stock Management";
            SMButtonLabel.Text = "View";

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            // Page header
            UserGreeting.Text = "Добре дошли, " + userCredentials[0];
            TimeLabel.Text = "Време";
            TimeLabel.Margin = new Thickness(52, -5, 0, 0);
            LogoutButton.Text = "Излизане";

            // Revenues and Incomes Section
            RevenuesAndExpensesLabel.Text = "Доходи и разходи";
            RAIButtonLabel.Text = "Погледнете";

            // Employess Management Section
            EmployessManagementLabel.Text = "Управление на служители";
            EMButtonLabel.Text = "Погледнете";

            // Stock Management Section
            StockManagementLabel.Text = "Управление на стока";
            SMButtonLabel.Text = "Погледнете";

            // Page Footer
            FooterENG.IsVisible = false;
            FooterBG.IsVisible = true;
        }
        else
        {
            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Revenues and Expenses Section
            RevenuesAndExpensesLabel.Text = "Revenues and Expenses";
            RAIButtonLabel.Text = "View";

            // Employess Management Section
            EmployessManagementLabel.Text = "Employees Management";
            EMButtonLabel.Text = "View";

            // Stock Management Section
            StockManagementLabel.Text = "Stock Management";
            SMButtonLabel.Text = "View";

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }

        EmployeeOneLabel.Text = topFiveEmployeesNames[0];
        EmployeeTwoLabel.Text = topFiveEmployeesNames[1];
        EmployeeThreeLabel.Text = topFiveEmployeesNames[2];
        EmployeeFourLabel.Text = topFiveEmployeesNames[3];
        EmployeeFiveLabel.Text = topFiveEmployeesNames[4];
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

    private async void RAIButtonLabel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RevenuesAndExpenses");
    }

    private async void EMButtonLabel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//EmployeesManagement");
    }

    private async void SMButtonLabel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StockManagement");
    }
}