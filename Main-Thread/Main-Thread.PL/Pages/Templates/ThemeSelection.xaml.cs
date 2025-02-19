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
            if (selectedTheme == "Light")
            {
                ThemeSwitch.IsToggled = false;
            }
            else if (selectedTheme == "Dark")
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
                themeSelection = "Light";
                ThemeLabel.Text = "Light";
                
                ThemeChanged?.Invoke(themeSelection);
            }
            else
            {
                themeSelection = "Dark";
                ThemeLabel.Text = "Dark";
                
                ThemeChanged?.Invoke(themeSelection);
            }
        }

        public void UpdateTheme(string theme)
        {
            if (theme == "Light")
            {
                Background.BackgroundColor = Colors.White;
                HiddenText.BackgroundColor = Colors.White;
                ThemeLabel.TextColor = Colors.Black;
            }
            else if (theme == "Dark")
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
    }
}