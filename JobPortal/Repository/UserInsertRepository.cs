using JobPortal.Model;
using JobPortal.services;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace JobPortal.Repository
{
   
    public class UserInsertRepository : IUserInsertRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public UserInsertRepository(IConfiguration configuration, IEmailSender emailSender)
        {
            _configuration = configuration;
            _emailSender = emailSender;
        }
        public async Task<bool> InsertUser(UserDetails userDetails)
        
        {
            string connectionString = _configuration.GetConnectionString("MyDb");

            Dictionary<string,string>MailCredentials=new Dictionary<string,string>();
            Dictionary<string, string> MailContents;
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

                        var tempPass = await PasswordHash.GenerateSalt();
                        MailCredentials.Add("Name", userDetails.FirstName);
                        MailCredentials.Add("Email", userDetails.Email);
                        MailCredentials.Add(userDetails.Email,tempPass);

                        userDetails.Password=await PasswordHash.ToHashSHA1(tempPass);
                        command.Parameters.AddWithValue("@Password",userDetails.Password);

                       int res= await command.ExecuteNonQueryAsync();
                        if (res > 0)
                        {
                            MailContents = await _emailSender.SendMessage(MailCredentials);
                            if(await _emailSender.SendEmail(MailContents))
                            {
                                MailContents.Clear();
                                MailCredentials.Clear();
                            }
                        }
                        return res>0;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public async Task<bool>UserEmailExists(String Email)
        {
            string ConnectionString = _configuration.GetConnectionString("MyDb");
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string qry = "SELECT * FROM UserDetails WHERE Email=@Email";
                using(SqlCommand command=new SqlCommand(qry,connection))
                {
                    command.Parameters.AddWithValue("@Email", Email);
                    SqlDataReader sqlDataReader =await command.ExecuteReaderAsync();

                    return sqlDataReader.HasRows;
                }
            }
        }
    }
}
