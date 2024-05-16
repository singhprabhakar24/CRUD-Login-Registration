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

        public async Task<Login> UserLogin(String username, String password)
        {
           
            var Match = await _context.Login.Where(x => x.username == username && x.password == password).FirstOrDefaultAsync();
          

            if (Match == null)
            {

                return null ;
            }
            else 
            {
                Match.IsActive = true;
              await   _context.SaveChangesAsync();
                //      loginresponse.username = username;
                //    loginresponse.password = password;

                return Match;
              
            }
            
        }

        public async Task<String> UserLogout(int id)
        {

            var FindLoggedUser = await _context.Login.Where(m => m.Id == id && m.IsActive == true).FirstOrDefaultAsync();

            if (FindLoggedUser == null)
            {
                return "";
            }
            else
            {
                FindLoggedUser.IsActive = false;
                _context.SaveChanges();
                return "User logout";

            }
        }

       
    }
}
