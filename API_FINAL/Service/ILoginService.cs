using API_FINAL.Response;
using API_FINAL.Models;


namespace API_FINAL.Service
{
    public interface ILoginService
    {
        Task<Login> UserLogin(String username, String password);
        Task<String> UserLogout(int id);
    }
}
