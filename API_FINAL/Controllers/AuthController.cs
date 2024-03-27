 using API_FINAL.Response;
using API_FINAL.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using API_FINAL.Models;


namespace API_FINAL.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly ITokenService _tokenservice;
        private readonly Context _context;

        public AuthController(ITokenService tokenservice,Context context)
        {
            _context = context;
            _tokenservice = tokenservice;
        }


        [HttpGet]

        public async Task<IActionResult> Login(string username , string password)
        {
            var user = _context.Login.Where(x => x.username == username && x.password == password && x.IsActive == true).FirstOrDefault();
            if (user != null)
            {
                var claims = new Claim[] { new Claim(ClaimTypes.Name, username) };

                  var jwt = _tokenservice.GenerateToken(claims, "QIZbmy/CGpUdnE8wGed+3rP/NF42Ap6W", 600);
                  return Ok(jwt);
            }
            else
            {
                return Unauthorized("");
            }
            
        
        }
    }
} 