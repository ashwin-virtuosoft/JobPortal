using JobPortal.Model;
using JobPortal.Repository;

namespace JobPortal.services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> UserLogin(Login login)
        {
            return  await _loginRepository.UserLogin(login);
        }
    }
}
