using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.BLL.Contracts.IValidation;
using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.BLL.Services.PageHandlers;
using Main_Thread.BLL.Services.Validation;
using Main_Thread.BLL.Services.Authentication;
using Main_Thread.BLL.Contracts.ISecurity;
using Main_Thread.BLL.Services.Security;
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
            services.AddSingleton<IHomePageService, HomePageService>();
            services.AddSingleton<ICryptographyService, CryptographyService>();

            // Pages
            services.AddSingleton<MainPage>();
            services.AddSingleton<RegisterCompany>();
            services.AddSingleton<LoginToCompany>();
            services.AddSingleton<HomePage>();
            //services.AddSingleton<EmployeesManagement>();

            return builder.Build();
        }
    }
}
