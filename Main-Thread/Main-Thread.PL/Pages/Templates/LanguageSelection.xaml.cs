using System;

namespace Main_Thread.PL.Pages.Templates
{
    public partial class LanguageSelection : ContentView
    {
        public string languageSelection = "";

        // Define the event
        public event Action<string> LanguageChanged;

        public string GetLanguageSelection()
        {
            return languageSelection;
        }

        public LanguageSelection()
        {
            InitializeComponent();
            EnglishCheckbox.IsChecked = true;
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