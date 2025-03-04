using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.Shared.ViewModels;
using OneOf;

namespace Main_Thread.BLL.Contracts.IPageHandlers
{
    public interface IRegisterPageHandler
    {
        OneOf<BusinessVm, string[]> OnRegisterButtonClicked(string ownerFirstName, string ownerLastName, string password, string businessName, string contactNumber, string email, string stateEntityRegistration, string employerIdentificationNumber, string streetAddressOne, string streetAddressTwo, string city, string stateProvince, string zipCode, string businessType, string otherBusinessType);
    }
}