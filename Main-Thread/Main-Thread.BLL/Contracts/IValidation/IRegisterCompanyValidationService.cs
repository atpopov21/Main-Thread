using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.Shared.InputModels;

namespace Main_Thread.BLL.Contracts.IValidation
{
    public interface IRegisterCompanyValidationService
    {
        string ValidateCompanyInput(RegisterCompanyIM inputModel);
    }
}
