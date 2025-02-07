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
}