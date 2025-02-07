using System.Windows.Input;

namespace Main_Thread.PL
{
    public partial class MainPage : ContentPage
    {
        // Links to the developers' social media profiles and application repository
        public ICommand ClickedDevOne => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand ClickedDevTwo => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand ClickedGitHubRepository => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand ClickedDiscussAndSupport => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand ClickedSecurityPolicy => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            BoxView[] leftStripes = { StripeOneL, StripeTwoL, StripeThreeL, StripeFourL, StripeFiveL, StripeSixL, StripeSevenL, StripeEigthL, StripeNineL, StripeTenL, StripeElevenL };
            BoxView[] rightStripes = { StripeOneR, StripeTwoR, StripeThreeR, StripeFourR, StripeFiveR, StripeSixR, StripeSevenR, StripeEigthR, StripeNineR, StripeTenR, StripeElevenR };
            StripesDetailsGenerator(leftStripes);
            StripesDetailsGenerator(rightStripes);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Window.MinimumHeight = 600;
            this.Window.MinimumWidth = 1000;
        }

        private void StripesDetailsGenerator(BoxView[] stripes)
        {
            foreach (BoxView stripe in stripes)
            {
                Random randomValue = new Random();
                int randomLength = randomValue.Next(50, 380);
                Color randomColor = Color.FromRgb(randomValue.Next(150, 235), randomValue.Next(140, 235), randomValue.Next(150, 235));
                stripe.WidthRequest = randomLength;
                stripe.BackgroundColor = randomColor;
            }
        }
    }

}
