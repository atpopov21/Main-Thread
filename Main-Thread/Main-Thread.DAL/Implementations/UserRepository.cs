using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Contracts;
using Main_Thread.DAL.Data;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context = new DbContext();

        // CREATE
        public async Task CreateUserAsync(User newUser)
        {
            if (newUser is not null)
            {
                _context.Users.Add(newUser);

                string query = $"INSERT INTO [Users] (FirstName, LastName, BirthDate, Password, Email, HireDate, Role, BusinessId) VALUES (@FirstName, @LastName, @BirthDate, @Password, @Email, @HireDate, @Role, @BusinessId)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                    command.Parameters.AddWithValue("@LastName", newUser.LastName);
                    command.Parameters.AddWithValue("@BirthDate", newUser.BirthDate);
                    command.Parameters.AddWithValue("@Password", newUser.Password);
                    command.Parameters.AddWithValue("@Email", newUser.Email);
                    command.Parameters.AddWithValue("@HireDate", newUser.HireDate);
                    command.Parameters.AddWithValue("@Role", newUser.Role);
                    command.Parameters.AddWithValue("@BusinessId", newUser.BusinessId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateUserAsync(User updatedUser)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == updatedUser.Id);

            if (user is not null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.BirthDate = updatedUser.BirthDate;
                user.Password = updatedUser.Password;
                user.Email = updatedUser.Email;
                user.HireDate = updatedUser.HireDate;
                user.Role = updatedUser.Role;
                user.BusinessId = updatedUser.BusinessId;
                
                string query = $"UPDATE [Users] SET [FirstName] = @FirstName, [LastName] = @LastName, [BirthDate] = @BirthDate, [Password] = @Password, [Email] = @Email, [HireDate] = @HireDate, [Role] = @Role, [BusinessId] = @BusinessId WHERE [UserId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@FirstName", updatedUser.FirstName);
                    command.Parameters.AddWithValue("@LastName", updatedUser.LastName);
                    command.Parameters.AddWithValue("@BirthDate", updatedUser.BirthDate);
                    command.Parameters.AddWithValue("@Password", updatedUser.Password);
                    command.Parameters.AddWithValue("@Email", updatedUser.Email);
                    command.Parameters.AddWithValue("@HireDate", updatedUser.HireDate);
                    command.Parameters.AddWithValue("@Role", updatedUser.Role);
                    command.Parameters.AddWithValue("@BusinessId", updatedUser.BusinessId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteUserAsync(User deletedUser)
        {
            if (deletedUser is not null)
            {
                string query = $"DELETE FROM [Users] WHERE [UserId] = @Id";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@Id", deletedUser.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}