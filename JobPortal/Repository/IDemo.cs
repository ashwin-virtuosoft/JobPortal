using JobPortal.Model;
using JobPortal.services;
using System.Data.SqlClient;

namespace JobPortal.Repository
{
    public interface IDemo
    {
        Task<bool> InsertDemo(Demo demo);
    }

    public class DemoRepo : IDemo
    {
        private readonly IConfiguration _configuration;

        public DemoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> InsertDemo(Demo demo)
        {
            string connectionString = _configuration.GetConnectionString("MyDb");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Demo (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.AddWithValue("@FirstName", demo.FirstName);
                        command.Parameters.AddWithValue("@LastName", demo.LastName);
                        command.Parameters.AddWithValue("@Email", demo.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", demo.PhoneNumber);

                        int res = await command.ExecuteNonQueryAsync();
                        return res > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it accordingly
                    return false;
                }
            }
        }

    }
}
