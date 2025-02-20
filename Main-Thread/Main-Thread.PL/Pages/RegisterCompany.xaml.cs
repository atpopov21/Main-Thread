using Main_Thread.PL.Pages.Resources;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Main_Thread.PL.Pages;

public enum PasswordScore
{
    Blank = 0,
    VeryWeak = 1,
    Weak = 2,
    Medium = 3,
    Strong = 4,
    VeryStrong = 5
}

public class PasswordAdvisor
{
    public static PasswordScore CheckStrength(string password)
    {
        int score = 0;

        if (password.Length < 1)
            return PasswordScore.Blank;
        if (password.Length < 4)
            return PasswordScore.VeryWeak;

        if (password.Length >= 8)
            score++;
        if (password.Length >= 12)
            score++;
        if (Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
            score++;
        if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
          Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
            score++;
        if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
            score++;

        return (PasswordScore)score;
    }
}

public partial class RegisterCompany : ContentPage
{
    // TEMPORARY declaration and initialization
    List<string> companyInformation = new List<string>(new string[15]);
    private PasswordScore passwordStrengthScore;
    private bool PasswordHidden = true, firstLaunch = true, colourInverted = false;
    private HorizontalStackLayout[] formRows;

    public RegisterCompany()
	{
        InitializeComponent();
        InitializePageComponents();
    }

    private void InitializePageComponents()
    {
        ShowEyeImage.IsVisible = false;
        HideEyeImage.IsVisible = false;
        ShowEyeLightImage.IsVisible = false;
        HideEyeLightImage.IsVisible = false;

        languageSelection.Margin = new Thickness(-5, -1730, 20, 1600);

        // Ensure Picker has a default selection
        if (CategoryPicker.SelectedIndex == -1)
        {
            CategoryPicker.SelectedIndex = 0;
        }

        formRows = new HorizontalStackLayout[]
        {
            FormRowOne, FormRowTwo, FormRowThree, FormRowFour,
            FormRowFive, FormRowSix, FormRowSeven, FormRowEight,
            FormRowNine, FormRowTen
        };

        OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
        OnThemeChanged(ClientSettingsVisuals.Instance.SelectedTheme);
    }

    private void OnLanguageChanged(string language)
    {
        ClientSettingsVisuals.Instance.SelectedLanguage = language;
        string selectedLanguage = language;

        if (selectedLanguage == "English")
        {
            // Header
            RegisterBusinessLabel.Text = "Register Your Business";
            RegisterBusinessSubtitleLabel.Text = "Please provide all required details to register your business with Main Thread Inc.";
            BusinessOwnerLabel.Text = "Business Owner";
            BusinessOwnerLabel.Padding = new Thickness(30, 22, 120, 0);
            
            // Body
            FirstNameLabel.Text = "First Name";
            LastNameLabel.Text = "Last Name";

            PasswordLabel.Text = "Password";
            PasswordLabel.Padding = new Thickness(30, 22, 162, 0);
            switch (passwordStrengthScore)
            {
                case PasswordScore.VeryWeak:
                    PasswordScoreLabel.Text = "Very Weak";
                    PasswordScoreLabel.TextColor = Colors.DimGray;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Weak:
                    PasswordScoreLabel.Text = "Weak";
                    PasswordScoreLabel.TextColor = Colors.DarkRed;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Medium:
                    PasswordScoreLabel.Text = "Medium";
                    PasswordScoreLabel.TextColor = Colors.DarkOrange;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Strong:
                    PasswordScoreLabel.Text = "Strong";
                    PasswordScoreLabel.TextColor = Colors.MediumBlue;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.VeryStrong:
                    PasswordScoreLabel.Text = "Very Strong";
                    PasswordScoreLabel.TextColor = Colors.ForestGreen;
                    PasswordScoreLabel.IsVisible = true;
                    break;
            }

            BusinessNameLabel.Text = "Business Name";
            BusinessNameLabel.Padding = new Thickness(30, 22, 120, 0);

            ContactNumberLabel.Text = "Contact Number";
            ContactNumberLabel.Padding = new Thickness(30, 22, 120, 0);

            EmailLabel.Text = "E-mail";
            EmailLabel.Padding = new Thickness(30, 22, 120, 0);

            SERLabel.Text = "State Entity Registration #";
            SERLabel.Padding = new Thickness(30, 22, 48, 0);

            EINLabel.Text = "Employer Identification\nNumber";
            EINLabel.Padding = new Thickness(30, 22, 67, 0);

            AddressLabel.Text = "Company Address";
            AddressLabel.Padding = new Thickness(30, 22, 103, 0);

            StreetAddressOneLabel.Text = "Street Address";
            StreetAddressLineTwoLabel.Text = "Street Address Line 2";
            CityLabel.Text = "City";
            StateProvinceLabel.Text = "State / Province";
            PostalZipCodeLabel.Text = "Postal / Zip Code";
            
            TypeOfBusinessLabel.Text = "Type of Business";
            TypeOfBusinessLabel.Padding = new Thickness(30, 30, 113, 0);

            OthersLabel.Text = "Others";
            OthersLabel.Padding = new Thickness(30, 23, 185, 0);
            //END OF: Body

            // Footer
            SubmitRegistratonButton.Text = "Register a Company";
            SuccessfulRegistrationCOMPANY.Text = "Company registration request has been submitted successfully!";

            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
        else if (selectedLanguage == "Bulgarian")
        {
            // Head BG
            RegisterBusinessLabel.Text = "Регистрирайте фирмата си";
            RegisterBusinessSubtitleLabel.Text = "Моля, предоставете всички необходими данни, за да регистрирате фирмата си в Main Thread Inc.";
            BusinessOwnerLabel.Text = "Собственик на фирмата"; //7
            BusinessOwnerLabel.Padding = new Thickness(30, 22, 55, 0);
            
            // Body BG
            FirstNameLabel.Text = "Име";
            LastNameLabel.Text = "Фамилия";

            PasswordLabel.Text = "Парола";
            PasswordLabel.Padding = new Thickness(30, 22, 176, 0);
            switch (passwordStrengthScore)
            {
                case PasswordScore.VeryWeak:
                    PasswordScoreLabel.Text = "Много слаба";
                    PasswordScoreLabel.TextColor = Colors.DimGray;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Weak:
                    PasswordScoreLabel.Text = "Слаба";
                    PasswordScoreLabel.TextColor = Colors.DarkRed;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Medium:
                    PasswordScoreLabel.Text = "Средна";
                    PasswordScoreLabel.TextColor = Colors.DarkOrange;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Strong:
                    PasswordScoreLabel.Text = "Силна";
                    PasswordScoreLabel.TextColor = Colors.MediumBlue;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.VeryStrong:
                    PasswordScoreLabel.Text = "Много силна";
                    PasswordScoreLabel.TextColor = Colors.ForestGreen;
                    PasswordScoreLabel.IsVisible = true;
                    break;
            }

            BusinessNameLabel.Text = "Име на фирмата";
            BusinessNameLabel.Padding = new Thickness(30, 22, 106, 0);

            ContactNumberLabel.Text = "Телефон за връзка";
            ContactNumberLabel.Padding = new Thickness(30, 22, 97, 0);

            EmailLabel.Text = "Електронна поща";
            EmailLabel.Padding = new Thickness(30, 22, 29, 0);

            SERLabel.Text = "Регистрация на \nдържавен субект #";
            SERLabel.Padding = new Thickness(30, 22, 92, 0);

            EINLabel.Text = "ЕГН";
            EINLabel.Padding = new Thickness(30, 22, 208, 0);

            AddressLabel.Text = "Адрес на компанията";
            AddressLabel.Padding = new Thickness(30, 22, 73, 0);

            StreetAddressOneLabel.Text = "Уличен адрес";
            StreetAddressLineTwoLabel.Text = "Уличен адрес ред 2";
            CityLabel.Text = "Град";
            StateProvinceLabel.Text = "Щат / Провинция";
            PostalZipCodeLabel.Text = "Пощенски код";

            TypeOfBusinessLabel.Text = "Вид на бизнеса";
            TypeOfBusinessLabel.Padding = new Thickness(30, 30, 118, 0);

            OthersLabel.Text = "Други";
            OthersLabel.Padding = new Thickness(30, 22, 192, 0);
            // END OF: Body BG

            // Footer
            SubmitRegistratonButton.Text = "Регистрирайте фирма";
            SubmitRegistratonButton.WidthRequest = 235;
            SuccessfulRegistrationCOMPANY.Text = "Заявката за регистрация на компания беше изпратена успешно!";

            FooterBG.IsVisible = true;
            FooterENG.IsVisible = false;
        }
        else
        {
            // Header
            RegisterBusinessLabel.Text = "Register Your Business";
            RegisterBusinessSubtitleLabel.Text = "Please provide all required details to register your business with Main Thread Inc.";
            BusinessOwnerLabel.Text = "Business Owner";
            BusinessOwnerLabel.Padding = new Thickness(30, 22, 120, 0);

            // Body
            FirstNameLabel.Text = "First Name";
            LastNameLabel.Text = "Last Name";

            PasswordLabel.Text = "Password";
            PasswordLabel.Padding = new Thickness(30, 22, 162, 0);
            switch (passwordStrengthScore)
            {
                case PasswordScore.VeryWeak:
                    PasswordScoreLabel.Text = "Very Weak";
                    PasswordScoreLabel.TextColor = Colors.DimGray;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Weak:
                    PasswordScoreLabel.Text = "Weak";
                    PasswordScoreLabel.TextColor = Colors.DarkRed;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Medium:
                    PasswordScoreLabel.Text = "Medium";
                    PasswordScoreLabel.TextColor = Colors.DarkOrange;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.Strong:
                    PasswordScoreLabel.Text = "Strong";
                    PasswordScoreLabel.TextColor = Colors.MediumBlue;
                    PasswordScoreLabel.IsVisible = true;
                    break;
                case PasswordScore.VeryStrong:
                    PasswordScoreLabel.Text = "Very Strong";
                    PasswordScoreLabel.TextColor = Colors.ForestGreen;
                    PasswordScoreLabel.IsVisible = true;
                    break;
            }

            BusinessNameLabel.Text = "Business Name";
            BusinessNameLabel.Padding = new Thickness(30, 22, 120, 0);

            ContactNumberLabel.Text = "Contact Number";
            ContactNumberLabel.Padding = new Thickness(30, 22, 120, 0);

            EmailLabel.Text = "E-mail";
            EmailLabel.Padding = new Thickness(30, 22, 120, 0);

            SERLabel.Text = "State Entity Registration #";
            SERLabel.Padding = new Thickness(30, 22, 48, 0);

            EINLabel.Text = "Employer Identification\nNumber";
            EINLabel.Padding = new Thickness(30, 22, 67, 0);

            AddressLabel.Text = "Company Address";
            AddressLabel.Padding = new Thickness(30, 22, 103, 0);

            StreetAddressOneLabel.Text = "Street Address";
            StreetAddressLineTwoLabel.Text = "Street Address Line 2";
            CityLabel.Text = "City";
            StateProvinceLabel.Text = "State / Province";
            PostalZipCodeLabel.Text = "Postal / Zip Code";

            TypeOfBusinessLabel.Text = "Type of Business";
            TypeOfBusinessLabel.Padding = new Thickness(30, 30, 113, 0);

            OthersLabel.Text = "Others";
            OthersLabel.Padding = new Thickness(30, 23, 185, 0);
            //END OF: Body

            // Footer
            SubmitRegistratonButton.Text = "Register a Company";
            SuccessfulRegistrationCOMPANY.Text = "Company registration request has been submitted successfully!";

            FooterENG.IsVisible = true;
            FooterBG.IsVisible = false;
        }
    }

    private void OnThemeChanged(string theme)
    {
        ClientSettingsVisuals.Instance.SelectedTheme = theme;

        if (theme == "Light")
        {
            // Form header
            RegisterBusinessLabel.TextColor = Colors.Black;

            // Row one
            BusinessOwnerLabel.TextColor = Colors.Black;
            FirstNameBox.ClearValue(Entry.BackgroundColorProperty);
            FirstNameBox.TextColor = Colors.Black;
            LastNameBox.ClearValue(Entry.BackgroundColorProperty);
            LastNameBox.TextColor = Colors.Black;

            // Row two
            PasswordLabel.TextColor = Colors.Black;
            PasswordBox.PlaceholderColor = Colors.LightGray;
            PasswordBox.ClearValue(Entry.BackgroundColorProperty);
            PasswordBox.TextColor = Colors.Black;

            // Row three
            BusinessNameLabel.TextColor = Colors.Black;
            BusinessNameBox.ClearValue(Entry.BackgroundColorProperty);
            BusinessNameBox.TextColor = Colors.Black;

            // Row four
            ContactNumberLabel.TextColor = Colors.Black;
            ContactNumberBox.PlaceholderColor = Colors.LightGray;
            ContactNumberBox.ClearValue(Entry.BackgroundColorProperty);
            ContactNumberBox.TextColor = Colors.Black;

            // Row five
            EmailLabel.TextColor = Colors.Black;
            EmailBox.PlaceholderColor = Colors.LightGray;
            EmailBox.ClearValue(Entry.BackgroundColorProperty);
            EmailBox.TextColor = Colors.Black;

            // Row six
            SERLabel.TextColor = Colors.Black;
            SERBox.PlaceholderColor = Colors.LightGray;
            SERBox.ClearValue(Entry.BackgroundColorProperty);
            SERBox.TextColor = Colors.Black;

            // Row seven
            EINLabel.TextColor = Colors.Black;
            PINBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;

            // Row eight
            AddressLabel.TextColor = Colors.Black;
            StreetAddressBox1.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            StreetAddressBox2.PlaceholderColor = Colors.LightGray;
            StreetAddressBox2.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            CityBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            ZipCodeBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            StateProvinceBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;

            // Row nine
            TypeOfBusinessLabel.TextColor = Colors.Black;
            CategoryPicker.ClearValue(Picker.BackgroundColorProperty);
            CategoryPicker.TextColor = Colors.Black;

            // Row ten
            OthersLabel.TextColor = Colors.Black;
            OthersBox.ClearValue(Entry.BackgroundColorProperty);
            OthersBox.TextColor = Colors.Black;

            // Form footer
            SubmitRegistratonButton.BackgroundColor = Color.FromArgb("#18bd5b");

            // Whole form
            Background.BackgroundColor = Colors.AliceBlue;
            FormBackground.BackgroundColor = Colors.White;
            colourInverted = false;
        }
        else if (theme == "Dark")
        {
            // Form header
            RegisterBusinessLabel.TextColor = Colors.White;
            
            // Row one
            BusinessOwnerLabel.TextColor = Colors.White;
            FirstNameBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            FirstNameBox.TextColor = Colors.WhiteSmoke;
            LastNameBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            LastNameBox.TextColor = Colors.WhiteSmoke;

            // Row two
            PasswordLabel.TextColor = Colors.White;
            PasswordBox.PlaceholderColor = Colors.Gray;
            PasswordBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            PasswordBox.TextColor = Colors.WhiteSmoke;

            // Row three
            BusinessNameLabel.TextColor = Colors.White;
            BusinessNameBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            BusinessNameBox.TextColor = Colors.WhiteSmoke;

            // Row four
            ContactNumberLabel.TextColor = Colors.White;
            ContactNumberBox.PlaceholderColor = Colors.Gray;
            ContactNumberBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            ContactNumberBox.TextColor = Colors.WhiteSmoke;

            // Row five
            EmailLabel.TextColor = Colors.White;
            EmailBox.PlaceholderColor = Colors.Gray;
            EmailBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            EmailBox.TextColor = Colors.WhiteSmoke;

            // Row six
            SERLabel.TextColor = Colors.White;
            SERBox.PlaceholderColor = Colors.Gray;
            SERBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            SERBox.TextColor = Colors.WhiteSmoke;

            // Row seven
            EINLabel.TextColor = Colors.White;
            PINBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            PINBox.TextColor = Colors.WhiteSmoke;

            // Row eight
            AddressLabel.TextColor = Colors.White;
            StreetAddressBox1.BackgroundColor = Color.FromArgb("#3b3b3b");
            StreetAddressBox1.TextColor = Colors.WhiteSmoke;
            StreetAddressBox2.PlaceholderColor = Colors.Gray;
            StreetAddressBox2.BackgroundColor = Color.FromArgb("#3b3b3b");
            StreetAddressBox2.TextColor = Colors.WhiteSmoke;
            CityBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            CityBox.TextColor = Colors.WhiteSmoke;
            ZipCodeBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            ZipCodeBox.TextColor = Colors.WhiteSmoke;
            StateProvinceBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            StateProvinceBox.TextColor = Colors.WhiteSmoke;

            // Row nine
            TypeOfBusinessLabel.TextColor = Colors.White;
            CategoryPicker.BackgroundColor = Color.FromArgb("#3b3b3b");
            CategoryPicker.TextColor = Colors.WhiteSmoke;

            // Row ten
            OthersLabel.TextColor = Colors.White;
            OthersBox.BackgroundColor = Color.FromArgb("#3b3b3b");
            OthersBox.TextColor = Colors.WhiteSmoke;

            // From footer
            SubmitRegistratonButton.BackgroundColor = Colors.BlueViolet;

            // Whole form
            Background.BackgroundColor = Color.FromArgb("#28282B");
            FormBackground.BackgroundColor = Color.FromArgb("#202124");
            colourInverted = true;
        }
        else
        {
            // Form header
            RegisterBusinessLabel.TextColor = Colors.Black;

            // Row one
            BusinessOwnerLabel.TextColor = Colors.Black;
            FirstNameBox.ClearValue(Entry.BackgroundColorProperty);
            FirstNameBox.TextColor = Colors.Black;
            LastNameBox.ClearValue(Entry.BackgroundColorProperty);
            LastNameBox.TextColor = Colors.Black;

            // Row two
            PasswordLabel.TextColor = Colors.Black;
            PasswordBox.PlaceholderColor = Colors.LightGray;
            PasswordBox.ClearValue(Entry.BackgroundColorProperty);
            PasswordBox.TextColor = Colors.Black;

            // Row three
            BusinessNameLabel.TextColor = Colors.Black;
            BusinessNameBox.ClearValue(Entry.BackgroundColorProperty);
            BusinessNameBox.TextColor = Colors.Black;

            // Row four
            ContactNumberLabel.TextColor = Colors.Black;
            ContactNumberBox.PlaceholderColor = Colors.LightGray;
            ContactNumberBox.ClearValue(Entry.BackgroundColorProperty);
            ContactNumberBox.TextColor = Colors.Black;

            // Row five
            EmailLabel.TextColor = Colors.Black;
            EmailBox.PlaceholderColor = Colors.LightGray;
            EmailBox.ClearValue(Entry.BackgroundColorProperty);
            EmailBox.TextColor = Colors.Black;

            // Row six
            SERLabel.TextColor = Colors.Black;
            SERBox.PlaceholderColor = Colors.LightGray;
            SERBox.ClearValue(Entry.BackgroundColorProperty);
            SERBox.TextColor = Colors.Black;

            // Row seven
            EINLabel.TextColor = Colors.Black;
            PINBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;

            // Row eight
            AddressLabel.TextColor = Colors.Black;
            StreetAddressBox1.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            StreetAddressBox2.PlaceholderColor = Colors.LightGray;
            StreetAddressBox2.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            CityBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            ZipCodeBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;
            StateProvinceBox.ClearValue(Entry.BackgroundColorProperty);
            PINBox.TextColor = Colors.Black;

            // Row nine
            TypeOfBusinessLabel.TextColor = Colors.Black;
            CategoryPicker.ClearValue(Picker.BackgroundColorProperty);
            CategoryPicker.TextColor = Colors.Black;

            // Row ten
            OthersLabel.TextColor = Colors.Black;
            OthersBox.ClearValue(Entry.BackgroundColorProperty);
            OthersBox.TextColor = Colors.Black;

            // Form footer
            SubmitRegistratonButton.BackgroundColor = Color.FromArgb("#18bd5b");

            // Whole form
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

        foreach (var row in formRows)
        {
            if (!colourInverted)
            {
                row.BackgroundColor = Colors.White;
            }
            else
            {
                row.BackgroundColor = Color.FromArgb("#202124");
            }
        }
    }

    // Functional methods - retrieve information from user input
    private void FirstNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerFirstNameINPUT = FirstNameBox.Text;
        companyInformation[0] = COMPANYownerFirstNameINPUT;
    }

    private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerLastNameINPUT = LastNameBox.Text;
        companyInformation[1] = COMPANYownerLastNameINPUT;
    }

    private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYuserpasswordINPUT = PasswordBox.Text;
        companyInformation[2] = COMPANYuserpasswordINPUT;

        if (companyInformation[2] == "" || companyInformation[2] == null)
        {
            PasswordScoreLabel.IsVisible = false;
            ShowEyeImage.IsVisible = false;
            HideEyeImage.IsVisible = false;
            ShowEyeLightImage.IsVisible = false;
            HideEyeLightImage.IsVisible = false;
            if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(-5, -1719, 20, 1600);
            else languageSelection.Margin = new Thickness(-5, -1780, 20, 1600);
            ShowEyeImage.Margin = new Thickness(-80, -41, 0, -40);
            HideEyeImage.Margin = new Thickness(-80, -41, 0, -40);
        }
        else
        {
            if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(0, -1731, 20, 1600);
            else languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
            ShowEyeImage.Margin = new Thickness(-80, -42, 0, -40);
            HideEyeImage.Margin = new Thickness(-81, -42, 0, -40);
            PasswordScoreLabel.IsVisible = true;

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

                if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(-5, -1731, 20, 1600);
                else languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
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

                if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(-5, -1731, 20, 1600);
                else languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
            }

            passwordStrengthScore = PasswordAdvisor.CheckStrength(companyInformation[2]);
            switch (passwordStrengthScore)
            {
                case PasswordScore.VeryWeak:
                    if (ClientSettingsVisuals.Instance.SelectedLanguage == "English") PasswordScoreLabel.Text = "Very Weak";
                    else PasswordScoreLabel.Text = "Много слаба";
                    PasswordScoreLabel.TextColor = Colors.DimGray;
                    break;

                case PasswordScore.Weak:
                    if (ClientSettingsVisuals.Instance.SelectedLanguage == "English") PasswordScoreLabel.Text = "Weak";
                    else PasswordScoreLabel.Text = "Слаба";
                    PasswordScoreLabel.TextColor = Colors.DarkRed;
                    break;

                case PasswordScore.Medium:
                    if (ClientSettingsVisuals.Instance.SelectedLanguage == "English") PasswordScoreLabel.Text = "Medium";
                    else PasswordScoreLabel.Text = "Средна";
                    PasswordScoreLabel.TextColor = Colors.DarkOrange;
                    break;

                case PasswordScore.Strong:
                    if (ClientSettingsVisuals.Instance.SelectedLanguage == "English") PasswordScoreLabel.Text = "Strong";
                    else PasswordScoreLabel.Text = "Силна";
                    PasswordScoreLabel.TextColor = Colors.MediumBlue;
                    break;

                case PasswordScore.VeryStrong:
                    if (ClientSettingsVisuals.Instance.SelectedLanguage == "English") PasswordScoreLabel.Text = "Very Strong";
                    else PasswordScoreLabel.Text = "Много силна";
                    PasswordScoreLabel.TextColor = Colors.ForestGreen;
                    break;
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

            if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(-5, -1731, 20, 1600);
            else languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
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

            if (!OthersBox.IsVisible) languageSelection.Margin = new Thickness(-5, -1731, 20, 1600);
            else languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
        }
    }

    private void BusinessNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYnameINPUT = BusinessNameBox.Text;
        companyInformation[3] = COMPANYnameINPUT;
    }

    private void ContactNumberBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerContactNumberINPUT = ContactNumberBox.Text;
        companyInformation[4] = COMPANYownerContactNumberINPUT;
    }

    private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerEmailINPUT = EmailBox.Text;
        companyInformation[5] = COMPANYownerEmailINPUT;
    }

    private void SERBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYSERNumberINPUT = SERBox.Text;
        companyInformation[6] = COMPANYSERNumberINPUT;
    }

    private void PINBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYemployerPININPUT = PINBox.Text;
        companyInformation[7] = COMPANYemployerPININPUT;
    }

    private void StreetAddressBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYstreetAddressOneINPUT = StreetAddressBox1.Text;
        companyInformation[8] = COMPANYstreetAddressOneINPUT;
    }

    private void StreetAddressBox2_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYstreetAddressTwoINPUT = StreetAddressBox2.Text;   // Can be null
        companyInformation[9] = COMPANYstreetAddressTwoINPUT;
    }

    private void CityBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYcityINPUT = CityBox.Text;
        companyInformation[10] = COMPANYcityINPUT;
    }

    private void StateProvinceBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYstateProvinceINPUT = StateProvinceBox.Text;
        companyInformation[11] = COMPANYstateProvinceINPUT;
    }

    private void ZipCodeBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYzipCodeINPUT = ZipCodeBox.Text;
        companyInformation[12] = COMPANYzipCodeINPUT;
    }

    private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CategoryPicker.SelectedItem != null)
        {
            string selectedCategory = CategoryPicker.SelectedItem.ToString();

            if (selectedCategory == "Others, please specify below")
            {
                OthersLabel.IsVisible = true;
                OthersBox.IsVisible = true;

                if ((HideEyeImage.IsVisible || ShowEyeImage.IsVisible) || (HideEyeLightImage.IsVisible || ShowEyeLightImage.IsVisible)) languageSelection.Margin = new Thickness(-5, -1791, 20, 1600);
                else languageSelection.Margin = new Thickness(-5, -1781, 20, 1600);
            }
            else
            {
                OthersLabel.IsVisible = false;
                OthersBox.IsVisible = false;
                if (companyInformation[13] != null)
                {
                    companyInformation[13] = "";
                }

                if ((HideEyeImage.IsVisible || ShowEyeImage.IsVisible) || (HideEyeLightImage.IsVisible || ShowEyeLightImage.IsVisible)) languageSelection.Margin = new Thickness(-5, -1731, 20, 1600);
                else languageSelection.Margin = new Thickness(-5, -1719, 20, 1600);
            }

            companyInformation[13] = selectedCategory;
        }
    }

    private void OthersBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYcategoryINPUT = OthersBox.Text;   // Can be null
        companyInformation[14] = COMPANYcategoryINPUT;
    }

    private bool CheckCredentials()
    {
        // Run checks for each element HERE --[successful]--> register a company [write to database]
        // If needed move checks to BLL

        int count = 0;
        foreach (string information in companyInformation)
        {
            // Check for a valid type of business
            if (information == "Please Select")
            {
                DisplayAlert("Alert", "Please select a type of business.", "OK");
                return false;
            }
            // Check if the type of business is specified
            else if (information == "Others, please specify below" && companyInformation[14] == null)
            {
                DisplayAlert("Alert", "Please specify the type of business.", "OK");
                return false;
            }

            // Check if any field is empty
            if (string.IsNullOrEmpty(information) && count != 14)
            {
                if (count != 9) // Skip check if Street Address Line 2 is empty
                {
                    DisplayAlert("Alert", "There are one or multiple empty fields.\nPlease fill them in.", "OK");
                    return false;
                }
            }
            count++;
        }

        // Check for valid input for first name
        if (!companyInformation[0].All(char.IsLetter))
        {
            DisplayAlert("Alert", "First name contains invalid characters.\nPlease enter a valid first name.", "OK");
            return false;
        }
        else if (companyInformation[0].Length < 3)
        {
            DisplayAlert("Alert", "First name is too short.\nPlease enter a valid first name.", "OK");
            return false;
        }


        // Check for valid input for last name
        if (!companyInformation[1].All(char.IsLetter))
        {
            DisplayAlert("Alert", "Last name contains invalid characters.\nPlease enter a valid last name.", "OK");
            return false;
        }
        else if (companyInformation[1].Length < 3)
        {
            DisplayAlert("Alert", "Last name is too short.\nPlease enter a valid last name.", "OK");
            return false;
        }


        // Check for a valid password
        if (companyInformation[2].Length < 8)
        {
            DisplayAlert("Alert", "Password can not be under 8 symbols.\nPlease enter a valid password.", "OK");
            return false;
        }
        else if (!Regex.IsMatch(companyInformation[2], @"[a-z]"))
        {
            DisplayAlert("Alert", "Password must include at least one lowercase letter.\nPlease enter a valid password.", "OK");
            return false;
        }
        else if (!Regex.IsMatch(companyInformation[2], @"[A-Z]"))
        {
            DisplayAlert("Alert", "Password must include at least one uppercase letter.\nPlease enter a valid password.", "OK");
            return false;
        }
        else if (!Regex.IsMatch(companyInformation[2], @"\d"))
        {
            DisplayAlert("Alert", "Password must include at least one number.\nPlease enter a valid password.", "OK");
            return false;
        }
        else if (!Regex.IsMatch(companyInformation[2], @"[^\w]"))
        {
            DisplayAlert("Alert", "Password must include at least one special character.\nPlease enter a valid password.", "OK");
            return false;
        }

        // Check for a valid business name
        if (companyInformation[3].Length < 3)
        {
            DisplayAlert("Alert", "Business name is too short.\nPlease enter a valid business name.", "OK");
            return false;
        }


        // Check for a valid number of characters in the contact number
        if (!companyInformation[4].All(char.IsDigit))
        {
            DisplayAlert("Alert", "Contact number contains invalid characters.\nPlease enter a valid contact number.", "OK");
            return false;
        }
        else if (companyInformation[4].Length < 10)
        {
            DisplayAlert("Alert", "Contact number is too short.\nPlease enter a valid contact number.", "OK");
            return false;
        }


        // Check for a valid email address
        if(!companyInformation[5].Contains("@") || !companyInformation[5].Contains("."))
        {
            DisplayAlert("Alert", "Invalid email address.\nPlease enter a valid email address.", "OK");
            return false;
        }


        // Check for a valid State Entity Registration number
        if (!companyInformation[6].All(char.IsLetterOrDigit))
        {
            DisplayAlert("Alert", "State Entity Registration number contains invalid characters.\nPlease enter a valid number.", "OK");
            return false;
        }
        else if (companyInformation[6].Length < 10)
        {
            DisplayAlert("Alert", "State Entity Registration number is too short.\nPlease enter a valid number.", "OK");
            return false;
        }


        // Check for a valid Employer Identification Number
        if (!companyInformation[7].All(char.IsDigit))
        {
            DisplayAlert("Alert", "Employer Identification Number contains invalid characters.\nPlease enter a valid number.", "OK");
            return false;
        }
        else if (companyInformation[7].Length < 10)
        {
            DisplayAlert("Alert", "Employer Identification Number is too short.\nPlease enter a valid number.", "OK");
            return false;
        }


        // Check for a valid company address
        if (companyInformation[8].Length < 10)
        {
            DisplayAlert("Alert", "Street Address is too short.\nPlease enter a valid street address", "OK");
            return false;
        }


        // Check for a valid city value
        if (!companyInformation[10].All(char.IsLetter))
        {
            DisplayAlert("Alert", "City name contains invalid characters.\nPlease enter a valid city name", "OK");
            return false;
        }
        else if (companyInformation[10].Length < 3)
        {
            DisplayAlert("Alert", "City name is too short.\nPlease enter a valid city name", "OK");
            return false;
        }


        // Check for a valid State/Province value
        if (!companyInformation[11].All(char.IsLetter))
        {
            DisplayAlert("Alert", "State / Province name contains invalid characters.\nPlease enter a valid state / province name", "OK");
            return false;
        }
        else if (companyInformation[11].Length < 3)
        {
            DisplayAlert("Alert", "State / Province name is too short.\nPlease enter a valid state / province name", "OK");
            return false;
        }


        // Check for a valid ZIP code
        if (!companyInformation[12].All(char.IsDigit))
        {
            DisplayAlert("Alert", "ZIP Code number contains invalid characters.\nPlease enter a valid ZIP code.", "OK");
            return false;
        }
        else if (companyInformation[12].Length < 4)
        {
            DisplayAlert("Alert", "ZIP Code number is too short.\nPlease enter a valid ZIP code.", "OK");
            return false;
        }


        return true;
    }

    private void SubmitRegistratonButton_Clicked(object sender, EventArgs e)
    {
        bool registrationSuccessful = CheckCredentials();

        // Write company register information to Debug window
        foreach (string information in companyInformation)
        {
            Debug.WriteLine(information);
        }

        if (registrationSuccessful)
        {
            SuccessfulRegistrationCOMPANY.IsVisible = true;
            DisplayAlert("Pending Approval", "Your company registration is currently under review by our team.\nWe appreciate your request and will notify you once the approval process is complete.", "OK");
        }
        else SuccessfulRegistrationCOMPANY.IsVisible = false;
    }

    // Design methods - enhance user experience
    private void FirstNameBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void LastNameBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void FirstNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowOne.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void LastNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowOne.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowOne.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void PasswordBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowTwo.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowTwo.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void PasswordBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowTwo.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowTwo.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void BusinessNameBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowThree.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowThree.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void BusinessNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowThree.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowThree.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void ContactNumberBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowFour.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowFour.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void ContactNumberBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowFour.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowFour.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void EmailBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowFive.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowFive.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void EmailBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowFive.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowFive.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void SERBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowSix.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowSix.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void SERBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowSix.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowSix.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void PINBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowSeven.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowSeven.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void PINBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowSeven.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowSeven.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void StreetAddressBox1_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void StreetAddressBox1_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void StreetAddressBox2_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void StreetAddressBox2_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void CityBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void CityBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void StateProvinceBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void StateProvinceBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void ZipCodeBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void ZipCodeBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowEight.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowEight.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void CategoryPicker_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowNine.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowNine.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void CategoryPicker_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowNine.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowNine.BackgroundColor = Color.FromArgb("#202124");
        }
    }

    private void OthersBox_Focused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowTen.BackgroundColor = Color.FromArgb("#f1f5ff");
        }
        else
        {
            FormRowTen.BackgroundColor = Color.FromArgb("#343434");
        }
    }

    private void OthersBox_Unfocused(object sender, FocusEventArgs e)
    {
        if (!colourInverted)
        {
            FormRowTen.BackgroundColor = Colors.White;
        }
        else
        {
            FormRowTen.BackgroundColor = Color.FromArgb("#202124");
        }
    }

}
