using API_FINAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace API_FINAL.Repository
{
    public interface ILoginRepository
    {
       Task<LoginResponse> UserLogin(String username, String password);

        Task<LoginResponse> UserLogout(String username, String password);
    }
}
