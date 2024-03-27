using API_FINAL.Models;
using API_FINAL.Response;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_FINAL.Repository
{
    public class LoginRepository : ILoginRepository
    {

        private readonly Context _context;

        public LoginRepository(Context context)
        {
            _context = context;
        }

        public async Task<LoginResponse> UserLogin(String username, String password)
        {
           
            var Match = await _context.Login.Where(x => x.username == username && x.password == password).FirstOrDefaultAsync();
            LoginResponse loginresponse = new LoginResponse();

            if (Match == null)
            {
           
                return loginresponse;
            }
            else 
            {
                Match.IsActive = true;
                _context.SaveChangesAsync();
                loginresponse.username = username;
                loginresponse.password = password;

                return loginresponse;
              
            }
            
        }

        public async Task<LoginResponse> UserLogout(String username,String password)
        {
            LoginResponse loginresponse = new LoginResponse();

           var Match = await _context.Login.Where(x => x.username == username && x.password == password && x.IsActive == true).FirstOrDefaultAsync();

            if (Match == null)
            {
                return loginresponse;
            }
            else
            {
                Match.IsActive = false;
                _context.SaveChangesAsync();
                loginresponse.username = username;
                loginresponse.password = password;
                return loginresponse;

            }
        }

       
    }
}
