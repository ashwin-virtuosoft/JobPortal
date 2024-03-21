using JobPortal.Model;
using System.Data.SqlClient;

namespace JobPortal.Repository
{
    public class AdminPageRepository:IAdminPageRepository
    {
        private readonly IConfiguration _configuration;

        public AdminPageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<UserDetails>> GetUser()
        {
            List<UserDetails> data = new List<UserDetails>();
            string connectionString = _configuration.GetConnectionString("MyDb");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    string selectQry = "SELECT UserId,FirstName,LastName,Email,PhoneNumber,CreatedBy,UpdatedBy,Status,Remark FROM UserDetails";
                    using (SqlCommand command = new SqlCommand(selectQry, connection))
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDetails details = new UserDetails();
                                details.UserId = reader.GetInt32(0);
                                details.FirstName = reader.GetString(1);
                                details.LastName = reader.GetString(2);
                                details.Email = reader.GetString(3);
                                details.PhoneNumber = reader.GetInt64(4);
                                details.CreatedBy = reader.GetInt32(5);
                                details.UpdatedBy = reader.GetInt32(6);
                                details.Status = reader.GetInt32(7);
                                details.Remark = reader.GetString(8);

                                data.Add(details);
                            }

                        }
                        if(data.Count > 0)
                        {
                            return data;
                        }
                        else
                        {
                            return null;
                        }
                                            
                        
                    }
                        
                }catch (Exception ex) 

                {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
    }
}
