using Main_Thread.PL.Pages.Resources;

namespace Main_Thread.PL.Pages.Templates
{
    public partial class ThemeSelection : ContentView
    {
        private string themeSelection = "";
        private string selectedTheme = ClientSettingsVisuals.Instance.SelectedTheme;

        // Define the event
        public event Action<string> ThemeChanged;

        public ThemeSelection()
        {
            InitializeComponent();
            ThemeHanlder();
            UpdateTheme(ClientSettingsVisuals.Instance.SelectedTheme);
        }

        private void ThemeHanlder()
        {
            if (selectedTheme == "Light" || selectedTheme == "Светло")
            {
                ThemeSwitch.IsToggled = false;
            }
            else if (selectedTheme == "Dark" || selectedTheme == "Тъмно")
            {
                ThemeSwitch.IsToggled = true;
            }
            else
            {
                ThemeSwitch.IsToggled = false;
            }
        }

        private void ThemeSwitched(object sender, ToggledEventArgs e)
        {
            if (!e.Value)
            {
                UpdateLanguage(ClientSettingsVisuals.Instance.SelectedLanguage);
                ThemeChanged?.Invoke(themeSelection);
            }
            else
            {
                UpdateLanguage(ClientSettingsVisuals.Instance.SelectedLanguage);
                ThemeChanged?.Invoke(themeSelection);
            }
        }

        public void UpdateTheme(string theme)
        {
            if (theme == "Light" || theme == "Светло")
            {
                Background.BackgroundColor = Colors.White;
                HiddenText.BackgroundColor = Colors.White;
                ThemeLabel.TextColor = Colors.Black;
            }
            else if (theme == "Dark" || theme == "Тъмно")
            {
                Background.BackgroundColor = Color.FromArgb("#28282B");
                HiddenText.BackgroundColor = Color.FromArgb("#28282B");
                ThemeLabel.TextColor = Colors.White;
            }
            else
            {
                Background.BackgroundColor = Colors.White;
                HiddenText.BackgroundColor = Colors.White;
                ThemeLabel.TextColor = Colors.Black;
            }
        }

        public void UpdateLanguage(string language)
        {
            if (language == "English")
            {
                if (ThemeSwitch.IsToggled)
                {
                    themeSelection = "Dark";
                    ThemeLabel.Text = "Dark";
                    Background.WidthRequest = 100;
                }
                else
                {
                    themeSelection = "Light";
                    ThemeLabel.Text = "Light";
                    Background.WidthRequest = 100;
                }
            }
            else if (language == "Bulgarian")
            {
                if (ThemeSwitch.IsToggled)
                {
                    themeSelection = "Тъмно";
                    ThemeLabel.Text = "Тъмно";
                    Background.WidthRequest = 115;
                }
                else
                {
                    themeSelection = "Светло";
                    ThemeLabel.Text = "Светло";
                    Background.WidthRequest = 115;
                }
            }
            else
            {
                if (ThemeSwitch.IsToggled)
                {
                    themeSelection = "Dark";
                    ThemeLabel.Text = "Dark";
                    Background.WidthRequest = 100;
                }
                else
                {
                    themeSelection = "Light";
                    ThemeLabel.Text = "Light";
                    Background.WidthRequest = 100;
                }
            }
        }
    }
}