using Main_Thread.PL.Pages;

namespace Main_Thread.PL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
