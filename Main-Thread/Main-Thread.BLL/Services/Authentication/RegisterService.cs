using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.BLL.Contracts;
using System.Text.RegularExpressions;
using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.DAL.Implementations;
using Main_Thread.DAL.Contracts;
using Main_Thread.Shared.InputModels;
using Main_Thread.DAL.Models;
using Main_Thread.BLL.Services.Security;
using Main_Thread.BLL.Contracts.ISecurity;

namespace Main_Thread.BLL.Services.Authentication;

public class RegisterService : IRegisterService
{
    private readonly IBusinessRepository _businessRepository = new BusinessRepository(); // Injected from DAL
    private readonly ICryptographyService _cryptographyService;

    public RegisterService(IBusinessRepository businessRepository, ICryptographyService cryptographyService)
    {
        _businessRepository = businessRepository; // DAL repository injected
        _cryptographyService = cryptographyService;
    }

    public RegisterService()
    {
        throw new NotImplementedException();
    }


    // Regular expression(Regex) for validating a name
    private static readonly Regex NameRegex = new Regex(
        @"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžæÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

    // Function to validate NAME using Regex
    public bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        // Check if the NAME matches the regex pattern
        return NameRegex.IsMatch(name);
    }
    
    
    // Function to validate EMAIL using Regex
    public bool IsValidEmail(string email)
    {
        // Check for blank input
        if (string.IsNullOrWhiteSpace(email) || email.Length > 256)
        {
            return false;
        }

        // Regular expression(Regex) for Email Validation
        string emailPatternRegex =
            ("^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

        // Check if the EMAIL matches the regex pattern
        return Regex.IsMatch(email, emailPatternRegex);
    }

    
    // Regular expression(Regex) for Password Validation
    private static readonly Regex PasswordRegex = new Regex(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,20}$",
        RegexOptions.Compiled);

    // Function to validate PASSWORD using Regex
    public bool IsValidPassword(string password)
    {
        // Check for blank input
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 100)
        {
            return false;
        }

        // Check if the PASSWORD matches the regex pattern
        return PasswordRegex.IsMatch(password);
    }
    
    
    public void CreateBusiness(BusinessIm business)
    {
        CryptographyService service = new CryptographyService();
        
        var newBusiness = new Business()
        {
            OwnerFirstName = business.OwnerFirstName,
            OwnerLastName = business.OwnerLastName,
            Password = service.ComputeSha256Hash(business.Password),
            Email = business.Email,
        };
        
        this._businessRepository.CreateBusinessAsync(newBusiness);
    }
}