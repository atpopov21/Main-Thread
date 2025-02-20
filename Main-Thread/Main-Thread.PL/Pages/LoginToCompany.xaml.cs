using Main_Thread.PL.Pages.Resources;
using System;
using System.Diagnostics;

namespace Main_Thread.PL.Pages;

public partial class LoginToCompany : ContentPage
{
    // TEMPORARY declaration and initialization
    List<string> userCredentials = new List<string>(new string[2]);
    private bool PasswordHidden = true, firstLaunch = true, colourInverted = false;

    public LoginToCompany()
    {
        InitializeComponent();
        InitializePageComponents();
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

    private void OnLanguageChanged(string language)
    {
        ClientSettingsVisuals.Instance.SelectedLanguage = language;
        string selectedLanguage = language;

        if (selectedLanguage == "English")
        {
            LoginToCompanyLabel.Text = "Login to Company";
            EmailLabel.Text = "Email";
            PasswordLabel.Text = "Password";

            LoginButton.Text = "Login";
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            LoginToCompanyLabel.Text = "Влезте в компания";
            EmailLabel.Text = "Имейл";
            PasswordLabel.Text = "Парола";

            LoginButton.Text = "Вписване";
            FooterENG.IsVisible = false;
            FooterBG.IsVisible = true;
        }
        else
        {
            LoginToCompanyLabel.Text = "Login to Company";
            EmailLabel.Text = "Email";
            PasswordLabel.Text = "Password";

            LoginButton.Text = "Login";
            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
    }

    private void OnThemeChanged(string theme)
    {
        ClientSettingsVisuals.Instance.SelectedTheme = theme;

        if (theme == "Light")
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
        else if (theme == "Dark")
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

    private bool CheckCredentials()
    {
        // "realEamils" need to be retreived from the database (ID's are being simulated with the index of each email, which is equal to the password)
        string[] realEmails = { "ivan@gmail.com", "BADimov21@codingburgas.bg", "michaelWon@abv.bg", "fakeADMIN" };
        string[] realMatchingPasswords = { "ivanIsHere", "1234567890!Secure", "hippo#21", "fakeADMIN" };

        // Check for empty fields
        foreach (string information in userCredentials)
        {
            if (string.IsNullOrEmpty(information))
            {
                DisplayAlert("Alert", "There are one or multiple empty fields.\nPlease fill them in.", "OK");
                return false;
            }
        }

        // Check if email exists
        if (!realEmails.Any(email => email == userCredentials[0]))
        {
            DisplayAlert("Failed Login", "Email not found.", "Try Again");
            return false;
        }

        // Find index of the entered email
        int emailIndex = Array.IndexOf(realEmails, userCredentials[0]);

        // Check if password matches the user's email
        if (realMatchingPasswords[emailIndex] != userCredentials[1])
        {
            DisplayAlert("Failed Login", "Wrong password.", "Try Again");
            return false;
        }

        return true;
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

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        bool registrationSuccessful = CheckCredentials();

        // Write company register information to Debug window
        foreach (string information in userCredentials)
        {
            Debug.WriteLine(information);
        }

        if (registrationSuccessful)
        {
            await DisplayAlert("Successful Login", "Login Successful.\nYou will be redirected to the Home page now.", "OK");
            await Shell.Current.GoToAsync("//HomePage");
        }
    }

    private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        userCredentials[0] = EmailBox.Text;
    }

    private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        userCredentials[1] = PasswordBox.Text;

        if (userCredentials[1] == "" || userCredentials[1] == null)
        {
            ShowEyeImage.IsVisible = false;
            HideEyeImage.IsVisible = false;
            ShowEyeLightImage.IsVisible = false;
            HideEyeLightImage.IsVisible = false;

            languageSelection.Margin = new Thickness(-5, -565, 20, 0);
            ShowEyeImage.Margin = new Thickness(-80, -41, 0, -40);
            HideEyeImage.Margin = new Thickness(-81, -71, 0, -70);
        }
        else
        {
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