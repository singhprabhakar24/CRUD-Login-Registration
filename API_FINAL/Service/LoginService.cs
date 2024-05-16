using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Response;

namespace API_FINAL.Service
{
    public class LoginService : ILoginService
    {
       
        public ILoginRepository _iloginRepository;

        public LoginService( ILoginRepository iloginRepository)
        {
            _iloginRepository = iloginRepository;
           
        }
        public async Task<Login> UserLogin(String username, String password)
        {

            return await _iloginRepository.UserLogin(username, password);
        }

        public async Task<String> UserLogout(int id)
        {
            return await _iloginRepository.UserLogout(id);
        }
    }
}
