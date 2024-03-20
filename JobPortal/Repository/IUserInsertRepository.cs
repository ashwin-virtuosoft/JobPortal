using JobPortal.Model;
using JobPortal.Repository;

namespace JobPortal.Repository
{
   public  interface  IUserInsertRepository 
    {
         Task<bool> InsertUser(UserDetails userDetails);
    }
    

    
}
