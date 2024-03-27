using API_FINAL.Models;
using API_FINAL.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API_FINAL.Service;
using Microsoft.AspNetCore.Authorization;

namespace API_FINAL.Controllers
{

   // [AllowAnonymous]
    [Route("api/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private  readonly Context _context;
        public readonly ILoginService _iloginservice;
        public LoginController(Context context,ILoginService iloginservice)
        {
            _iloginservice = iloginservice;
            _context = context;
        }



        
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var Result = await _context.Login.FindAsync(id);

            if (Result == null)
            {
                return NotFound();
            }
            return Result;
        }


        [HttpPost]

        public async Task<ActionResult> UserLogin(String username, String password)
        {
        
            LoginResponse loginRespose = new LoginResponse();

            loginRespose = await _iloginservice.UserLogin(username, password);
            if (loginRespose.username =="" )
            {

                return BadRequest("User Not Exist");
            }
            else
            { 
                return Ok(loginRespose);
            }
           
        }

        [HttpPost]
    
        public async Task<ActionResult> UserLogout(String username,String password)
        {
            LoginResponse loginRespose = new LoginResponse();

            loginRespose = await _iloginservice.UserLogout(username, password);
            if (loginRespose.username == "")
            {
                return BadRequest("User Not Exist");
            }
            else
            {            
                return Ok("User Logged Out");
            }

        }
    }
}
