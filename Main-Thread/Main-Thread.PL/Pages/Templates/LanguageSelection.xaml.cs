using Main_Thread.PL.Pages.Resources;

namespace Main_Thread.PL.Pages.Templates
{
    public partial class LanguageSelection : ContentView
    {
        private string languageSelection = "";
        private string selectedLanguage = ClientSettingsVisuals.Instance.SelectedLanguage;

        // Define the event
        public event Action<string> LanguageChanged;

        public LanguageSelection()
        {
            InitializeComponent();
            LanguageHanlder();
        }

        private void LanguageHanlder()
        {
            if (selectedLanguage == "English")
            {
                EnglishCheckbox.IsChecked = true;
            }
            else if (selectedLanguage == "Bulgarian")
            {
                BulgarianCheckbox.IsChecked = true;
            }
            else
            {
                EnglishCheckbox.IsChecked = true;
            }
        }

        private void EnglishCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                languageSelection = "English";
                LanguageChanged?.Invoke(languageSelection);
            }
        }

        private void BulgarianCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                languageSelection = "Bulgarian";
                LanguageChanged?.Invoke(languageSelection);
            }
        }
    }
}