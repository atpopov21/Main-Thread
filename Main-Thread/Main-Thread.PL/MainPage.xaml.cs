using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using System.Windows.Input;
using Main_Thread.PL.Pages;
using Main_Thread.PL.Pages.Templates;
using System.Diagnostics;

namespace Main_Thread.PL
{
    public partial class MainPage : ContentPage
    {
        // Default value for language: "English"
        private string selectedLanguage = "English";

        public MainPage()
        {
            InitializeComponent();

            MainThreadLogo.BackgroundColor = Color.Parse("Transparent");

            // Debug.WriteLine(selectedLanguage);  // SHOULD be removed in production
        }

        private void OnLanguageChanged(string language)
        {
            selectedLanguage = language;
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
            // Debug.WriteLine("Selected Language: " + selectedLanguage);  // SHOULD be removed in production
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Window.MinimumHeight = 600;
            this.Window.MinimumWidth = 1000;
        }

        private void Register_Company_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterCompany());
        }

        private void Login_Company_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginToCompany());
        }
    }
}