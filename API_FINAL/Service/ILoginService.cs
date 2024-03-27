using API_FINAL.Response;

namespace API_FINAL.Service
{
    public interface ILoginService
    {
        Task<LoginResponse> UserLogin(String username, String password);
        Task<LoginResponse> UserLogout(String username, String password);
    }
}
