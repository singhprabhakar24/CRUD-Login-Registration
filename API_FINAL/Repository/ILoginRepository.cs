using API_FINAL.Response;
using Microsoft.AspNetCore.Mvc;
using API_FINAL.Models;


namespace API_FINAL.Repository
{
    public interface ILoginRepository
    {
       Task<Login> UserLogin(String username, String password);

        Task<String> UserLogout(int id);
    }
}
