using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.Shared.ViewModels;

namespace Main_Thread.BLL.Contracts.IAuthentication
{
    public interface ILoginService
    {
        bool CheckPassword(string iPassword, string uPassword);
        bool CheckEmail(string iEmail, string uEmail);
        BusinessVm LoginValidation(string email, string password);
    }
}