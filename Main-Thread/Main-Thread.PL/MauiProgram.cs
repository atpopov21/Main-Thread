using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.BLL.Contracts.IValidation;
using Main_Thread.BLL.Services.Validation;
using Main_Thread.BLL.Services.Authentication;
using Main_Thread.PL.Pages;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Main_Thread.PL
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var services = builder.Services;

            // Services
            services.AddSingleton<IRegisterCompanyValidationService, RegisterCompanyValidationService>();
            services.AddSingleton<ILoginService, LoginService>();

            // Pages
            services.AddSingleton<MainPage>();
            services.AddSingleton<RegisterCompany>();
            services.AddSingleton<LoginToCompany>();

            return builder.Build();
        }
    }
}
