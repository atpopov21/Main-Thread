using Main_Thread.PL.Pages.Resources;
using System.Windows.Input;

namespace Main_Thread.PL.Pages.Templates;

public partial class Footer : ContentView
{
    // Links to the developers' social media profiles and application repository
    public ICommand ClickedDevOne => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    public ICommand ClickedDevTwo => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    public ICommand ClickedGitHubRepository => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    public ICommand ClickedDiscussAndSupport => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    public ICommand ClickedSecurityPolicy => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    
    public Footer()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public void UpdateTheme(string theme)
    {
        if (theme == "Light")
        {
            PageBackground.BackgroundColor = Colors.AliceBlue;
        }
        else if (theme == "Dark")
        {
            PageBackground.BackgroundColor = Color.FromArgb("#28282B");
        }
        else
        {
            PageBackground.BackgroundColor = Colors.AliceBlue;
        }
    }
}