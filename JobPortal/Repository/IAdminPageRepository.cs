using JobPortal.Model;

namespace JobPortal.Repository
{
    public interface IAdminPageRepository
    {
        Task<List<UserDetails>> GetUser();
    }
}
