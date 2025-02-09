using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using System.Windows.Input;
using Main_Thread.PL.Pages;

namespace Main_Thread.PL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainThreadLogo.BackgroundColor = Color.Parse("Transparent");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Window.MinimumHeight = 600;
            this.Window.MinimumWidth = 1000;
        }

        private void Register_Company_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterCompany());
        }

        private void Login_Company_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginToCompany());
        }
    }

}
