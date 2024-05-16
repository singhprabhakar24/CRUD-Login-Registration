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


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Login>>> Get()
        {
            return await _context.Login.ToListAsync();
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
        
            Login login = new Login();

            login = await _iloginservice.UserLogin(username, password);

            if (login == null )
            {

                return BadRequest("User Not Exist");
            }
            else
            { 
                return Ok(login);
            }
           
        }

        [HttpPost]
    
        public async Task<ActionResult> UserLogout(int id)
        {
            var result = await _iloginservice.UserLogout(id);

            if (result == "")
            {
                return BadRequest("not exist");
            }
            else
            {
                return Ok("User loged out");
            }

        }
    }
}
