using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.BLL.Services.Authentication;
using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.Shared.ViewModels;
namespace Main_Thread.BLL.Services.PageHandlers;

public class LoginPageHandler : ILoginPageHandler
{
    public static readonly ILoginService LoginService = new LoginService();
    public BusinessVm LoginButtonFunc(string email, string password)
    {
        return LoginService.LoginValidation(email, password);
    }
}