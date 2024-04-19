using JobPortal.Model;

namespace JobPortal.Repository
{
    public interface ILoginRepository
    {
        Task<bool> UserLogin(Login login);
    }
}
