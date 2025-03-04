using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.Shared.InputModels;

namespace Main_Thread.BLL.Contracts.IAuthentication
{
    public interface IRegisterService
    {
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
        
        public void CreateBusiness(BusinessIm business);
    }
}