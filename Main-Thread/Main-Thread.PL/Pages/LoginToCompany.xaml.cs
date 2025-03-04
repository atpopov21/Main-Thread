using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.BLL.Contracts.IValidation;
using Main_Thread.BLL.Services.Validation;
using Main_Thread.BLL.Services.PageHandlers;
using Main_Thread.PL.Pages.Resources;
using Main_Thread.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using Main_Thread.Shared.ViewModels;

namespace Main_Thread.PL.Pages;

public partial class LoginToCompany : ContentPage
{
    private readonly LoginPageHandler _loginService;
    private bool PasswordHidden = true, firstLaunch = true, colourInverted = false;

    public LoginToCompany(LoginPageHandler loginService)
    {
        InitializeComponent();
        InitializePageComponents();

        _loginService = loginService;
    }

    private void InitializePageComponents()
    {
        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
        OnThemeChanged(ClientSettingsVisuals.Instance.SelectedTheme);

        ShowEyeImage.IsVisible = false;
        HideEyeImage.IsVisible = false;
        ShowEyeLightImage.IsVisible = false;
        HideEyeLightImage.IsVisible = false;

        languageSelection.Margin = new Thickness(-5, -565, 20, 0);
    }

    public void OnLanguageChanged(string language)
    {
        ClientSettingsVisuals.Instance.SelectedLanguage = language;
        string selectedLanguage = language;

        if (selectedLanguage == "English")
        {
            MainThreadLoginTitle.Title = "Main Thread | Login to a company";

            LoginToCompanyLabel.Text = "Login to Company";
            EmailLabel.Text = "Email";
            PasswordLabel.Text = "Password";

            LoginButton.Text = "Login";
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            MainThreadLoginTitle.Title = "Главна нишка | Влезте в компания";

            LoginToCompanyLabel.Text = "Влезте в компания";
            EmailLabel.Text = "Имейл";
            PasswordLabel.Text = "Парола";

            LoginButton.Text = "Влизане";
            FooterENG.IsVisible = false;
            FooterBG.IsVisible = true;
        }
        else
        {
            MainThreadLoginTitle.Title = "Main Thread | Login to a company";

            LoginToCompanyLabel.Text = "Login to Company";
            EmailLabel.Text = "Email";
            PasswordLabel.Text = "Password";

            LoginButton.Text = "Login";
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
            LoginToCompanyLabel.TextColor = Colors.Black;
            
            EmailLabel.TextColor = Colors.Black;
            EmailBox.PlaceholderColor = Colors.LightGray;
            EmailBox.ClearValue(Entry.BackgroundColorProperty);
            EmailBox.TextColor = Colors.Black;

            PasswordLabel.TextColor = Colors.Black;
            PasswordBox.PlaceholderColor = Colors.LightGray;
            PasswordBox.ClearValue(Entry.BackgroundColorProperty);
            PasswordBox.TextColor = Colors.Black;

            LoginButton.BackgroundColor = Colors.RoyalBlue;
            Background.BackgroundColor = Colors.AliceBlue;
            FormBackground.BackgroundColor = Colors.White;
            colourInverted = false;
        }
        else if (theme == "Dark" || theme == "Тъмно")
        {
            LoginToCompanyLabel.TextColor = Colors.White;
            
            EmailLabel.TextColor = Colors.White;
            EmailBox.PlaceholderColor = Colors.Gray;
            EmailBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            EmailBox.TextColor = Colors.WhiteSmoke;

            PasswordLabel.TextColor = Colors.White;
            PasswordBox.PlaceholderColor = Colors.Gray;
            PasswordBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            PasswordBox.TextColor = Colors.WhiteSmoke;

            LoginButton.BackgroundColor = Colors.BlueViolet;
            Background.BackgroundColor = Color.FromArgb("#28282B");
            FormBackground.BackgroundColor = Color.FromArgb("#202124");
            colourInverted = true;
        }
        else
        {
            LoginToCompanyLabel.TextColor = Colors.Black;

            EmailLabel.TextColor = Colors.Black;
            EmailBox.ClearValue(Entry.BackgroundColorProperty);

            PasswordLabel.TextColor = Colors.Black;
            PasswordBox.ClearValue(Entry.BackgroundColorProperty);

            LoginButton.BackgroundColor = Colors.RoyalBlue;
            Background.BackgroundColor = Colors.AliceBlue;
            FormBackground.BackgroundColor = Colors.White;
            colourInverted = false;
        }

        // Call page elements' methods to update their UI
        FooterENG.UpdateTheme(theme);
        FooterBG.UpdateTheme(theme);
        languageSelection.UpdateTheme(theme);
        themeSelection.UpdateTheme(theme);
        PasswordBox_TextChanged(null, null);
    }
    
    /* Method for creating linear backgrounds
    private LinearGradientBrush CreateGradient(Color myStartColor, Color myEndColor)
    {
        var gb = new LinearGradientBrush();
        if (myStartColor != null && myEndColor != null)
        {
            gb.EndPoint = new Point(0, 1);
            gb.GradientStops.Add(new GradientStop(myStartColor, 0.1f));
            gb.GradientStops.Add(new GradientStop(myEndColor, 1.0f));
        }
        return gb;
    }*/

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailBox.Text;
        string password = PasswordBox.Text;

        // Check if entry fields are empty
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter both email and password.", "OK");
            return;
        } /*(else if () // !!!!!!Check if the email and password entered by the user match in the database!!!!!!
        {
            await DisplayAlert("Error", "Incorrect email or password.", "OK");
            return;
        }*/ // I am commenting this part of the code because it is not finished and the if() statement is empty, DO NOT DELETE IT!
            
        // Pull user data by checking for user with matching email and password
        BusinessVm business = _loginService.LoginButtonFunc(email, password);
            
        // Display this when login is successful
        DisplayAlert("Login", $"Logged in successfully!\nWelcome back {business.OwnerFirstName} {business.OwnerLastName}, owner of {business.BusinessName}!", "OK");
            
        // If successful, navigate to the next page(MainPage)
        await Navigation.PushAsync(new HomePage());
    }
        
    // Function to send the user to RegistrationForm page when the "Create an account" button(in footer) clicked
    // private void OnCreateAnAccountClicked(object sender, EventArgs e)
    // {
    //     Navigation.PushAsync(new RegisterCompany()); 
    // }

    private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (PasswordBox.Text == "" || PasswordBox.Text == null)
        {
            ShowEyeImage.IsVisible = false;
            HideEyeImage.IsVisible = false;
            ShowEyeLightImage.IsVisible = false;
            HideEyeLightImage.IsVisible = false;
            EyeButton.IsVisible = false;

            languageSelection.Margin = new Thickness(-5, -565, 20, 0);
            ShowEyeImage.Margin = new Thickness(-80, -41, 0, -40);
            HideEyeImage.Margin = new Thickness(-81, -71, 0, -70);
        }
        else
        {
            EyeButton.IsVisible = true;
            ShowEyeImage.Margin = new Thickness(-80, -41, 0, -40);
            HideEyeImage.Margin = new Thickness(-81, -71, 0, -70);

            if (!PasswordHidden || firstLaunch)
            {
                if (!colourInverted)
                {
                    ShowEyeImage.IsVisible = true;
                    HideEyeImage.IsVisible = false;

                    ShowEyeLightImage.IsVisible = false;
                    HideEyeLightImage.IsVisible = false;
                }
                else
                {
                    ShowEyeLightImage.IsVisible = true;
                    HideEyeLightImage.IsVisible = false;

                    ShowEyeImage.IsVisible = false;
                    HideEyeImage.IsVisible = false;
                }

                languageSelection.Margin = new Thickness(-5, -566, 20, 0);
            }
            else
            {
                if (!colourInverted)
                {
                    ShowEyeImage.IsVisible = false;
                    HideEyeImage.IsVisible = true;

                    ShowEyeLightImage.IsVisible = false;
                    HideEyeLightImage.IsVisible = false;
                }
                else
                {
                    ShowEyeLightImage.IsVisible = false;
                    HideEyeLightImage.IsVisible = true;

                    ShowEyeImage.IsVisible = false;
                    HideEyeImage.IsVisible = false;
                }

                languageSelection.Margin = new Thickness(-5, -565, 20, 0);
            }
        }
    }

    private void PasswordShowStateClicked(object sender, EventArgs e)
    {
        firstLaunch = false;
        if (PasswordHidden)
        {
            PasswordBox.IsPassword = true;
            PasswordHidden = false;

            if (!colourInverted)
            {
                ShowEyeImage.IsVisible = true;
                HideEyeImage.IsVisible = false;

                ShowEyeLightImage.IsVisible = false;
                HideEyeLightImage.IsVisible = false;
            }
            else
            {
                ShowEyeLightImage.IsVisible = true;
                HideEyeLightImage.IsVisible = false;

                ShowEyeImage.IsVisible = false;
                HideEyeImage.IsVisible = false;
            }

            languageSelection.Margin = new Thickness(-5, -566, 20, 0);
        }
        else
        {
            PasswordBox.IsPassword = false;
            PasswordHidden = true;

            if (!colourInverted)
            {
                ShowEyeImage.IsVisible = false;
                HideEyeImage.IsVisible = true;

                ShowEyeLightImage.IsVisible = false;
                HideEyeLightImage.IsVisible = false;
            }
            else
            {
                ShowEyeLightImage.IsVisible = false;
                HideEyeLightImage.IsVisible = true;

                ShowEyeImage.IsVisible = false;
                HideEyeImage.IsVisible = false;
            }

            languageSelection.Margin = new Thickness(-5, -565, 20, 0);
        }
    }

}