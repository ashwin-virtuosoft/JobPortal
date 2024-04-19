using JobPortal.Model;

namespace JobPortal.Repository
{
    public interface IUserTypeInsert
    {
        Task<bool> InsertUserType(UserTypeMaster userTypeMaster);
    }
}
