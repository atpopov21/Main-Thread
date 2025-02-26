using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Data;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Implementations
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DbContext _context = new DbContext();

        // CREATE
        public async Task CreateBusinessAsync(Business newBusiness)
        {
            if (newBusiness is not null)
            {
                _context.Businesses.Add(newBusiness);

                string query = $"INSERT INTO [Businesses] (OwnerFirstName, OwnerLastName, Password, BusinessName, ContactNumbber, Email, StateEntityRegistration, EmployerIdentificationNumber, StreetAddressOne, /*StreetAddressTwo*/, City, StateProvince, ZipCode, BusinessType, /*OtherBusinessType*/) VALUES (@OwnerFirstName, @OwnerLastName, @Password, @BusinessName, @ContactNumbber, @Email, @StateEntityRegistration, @EmployerIdentificationNumber, @StreetAddressOne, /*@StreetAddressTwo*/, @City, @StateProvince, @ZipCode, @BusinessType, /*@OtherBusinessType*/)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@OwnerFirstName", newBusiness.OwnerFirstName);
                    command.Parameters.AddWithValue("@OwnerLastName", newBusiness.OwnerLastName);
                    command.Parameters.AddWithValue("@Password", newBusiness.Password);
                    command.Parameters.AddWithValue("@BusinessName", newBusiness.BusinessName);
                    command.Parameters.AddWithValue("@ContactNumber", newBusiness.ContactNumber);
                    command.Parameters.AddWithValue("@Email", newBusiness.Email);
                    command.Parameters.AddWithValue("@StateEntityRegistration", newBusiness.StateEntityRegistration);
                    command.Parameters.AddWithValue("@EmployerIdentificationNumber", newBusiness.EmployerIdentificationNumber);
                    command.Parameters.AddWithValue("@StreetAddressOne", newBusiness.StreetAddressOne);
                    //command.Parameters.AddWithValue("@StreetAddressTwo", newBusiness.StreetAddressTwo);
                    command.Parameters.AddWithValue("@City", newBusiness.City);
                    command.Parameters.AddWithValue("@StateProvince", newBusiness.StateProvince);
                    command.Parameters.AddWithValue("@ZipCode", newBusiness.ZipCode);
                    command.Parameters.AddWithValue("@BusinessType", newBusiness.BusinessType);
                    //command.Parameters.AddWithValue("@OtherBusinessType", newBusiness.OtherBusinessType);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateBusinessAsync(Business updatedBusiness)
        {
            Business business = _context.Businesses.FirstOrDefault(x => x.Id == updatedBusiness.Id);

            if (business is not null)
            {
                business.OwnerFirstName = updatedBusiness.OwnerFirstName;
                business.OwnerLastName = updatedBusiness.OwnerLastName;
                business.Password = updatedBusiness.Password;
                business.BusinessName = updatedBusiness.BusinessName;
                business.ContactNumber = updatedBusiness.ContactNumber;
                business.Email = updatedBusiness.Email;
                business.StateEntityRegistration = updatedBusiness.StateEntityRegistration;
                business.EmployerIdentificationNumber = updatedBusiness.EmployerIdentificationNumber;
                business.StreetAddressOne = updatedBusiness.StreetAddressOne;
                //business.StreetAddressTwo = updatedBusiness.StreetAddressTwo;
                business.City = updatedBusiness.City;
                business.StateProvince = updatedBusiness.StateProvince;
                business.ZipCode = updatedBusiness.ZipCode;
                business.BusinessType = updatedBusiness.BusinessType;
                business.OtherBusinessType = updatedBusiness.OtherBusinessType;

                string query = $"UPDATE [Businesses] SET [OwnerFirstName] = @OwnerFirstName, [OwnerLastName] = @OwnerLastName, [Password] = @Password, [BusinessName] = @BusinessName, [ContactNumber] = @ContactNumber, [Email] = @Email, [StateEntityRegistration] = @StateEntityRegistration, [EmployerIdentificationNumber] = @EmployerIdentificationNumber, [StreetAddressOne] = @StreetAddressOne, /*[StreetAddressTwo] = @StreetAddressTwo*/, [City] = @City, [StateProvince] = @StateProvince, [ZipCode] = @ZipCode, [BusinessType] = @BusinessType, /*[OtherBusinessType] = @OtherBusinessType*/ WHERE [BusinessId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@OwnerFirstName", updatedBusiness.OwnerFirstName);
                    command.Parameters.AddWithValue("@OwnerLastName", updatedBusiness.OwnerLastName);
                    command.Parameters.AddWithValue("@Password", updatedBusiness.Password);
                    command.Parameters.AddWithValue("@BusinessName", updatedBusiness.BusinessName);
                    command.Parameters.AddWithValue("@ContactNumber", updatedBusiness.ContactNumber);
                    command.Parameters.AddWithValue("@Email", updatedBusiness.Email);
                    command.Parameters.AddWithValue("@StateEntityRegistration", updatedBusiness.StateEntityRegistration);
                    command.Parameters.AddWithValue("@EmployerIdentificationNumber", updatedBusiness.EmployerIdentificationNumber);
                    command.Parameters.AddWithValue("@StreetAddressOne", updatedBusiness.StreetAddressOne);
                    //command.Parameters.AddWithValue("@StreetAddressTwo", updatedBusiness.StreetAddressTwo);
                    command.Parameters.AddWithValue("@City", updatedBusiness.City);
                    command.Parameters.AddWithValue("@StateProvince", updatedBusiness.StateProvince);
                    command.Parameters.AddWithValue("@ZipCode", updatedBusiness.ZipCode);
                    command.Parameters.AddWithValue("@BusinessType", updatedBusiness.BusinessType);
                    //command.Parameters.AddWithValue("@OtherBusinessType", updatedBusiness.OtherBusinessType);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteBusinessAsync(Business deletedBusiness)
        {
            if (deletedBusiness is not null)
            {
                string query = $"DELETE FROM [Businesses] WHERE [BusinessId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@Id", deletedBusiness.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}