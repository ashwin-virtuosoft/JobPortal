using JobPortal.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace JobPortal.Repository
{
   
    public class UserInsertRepository : IUserInsertRepository
    {
        private readonly IConfiguration _configuration;


        public UserInsertRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> InsertUser(UserDetails userDetails)
        {
            string connectionString = _configuration.GetConnectionString("MyDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SpInsertUserDetail1", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", userDetails.FirstName);
                        command.Parameters.AddWithValue("@LastName", userDetails.LastName);
                        command.Parameters.AddWithValue("@Email", userDetails.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", userDetails.PhoneNumber);
                        command.Parameters.AddWithValue("@CreatedBy", userDetails.CreatedBy);
                        command.Parameters.AddWithValue("@UpdatedBy", userDetails.UpdatedBy);
                        command.Parameters.AddWithValue("@Status", userDetails.Status);
                        command.Parameters.AddWithValue("@Remark", userDetails.Remark);

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
    }
}
