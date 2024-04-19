
using JobPortal.Model;
using System.Data.SqlClient;

namespace JobPortal.Repository
{
    public class UserTypeInsert : IUserTypeInsert
    {
        private readonly IConfiguration _configuration;

        public UserTypeInsert(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public async Task<bool> InsertUserType(UserTypeMaster userTypeMaster)
        {
            string connectionString = _configuration.GetConnectionString("MyDb");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SpInsertType", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", userTypeMaster.FirstName);
                        command.Parameters.AddWithValue("@LastName", userTypeMaster.LastName);
                        command.Parameters.AddWithValue("@Email", userTypeMaster.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", userTypeMaster.PhoneNumber);
                        command.Parameters.AddWithValue("@Password",userTypeMaster.Password);
                        command.Parameters.AddWithValue("@UserType",userTypeMaster.UserType);

                        int res = await command.ExecuteNonQueryAsync();
                        return res > 0;
                    }

                }catch (Exception ex)
                { 
                    return false;
                }
            }
        }
    }
}
