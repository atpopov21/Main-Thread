﻿using System;
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

                string query = "INSERT INTO [Businesses] (CategoryName) VALUES (@CategoryName)";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", newCategory.Name);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // UPDATE
        public async Task UpdateCategoryAsync(Category updatedCategory)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == updatedCategory.Id);
            
            if (category != null)
            {
                category.Name = updatedCategory.Name;

                string query = "UPDATE [Categories] SET [CategoryName] = @CategoryName WHERE [CategoryId] = @CategoryId";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", updatedCategory.Name);
                    command.Parameters.AddWithValue("@CategoryId", updatedCategory.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // DELETE
        public async Task DeleteCategoryAsync(Category deletedCategory)
        {
            if (deletedCategory is not null)
            {
                string query = "DELETE FROM [Categories] WHERE [CategoryId] = @CategoryId";

                using (SqlCommand command = new SqlCommand(query, _context.Connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", deletedCategory.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}