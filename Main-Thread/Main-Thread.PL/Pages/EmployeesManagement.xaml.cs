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
    string[] employeeData = { "0", "Ivan Angelov", "Software Engineer", "089 4672 021", "2025-05-03" };

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

            // Header
            BoardHeader.Text = "Company Employees";
            AddEmployeeButton.Text = "Add Employee";

            // Filters
            FilterID.Text = "ID";
            FilterName.Text = "Name";
            FilterDepartment.Text = "Department";
            FilterContact.Text = "Contact";
            FilterHireDate.Text = "Hire Date";
            FilterActions.Text = "Actions";

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

            // Header
            BoardHeader.Text = "Служители на компанията";
            AddEmployeeButton.Text = "Добави служител";

            // Filters
            FilterID.Text = "ID";
            FilterName.Text = "Име";
            FilterDepartment.Text = "Отдел";
            FilterContact.Text = "Връзка";
            FilterHireDate.Text = "Дата на назначаване";
            FilterActions.Text = "Действия";

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

            // Header
            BoardHeader.Text = "Company Employees";
            AddEmployeeButton.Text = "Add Employee";

            // Filters
            FilterID.Text = "ID";
            FilterName.Text = "Name";
            FilterDepartment.Text = "Department";
            FilterContact.Text = "Contact";
            FilterHireDate.Text = "Hire Date";
            FilterActions.Text = "Actions";

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
            // Board generic/header
            BoardBackground.BackgroundColor = Colors.White;
            BoardHeader.TextColor = Colors.Black;
            AddEmployeeButton.BackgroundColor = Colors.RoyalBlue;

            // Board filters
            FiltersBackground.BackgroundColor = Color.FromArgb("#f3f3f3");
            FilterID.TextColor = Colors.Black;
            FilterName.TextColor = Colors.Black;
            FilterDepartment.TextColor = Colors.Black;
            FilterContact.TextColor = Colors.Black;
            FilterHireDate.TextColor = Colors.Black;
            FilterActions.TextColor = Colors.Black;

            // Employees details
            EmployeeID.TextColor = Colors.Black;
            EmployeeName.TextColor = Colors.Black;
            EmployeeDepartment.TextColor = Colors.Black;
            EmployeeContact.TextColor = Colors.Black;
            EmployeeHireDate.TextColor = Colors.Black;
            EmployeeActions.ClearValue(Picker.BackgroundColorProperty);

            Background.BackgroundColor = Colors.AliceBlue;
            BoardBackground.BackgroundColor = Colors.White;
        }
        else if (theme == "Dark" || theme == "Тъмно")
        {
            // Board generic/header
            BoardBackground.BackgroundColor = Color.FromArgb("#3b3b3b");
            BoardHeader.TextColor = Colors.White;
            AddEmployeeButton.BackgroundColor = Colors.BlueViolet;

            // Board filters
            FiltersBackground.BackgroundColor = Color.FromArgb("#3b3b3b");
            FilterID.TextColor = Colors.White;
            FilterName.TextColor = Colors.White;
            FilterDepartment.TextColor = Colors.White;
            FilterContact.TextColor = Colors.White;
            FilterHireDate.TextColor = Colors.White;
            FilterActions.TextColor = Colors.White;

            // Employees details
            EmployeeID.TextColor = Colors.White;
            EmployeeName.TextColor = Colors.White;
            EmployeeDepartment.TextColor = Colors.White;
            EmployeeContact.TextColor = Colors.White;
            EmployeeHireDate.TextColor = Colors.White;
            EmployeeActions.BackgroundColor = Colors.White;

            Background.BackgroundColor = Color.FromArgb("#28282B");
            BoardBackground.BackgroundColor = Color.FromArgb("#202124");
        }
        else
        {
            // Board generic/header
            BoardBackground.BackgroundColor = Colors.White;
            BoardHeader.TextColor = Colors.Black;
            AddEmployeeButton.BackgroundColor = Colors.RoyalBlue;

            // Board filters
            FiltersBackground.BackgroundColor = Color.FromArgb("#f3f3f3");
            FilterID.TextColor = Colors.Black;
            FilterName.TextColor = Colors.Black;
            FilterDepartment.TextColor = Colors.Black;
            FilterContact.TextColor = Colors.Black;
            FilterHireDate.TextColor = Colors.Black;
            FilterActions.TextColor = Colors.Black;

            // Employees details
            EmployeeID.TextColor = Colors.Black;
            EmployeeName.TextColor = Colors.Black;
            EmployeeDepartment.TextColor = Colors.Black;
            EmployeeContact.TextColor = Colors.Black;
            EmployeeHireDate.TextColor = Colors.Black;
            EmployeeActions.ClearValue(Picker.BackgroundColorProperty);

            Background.BackgroundColor = Colors.AliceBlue;
            BoardBackground.BackgroundColor = Colors.White;
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