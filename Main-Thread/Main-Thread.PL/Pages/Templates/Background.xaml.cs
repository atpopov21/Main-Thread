namespace Main_Thread.PL.Pages.Templates;

public partial class Background : ContentView
{
	public Background()
	{
		InitializeComponent();

        BoxView[] leftStripes = { StripeOneL, StripeTwoL, StripeThreeL, StripeFourL, StripeFiveL, StripeSixL, StripeSevenL, StripeEigthL, StripeNineL, StripeTenL, StripeElevenL };
        BoxView[] rightStripes = { StripeOneR, StripeTwoR, StripeThreeR, StripeFourR, StripeFiveR, StripeSixR, StripeSevenR, StripeEigthR, StripeNineR, StripeTenR, StripeElevenR };
        StripesDetailsGenerator(leftStripes);
        StripesDetailsGenerator(rightStripes);
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