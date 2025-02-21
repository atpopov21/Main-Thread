using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Main_Thread.BLL.Contracts.IAuthentication;
using Main_Thread.Shared.InputModels;

namespace Main_Thread.BLL.Services.Authentication
{
    public class LoginService : ILoginService
    {
        public string ValidateUserCredentials(LoginToCompanyIM inputModel)
        {
            // TEMPORARY INITIALIZATION
            // "realEamils" need to be retreived from the database (ID's are being simulated with the index of each email, which is equal to the password)
            string[] realEmails = { "ivan@gmail.com", "BADimov21@codingburgas.bg", "michaelWon@abv.bg", "fakeADMIN" };
            string[] realMatchingPasswords = { "ivanIsHere", "1234567890!Secure", "hippo#21", "fakeADMIN" };

            // Get all properties of the input model
            PropertyInfo[] properties = inputModel.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(inputModel);

                // Check if any field is empty
                if (string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    return "There are one or multiple empty fields.\nPlease fill them in.";
                }
            }

            // Check if email exists
            if (!realEmails.Any(email => email == inputModel.Email))
            {
                return "Email not found.";
            }

            // Find index of the entered email
            int emailIndex = Array.IndexOf(realEmails, inputModel.Email);

            // Check if password matches the user's email
            if (realMatchingPasswords[emailIndex] != inputModel.Password)
            {
                return "Incorrect email or password.";
            }

            // All validations passed
            return "passed";
        }
    }
}
