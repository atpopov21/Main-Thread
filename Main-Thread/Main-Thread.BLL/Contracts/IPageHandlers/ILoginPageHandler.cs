using Main_Thread.Shared.ViewModels;
using Main_Thread.Shared.ViewModels;

namespace Main_Thread.BLL.Contracts.IPageHandlers;

public interface ILoginPageHandler
{
    BusinessVm LoginButtonFunc(string email, string password);
}