using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using System.Windows.Input;

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

    }

}
