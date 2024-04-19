using JobPortal.Model;
using System.Data.SqlClient;
using System.Management;

namespace JobPortal.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;

        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> UserLogin(Login login)
        {
            string connectionString = _configuration.GetConnectionString("MyDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string qry = "SELECT * FROM Demo WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(qry, connection))
                    {
                        command.Parameters.AddWithValue("@Email", login.Email);
                        command.Parameters.AddWithValue("@Password", login.Password);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            return await reader.ReadAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    return false;
                }
            }
        }
    }
}
