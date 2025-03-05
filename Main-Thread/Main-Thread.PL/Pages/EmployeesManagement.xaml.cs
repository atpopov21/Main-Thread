using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.BLL.Contracts.IValidation;
using Main_Thread.BLL.Services.PageHandlers;
using Main_Thread.PL.Pages.Resources;
using Microcharts;
using SkiaSharp;

namespace Main_Thread.PL.Pages;

public partial class EmployeesManagement : ContentPage
{
    // TEMPORARY declaration & initializaton; Info about the user must be retrieved from the database
    string[] userCredentials = { "Aleksandar Popov", "21", "ADMIN" };

    private readonly IEmployeesManagementService _employeesManagementService;
    private readonly IDispatcherTimer _timer;

    public EmployeesManagement(IEmployeesManagementService EmployeesManagementService)
    {
        _employeesManagementService = EmployeesManagementService;
        InitializeComponent();
        InitializePageComponents();

        // Initialize Timer
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += (s, e) => UpdateTime();
        _timer.Start();
    }

    private void InitializePageComponents()
    {
        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
        OnThemeChanged(ClientSettingsVisuals.Instance.SelectedTheme);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //InitializePageComponents();

        languageSelection.LanguageHanlder(ClientSettingsVisuals.Instance.SelectedLanguage);
        themeSelection.ThemeHandler(ClientSettingsVisuals.Instance.SelectedTheme);
    }

    private void UpdateTime()
    {
        TimeStamp.Text = DateTime.Now.ToString("HH:mm"); // Format as HH:MM
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
            PageReference.Title = "Employees Management";

            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Body

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            // Page title
            PageReference.Title = "Управление на служители";

            // Page header
            UserGreeting.Text = "Добре дошли, " + userCredentials[0];
            TimeLabel.Text = "Време";
            TimeLabel.Margin = new Thickness(52, -5, 0, 0);
            LogoutButton.Text = "Излизане";

            // Body

            // Page Footer
            FooterENG.IsVisible = false;
            FooterBG.IsVisible = true;
        }
        else
        {
            // Page title
            PageReference.Title = "Employees Management";

            // Page header
            UserGreeting.Text = "Welcome, " + userCredentials[0];
            TimeLabel.Text = "Time";
            TimeLabel.Margin = new Thickness(57, -5, 0, 0);
            LogoutButton.Text = "Logout";

            // Body

            // Page Footer
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }

        themeSelection.UpdateLanguage(language);
    }

    private void OnThemeChanged(string theme)
    {
        ClientSettingsVisuals.Instance.SelectedTheme = theme;

        if (theme == "Light" || theme == "Светло")
        {
            // Elements

            Background.BackgroundColor = Colors.AliceBlue;
        }
        else if (theme == "Dark" || theme == "Тъмно")
        {
            // Elements

            Background.BackgroundColor = Color.FromArgb("#28282B");
        }
        else
        {
            // Elements

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
}