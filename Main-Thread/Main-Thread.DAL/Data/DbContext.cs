using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Main_Thread.DAL.Models;

namespace Main_Thread.DAL.Data;

public class DbContext
{
    public SqlConnection Connection { get; } = new SqlConnection();
    public List<Business> Businesses { get; set; }
    public List<Profit> Profits { get; set; }
    public List<Revenue> Revenues { get; set; }
    public List<Stock> Stocks { get; set; }
    public List<User> Users { get; set; }

    public DbContext()
    {
        string connectionString = "Server=tcp:main-thread-server.database.windows.net,1433;Initial Catalog=MainThread;Persist Security Info=False;User ID=ThreadMain;Password={MainThread@1243};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        Connection = new SqlConnection(connectionString);
        Connection.Open();
        
        Businesses = new List<Business>();
        Profits = new List<Profit>();
        Revenues = new List<Revenue>();
        Stocks = new List<Stock>();
        Users = new List<User>();

        LoadDataAsync().Wait();
    }

    public async Task LoadDataAsync()
    {
        await ReadBusinessesAsync();
        await ReadProfitsAsync();
        await ReadRevenuesAsync();
        await ReadStocksAsync();
        await ReadUsersAsync();
    }

    public async Task ReadBusinessesAsync()
    {
        string query = "SELECT * FROM Businesses";
        SqlCommand command = new SqlCommand(query, Connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Businesses.Add(new Business()
            {
                Id = reader.GetInt32(0),
                OwnerFirstName = reader.GetString(1),
                OwnerLastName = reader.GetString(2),
                Password = reader.GetString(3),
                BusinessName = reader.GetString(4),
                ContactNumber = reader.GetString(5),
                Email = reader.GetString(6),
                StateEntityRegistration = reader.GetString(7),
                EmployerIdentificationNumber = reader.GetString(8),
                StreetAddressOne = reader.GetString(9),
                //StreetAddressTwo = reader.GetString(10),
                City = reader.GetString(10),
                StateProvince = reader.GetString(11),
                ZipCode = reader.GetString(12),
                BusinessType = reader.GetString(13),
                //OtherBusinessType = reader.GetString(15),
            });
        }
        reader.Close();
    }
    
    // Read category by ID
    public async Task<Business> GetBusinessByIdAsync(int businessId)
    {
        string query = "SELECT * FROM Businesses WHERE BusinessId = @Id";

        using (SqlCommand command = new SqlCommand(query, Connection))
        {
            command.Parameters.AddWithValue("@Id", businessId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Business()
                    {
                        Id = Convert.ToInt32(reader["BusinessId"]),
                        OwnerFirstName = Convert.ToString(reader["OwnerFirstName"]),
                        OwnerLastName = Convert.ToString(reader["OwnerLastName"]),
                        Password = Convert.ToString(reader["Password"]),
                        BusinessName = Convert.ToString(reader["BusinessName"]),
                        ContactNumber = Convert.ToString(reader["ContactNumber"]),
                        Email = Convert.ToString(reader["Email"]),
                        StateEntityRegistration = Convert.ToString(reader["StateEntityRegistration"]),
                        EmployerIdentificationNumber = Convert.ToString(reader["EmployerIdentificationNumber"]),
                        StreetAddressOne = Convert.ToString(reader["StreetAddressOne"]),
                        //StreetAddressTwo = Convert.ToString(reader["StreetAddressTwo"]),
                        City = Convert.ToString(reader["City"]),
                        StateProvince = Convert.ToString(reader["StateProvince"]),
                        ZipCode = Convert.ToString(reader["ZipCode"]),
                        BusinessType = Convert.ToString(reader["BusinessType"]),
                        //OtherBusinessType = Convert.ToString(reader["OtherBusinessType"]),
                    };
                }
            }
        }

        return null;
    }

    
    public async Task ReadProfitsAsync()
    {
        string query = "SELECT * FROM Profits";
        SqlCommand command = new SqlCommand(query, Connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Profits.Add(new Profit()
            {
                Id = reader.GetInt32(0),
                DailyProfit = reader.GetDecimal(1),
                Date = reader.GetDateTime(2),
            });
        }
        reader.Close();
    }
    
    // Read category by ID
    public async Task<Profit> GetProfitByIdAsync(int profitId)
    {
        string query = "SELECT * FROM Profits WHERE ProfitId = @Id";

        using (SqlCommand command = new SqlCommand(query, Connection))
        {
            command.Parameters.AddWithValue("@Id", profitId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Profit()
                    {
                        Id = Convert.ToInt32(reader["ProfitId"]),
                        DailyProfit = Convert.ToDecimal(reader["DailyProfit"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                    };
                }
            }
        }

        return null;
    }
    
    
    public async Task ReadRevenuesAsync()
    {
        string query = "SELECT * FROM Revenues";
        SqlCommand command = new SqlCommand(query, Connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Revenues.Add(new Revenue()
            {
                Id = reader.GetInt32(0),
                DailyRevenue = reader.GetDecimal(1),
                Date = reader.GetDateTime(2),
            });
        }
        reader.Close();
    }
    
    // Read category by ID
    public async Task<Revenue> GetRevenueByIdAsync(int revenueId)
    {
        string query = "SELECT * FROM Revenues WHERE RevenueId = @Id";

        using (SqlCommand command = new SqlCommand(query, Connection))
        {
            command.Parameters.AddWithValue("@Id", revenueId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Revenue()
                    {
                        Id = Convert.ToInt32(reader["RevenueId"]),
                        DailyRevenue = Convert.ToDecimal(reader["DailyRevenue"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                    };
                }
            }
        }

        return null;
    }
    
    
    public async Task ReadStocksAsync()
    {
        string query = "SELECT * FROM Stocks";
        SqlCommand command = new SqlCommand(query, Connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Stocks.Add(new Stock()
            {
                Id = reader.GetInt32(0),
                ProductName = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Quantity = reader.GetInt32(3),
                Rating = reader.GetDecimal(4),
            });
        }
        reader.Close();
    }
    
    // Read category by ID
    public async Task<Stock> GetStockByIdAsync(int stockId)
    {
        string query = "SELECT * FROM Stocks WHERE StockId = @Id";

        using (SqlCommand command = new SqlCommand(query, Connection))
        {
            command.Parameters.AddWithValue("@Id", stockId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Stock()
                    {
                        Id = Convert.ToInt32(reader["RevenueId"]),
                        ProductName = Convert.ToString(reader["ProductName"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Rating = Convert.ToDecimal(reader["Rating"]),
                    };
                }
            }
        }

        return null;
    }
    
    
    public async Task ReadUsersAsync()
    {
        string query = "SELECT * FROM Users";
        SqlCommand command = new SqlCommand(query, Connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Users.Add(new User()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                BirthDate = reader.GetDateTime(3),
                PersonalIdentificationNumber = reader.GetString(4),
                Password = reader.GetString(5),
                Email = reader.GetString(6),
                HireDate = reader.GetDateTime(7),
                Role = reader.GetInt32(8),
            });
        }
        reader.Close();
    }
    
    // Read category by ID
    public async Task<User> GetUserByIdAsync(int userId)
    {
        string query = "SELECT * FROM Users WHERE UserId = @Id";

        using (SqlCommand command = new SqlCommand(query, Connection))
        {
            command.Parameters.AddWithValue("@Id", userId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = Convert.ToInt32(reader["RevenueId"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        PersonalIdentificationNumber = Convert.ToString(reader["PersonalIdentificationNumber"]),
                        Password = Convert.ToString(reader["Password"]),
                        Email = Convert.ToString(reader["Email"]),
                        HireDate = Convert.ToDateTime(reader["HireDate"]),
                        Role = Convert.ToInt32(reader["Role"]),
                    };
                }
            }
        }

        return null;
    }
    
    public void Dispose()
    {
        if (Connection != null && Connection.State == ConnectionState.Open)
        {
            Connection.Close();
        }
    }
}