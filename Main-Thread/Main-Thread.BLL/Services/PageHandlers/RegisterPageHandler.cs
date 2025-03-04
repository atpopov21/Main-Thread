using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.BLL.Contracts.IPageHandlers;
using Main_Thread.BLL.Services.Authentication;
using Main_Thread.Shared.ViewModels;
using OneOf;

namespace Main_Thread.BLL.Services.PageHandlers
{
    public class RegisterPageHandler : IRegisterPageHandler
    {
        public OneOf<BusinessVm, string[]> OnRegisterButtonClicked(string ownerFirstName, string ownerLastName, string password, string businessName, string contactNumber, string email, string stateEntityRegistration, string employerIdentificationNumber, string streetAddressOne, string streetAddressTwo, string city, string stateProvince, string zipCode, string businessType, string otherBusinessType)
        {
            RegisterService service = new RegisterService();
            if (!service.IsValidName(ownerFirstName))
            {
                return new string[] { "Invalid first name", "Please enter a valid name.", "OK" };
            }

            if (!service.IsValidName(ownerLastName))
            {
                return new string[] { "Invalid last name", "Please enter a valid name.", "OK" };
            }
            
            if (!service.IsValidPassword(password))
            {
                return new string[] { "Invalid password", "Please enter a valid password.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(businessName))
            {
                return new string[] { "No Business Name", "Please enter a name for your business.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                return new string[] { "No Contact Number", "Please enter a contact number.", "OK" };
            }

            if (!service.IsValidEmail(email))
            {
                return new string[] { "Invalid email", "Please enter a valid email address.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(stateEntityRegistration) || stateEntityRegistration.Length != 9)
            {
                return new string[] { "No State Entity Registration Number", "Please enter your business's state entity registration number.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(employerIdentificationNumber) || employerIdentificationNumber.Length != 9)
            {
                return new string[] { "No Employer Identification Number", "Please enter your EIN.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(streetAddressOne))
            {
                return new string[] { "No Street Address", "Please enter a business street address.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(city))
            {
                return new string[] { "No City Address", "Please enter the city the street address is in.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(stateProvince))
            {
                return new string[] { "No State/Province", "Please enter the state or province your business is located within.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length != 5)
            {
                return new string[] { "No Zip Code", "Please enter a valid zip code.", "OK" };
            }
            
            if (string.IsNullOrWhiteSpace(businessType))
            {
                return new string[] { "No Contact Number", "Please enter a contact number.", "OK" };
            }
            
            return new BusinessVm() {
                OwnerFirstName = ownerFirstName,
                OwnerLastName = ownerLastName,
                Password = password,
                BusinessName = businessName,
                ContactNumber = contactNumber,
                Email = email,
                StateEntityRegistration = stateEntityRegistration,
                EmployerIdentificationNumber = employerIdentificationNumber,
                StreetAddressOne = streetAddressOne,
                StreetAddressTwo = streetAddressTwo,
                City = city,
                StateProvince = stateProvince,
                ZipCode = zipCode,
                BusinessType = businessType,
                OtherBusinessType = otherBusinessType,
            };
        }
    }
}