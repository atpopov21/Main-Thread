using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.BLL.Contracts;
using System.Text.RegularExpressions;
using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.DAL.Data;
using Main_Thread.BLL.Services.Security;
using Main_Thread.BLL.Contracts.ISecurity;
using Main_Thread.Shared.ViewModels;
using Main_Thread.DAL;
using Main_Thread.Shared;

namespace Main_Thread.BLL.Services.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly DbContext _context = new DbContext();
        private readonly ICryptographyService _cryptographyService = new CryptographyService();

        public bool CheckPassword(string iPassword, string uPassword) {
            return _cryptographyService.ComputeSha256Hash(iPassword) == uPassword;
        }

        public bool CheckEmail(string iEmail, string uEmail) {
            return _cryptographyService.ComputeSha256Hash(iEmail) == uEmail;
        }

        public BusinessVm LoginValidation(string email, string password) {
            foreach (var business in _context.Businesses)
            {
                if (CheckEmail(email, business.Email) && CheckPassword(password, business.Password))
                {
                    return new BusinessVm
                    {
                        Id = business.Id,
                        OwnerFirstName = business.OwnerFirstName,
                        OwnerLastName = business.OwnerLastName,
                        Password = business.Password,
                        BusinessName = business.BusinessName,
                        ContactNumber = business.ContactNumber,
                        Email = business.Email,
                        StateEntityRegistration = business.StateEntityRegistration,
                        EmployerIdentificationNumber = business.EmployerIdentificationNumber,
                        StreetAddressOne = business.StreetAddressOne,
                        StreetAddressTwo = business.StreetAddressTwo,
                        City = business.City,
                        StateProvince = business.StateProvince,
                        ZipCode = business.ZipCode,
                        BusinessType = business.BusinessType,
                        OtherBusinessType = business.OtherBusinessType,
                    };
                }
            }
            return new BusinessVm();
        }
    }
}