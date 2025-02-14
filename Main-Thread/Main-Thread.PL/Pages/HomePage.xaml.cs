using Main_Thread.PL.Pages.Resources;
using System.Diagnostics;	// SHOULD be removed in production

namespace Main_Thread.PL.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        //OnLanguageChanged(ClientSettingsVisuals.Instance.SelectedLanguage);
    }
}