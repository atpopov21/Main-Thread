using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using System.Windows.Input;
using Main_Thread.PL.Pages;
using Main_Thread.PL.Pages.Templates;
using Main_Thread.PL.Pages.Resources;

namespace Main_Thread.PL
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitializePageComponents();

            _serviceProvider = serviceProvider;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            //InitializePageComponents();

            languageSelection.LanguageHanlder(ClientSettingsVisuals.Instance.SelectedLanguage);
            themeSelection.ThemeHandler(ClientSettingsVisuals.Instance.SelectedTheme);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Window.MinimumHeight = 600;
            this.Window.MinimumWidth = 1000;
        }

        private void InitializePageComponents()
        {
            OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
            OnThemeChanged(ClientSettingsVisuals.Instance.SelectedTheme);

            MainThreadLogo.BackgroundColor = Color.Parse("Transparent");
        }

        private void OnLanguageChanged(string language)
        {
            ClientSettingsVisuals.Instance.SelectedLanguage = language;
            string selectedLanguage = language;

            if (selectedLanguage == "English")
            {
                MainThreadHomeTitle.Title = "Main Thread | Welcome";
                RegisterACompanyButton.Text = "Register a Company";
                LoginToACompanyButton.Text = "Login to a Company";
                RegisterACompanyButton.WidthRequest = 220;
                FooterENG.IsVisible = true;
                FooterBG.IsVisible = false;
            }
            else if (selectedLanguage == "Bulgarian")
            {
                MainThreadHomeTitle.Title = "Главна нишка | Добре Дошли";
                RegisterACompanyButton.Text = "Регистрирайте фирма";
                LoginToACompanyButton.Text = "Влезте във фирма";
                RegisterACompanyButton.WidthRequest = 235;
                FooterBG.IsVisible = true;
                FooterENG.IsVisible = false;
            }
            else
            {
                MainThreadHomeTitle.Title = "Main Thread | Welcome";
                RegisterACompanyButton.Text = "Register a Company";
                LoginToACompanyButton.Text = "Login to a Company";
                RegisterACompanyButton.WidthRequest = 220;
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
                Background.BackgroundColor = Colors.AliceBlue;
                RegisterACompanyButton.BackgroundColor = Colors.White;
                RegisterACompanyButton.TextColor = Colors.Black;

                MainThreadLogo.IsVisible = true;
                MainThreadLogo.BackgroundColor = Colors.Transparent;
                MainThreadLogoDarkTheme.IsVisible = false;

                LoginToACompanyButton.BackgroundColor = Colors.White;
                LoginToACompanyButton.TextColor = Colors.Black;
            }
            else if (theme == "Dark" || theme == "Тъмно")
            {
                Background.BackgroundColor = Color.FromArgb("#28282B");
                RegisterACompanyButton.BackgroundColor = Color.FromArgb("#212121");
                RegisterACompanyButton.TextColor = Colors.White;

                MainThreadLogo.IsVisible = false;
                MainThreadLogoDarkTheme.IsVisible = true;
                MainThreadLogoDarkTheme.BackgroundColor = Colors.Transparent;

                LoginToACompanyButton.BackgroundColor = Color.FromArgb("#212121");
                LoginToACompanyButton.TextColor = Colors.White;
            }
            else
            {
                Background.BackgroundColor = Colors.AliceBlue;
                RegisterACompanyButton.BackgroundColor = Colors.White;
                RegisterACompanyButton.TextColor = Colors.Black;

                MainThreadLogo.IsVisible = true;
                MainThreadLogo.BackgroundColor = Colors.Transparent;
                MainThreadLogoDarkTheme.IsVisible = false;

                LoginToACompanyButton.BackgroundColor = Colors.White;
                LoginToACompanyButton.TextColor = Colors.Black;
            }

            // Call page elements' methods to update their UI
            FooterENG.UpdateTheme(theme);
            FooterBG.UpdateTheme(theme);
            languageSelection.UpdateTheme(theme);
            themeSelection.UpdateTheme(theme);
        }

        private async void Register_Company_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Resolve RegisterCompanyPage from the DI container
                var registerCompanyPage = _serviceProvider.GetRequiredService<RegisterCompany>();

                // Navigate to RegisterCompanyPage
                await Navigation.PushAsync(registerCompanyPage);   // With a "Back" option
            }
            catch (Exception ex)
            {
                // Log or display the error
                await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
            }
        }

        private async void Login_Company_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Resolve LoginToCompanyPage from the DI container
                var loginToCompanyPage = _serviceProvider.GetRequiredService<LoginToCompany>();

                // Navigate to LoginToCompanyPage
                await Shell.Current.Navigation.PushAsync(loginToCompanyPage);   // With a "Back" option
            }
            catch (Exception ex)
            {
                // Log or display the error
                await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
            }
        }
        
    }
}