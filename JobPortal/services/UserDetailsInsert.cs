using System.Data.SqlClient;
using System.Xml.Linq;
using JobPortal.Model;
using JobPortal.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobPortal.services
{
    public class UserDetailsInsert
    {
   
        private readonly IUserInsertRepository userInsertRepository;
       

        public UserDetailsInsert(UserInsertRepository rpo)
        {
            
            userInsertRepository = rpo;
        }
       
        public async Task<bool> InsertUser(UserDetails userDetails)
        {
           return await userInsertRepository.InsertUser(userDetails);
        }

        

       
    }
}
