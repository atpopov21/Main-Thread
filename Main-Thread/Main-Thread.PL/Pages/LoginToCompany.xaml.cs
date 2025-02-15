using Main_Thread.PL.Pages.Resources;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Diagnostics;

namespace Main_Thread.PL.Pages;

public partial class LoginToCompany : ContentPage
{
    List<string> userCredentials = new List<string>(new string[2]);

    public LoginToCompany()
    {
        InitializeComponent();
        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
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
    }
}