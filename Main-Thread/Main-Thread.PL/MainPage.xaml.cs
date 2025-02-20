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
        public MainPage()
        {
            InitializeComponent();
            InitializePageComponents();
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
                RegisterACompanyButton.Text = "Register a Company";
                LoginToACompanyButton.Text = "Login to a Company";
                RegisterACompanyButton.WidthRequest = 220;
                FooterENG.IsVisible = true;
                FooterBG.IsVisible = false;
            }
            else if (selectedLanguage == "Bulgarian")
            {
                RegisterACompanyButton.Text = "Регистрирайте фирма";
                LoginToACompanyButton.Text = "Влезте във фирма";
                RegisterACompanyButton.WidthRequest = 235;
                FooterBG.IsVisible = true;
                FooterENG.IsVisible = false;
            }
            else
            {
                RegisterACompanyButton.Text = "Register a Company";
                LoginToACompanyButton.Text = "Login to a Company";
                RegisterACompanyButton.WidthRequest = 220;
                FooterENG.IsVisible = true;
                FooterBG.IsVisible = false;
            }
        }

        private void OnThemeChanged(string theme)
        {
            ClientSettingsVisuals.Instance.SelectedTheme = theme;

            if (theme == "Light")
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
            else if (theme == "Dark")
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

            // Call Footer method to update its UI
            FooterENG.UpdateTheme(theme);
            FooterBG.UpdateTheme(theme);
            languageSelection.UpdateTheme(theme);
            themeSelection.UpdateTheme(theme);
        }


        private async void Register_Company_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//RegisterCompany");   // With no "Back" option
            await Navigation.PushAsync(new RegisterCompany());    // With a "Back" option
        }

        private async void Login_Company_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginToCompany");    // With no "Back" option
            await Navigation.PushAsync(new LoginToCompany());     // With a "Back" option
        }
        
    }
}