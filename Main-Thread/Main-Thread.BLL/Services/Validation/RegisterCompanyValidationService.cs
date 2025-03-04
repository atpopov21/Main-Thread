using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Main_Thread.BLL.Contracts.IValidation;
using Main_Thread.Shared.InputModels;

namespace Main_Thread.BLL.Services.Validation
{
    public class RegisterCompanyValidationService : IRegisterCompanyValidationService
    {
        public string ValidateCompanyInput(BusinessIm inputModel)
        {
            // Get all properties of the input model
            PropertyInfo[] properties = inputModel.GetType().GetProperties();

            int count = 0;
            foreach (var property in properties)
            {
                var value = property.GetValue(inputModel);

                // Check for a valid type of business
                if (Convert.ToString(value) == "Please Select")
                {
                    return "Please select a type of business.";
                }
                // Check if the type of business is specified
                else if (Convert.ToString(value) == "Others, please specify below" && inputModel.OtherBusinessType == null)
                {
                    return "Please specify the type of business.";
                }

                // Check if any field is empty
                if (string.IsNullOrEmpty(Convert.ToString(value)) && count != 14)
                {
                    if (count != 9) // Skip check if Street Address Line 2 is empty
                    {
                        return "There are one or multiple empty fields.\nPlease fill them in.";
                    }
                }
                count++;
            }


            // Check for valid input for first name
            if (!inputModel.OwnerFirstName.All(char.IsLetter))
            {
                return "First name contains invalid characters.\nPlease enter a valid first name.";
            }
            else if (inputModel.OwnerFirstName.Length < 3)
            {
                return "First name is too short.\nPlease enter a valid first name.";
            }


            // Check for valid input for last name
            if (!inputModel.OwnerLastName.All(char.IsLetter))
            {
                return "Last name contains invalid characters.\nPlease enter a valid last name.";
            }
            else if (inputModel.OwnerLastName.Length < 3)
            {
                return "Last name is too short.\nPlease enter a valid last name.";
            }


            // Check for a valid password
            if (inputModel.Password.Length < 8)
            {
                return "Password can not be under 8 symbols.\nPlease enter a valid password.";
            }
            else if (!Regex.IsMatch(inputModel.Password, @"[a-z]"))
            {
                return "Password must include at least one lowercase letter.\nPlease enter a valid password.";
            }
            else if (!Regex.IsMatch(inputModel.Password, @"[A-Z]"))
            {
                return "Password must include at least one uppercase letter.\nPlease enter a valid password.";
            }
            else if (!Regex.IsMatch(inputModel.Password, @"\d"))
            {
                return "Password must include at least one number.\nPlease enter a valid password.";
            }
            else if (!Regex.IsMatch(inputModel.Password, @"[^\w]"))
            {
                return "Password must include at least one special character.\nPlease enter a valid password.";
            }


            // Check for a valid business name
            if (inputModel.BusinessName.Length < 3)
            {
                return "Business name is too short.\nPlease enter a valid business name.";
            }


            // Check for a valid number of characters in the contact number
            if (!inputModel.ContactNumber.All(char.IsDigit))
            {
                return "Contact number contains invalid characters.\nPlease enter a valid contact number.";
            }
            else if (inputModel.ContactNumber.Length < 10)
            {
                return "Contact number is too short.\nPlease enter a valid contact number.";
            }


            // Check for a valid email address
            if (!inputModel.Email.Contains("@") || !inputModel.Email.Contains("."))
            {
                return "Invalid email address.\nPlease enter a valid email address.";
            }


            // Check for a valid State Entity Registration number
            if (!inputModel.StateEntityRegistration.All(char.IsLetterOrDigit))
            {
                return "State Entity Registration number contains invalid characters.\nPlease enter a valid number.";
            }
            else if (inputModel.StateEntityRegistration.Length < 10)
            {
                return "State Entity Registration number is too short.\nPlease enter a valid number.";
            }


            // Check for a valid Employer Identification Number
            if (!inputModel.EmployerIdentificationNumber.All(char.IsDigit))
            {
                return "Employer Identification Number contains invalid characters.\nPlease enter a valid number.";
            }
            else if (inputModel.EmployerIdentificationNumber.Length < 10)
            {
                return "Employer Identification Number is too short.\nPlease enter a valid number.";
            }


            // Check for a valid company address
            if (inputModel.StreetAddressOne.Length < 10)
            {
                return "Street Address is too short.\nPlease enter a valid street address";
            }


            // Check for a valid city value
            if (!inputModel.City.All(char.IsLetter))
            {
                return "City name contains invalid characters.\nPlease enter a valid city name";
            }
            else if (inputModel.City.Length < 3)
            {
                return "City name is too short.\nPlease enter a valid city name";
            }


            // Check for a valid State/Province value
            if (!inputModel.StateProvince.All(char.IsLetter))
            {
                return "State / Province name contains invalid characters.\nPlease enter a valid state / province name";
            }
            else if (inputModel.StateProvince.Length < 3)
            {
                return "State / Province name is too short.\nPlease enter a valid state / province name";
            }


            // Check for a valid ZIP code
            if (!inputModel.ZipCode.All(char.IsDigit))
            {
                return "ZIP Code number contains invalid characters.\nPlease enter a valid ZIP code.";
            }
            else if (inputModel.ZipCode.Length < 4)
            {
                return "ZIP Code number is too short.\nPlease enter a valid ZIP code.";
            }


            // All validations passed
            return "passed";
        }
    }
}
