using JobPortal.Model;
using JobPortal.Repository;

namespace JobPortal.services
{
    public class GetUserDetails
    {
        private readonly IAdminPageRepository adminPageRepository;

        public GetUserDetails(AdminPageRepository admin)
        {

            adminPageRepository = admin;
        }

        public async Task<List<UserDetails>> GetUser()
        {
            return await adminPageRepository.GetUser();
        }
    }
}
