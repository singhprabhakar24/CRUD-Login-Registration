using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API_FINAL.Authentication;

namespace API_FINAL.Controllers
{
    
    [Authorize]
 
    [Route("api/[Action]")]
    [ApiController]
  
    public class RegistrationController : ControllerBase
    {
        private readonly Context _context;

        public readonly IRegistrationService _iregistrationservice;

        public RegistrationController(Context context, IRegistrationService iregistrationservice)
        {
            _context = context;
            _iregistrationservice = iregistrationservice;
        }

        [HttpPost]


        public async Task<ActionResult> GetRegistration(int userid)
        {

            var Result = await _iregistrationservice.GetRegistration(userid);

            if (Result == null)
            {
                return BadRequest("Not exist");
            }
            else
            {
                return Ok(Result);
            }

        }

        [HttpPost]
        
        public async Task<ActionResult> AddRegistration(Registration registration)
        {
            var Result = await _iregistrationservice.AddRegistration(registration);
          
            if (Result == null)
            {
                return BadRequest("Not Exist");
            }
            else
            {
                return Ok(Result);
            }

        }

        [HttpPut]

        public async Task<ActionResult> UpdateRegistration(Registration registration)
        {

            var Result = await _iregistrationservice.UpdateRegistration(registration);

            if (Result == null)
            {
                return BadRequest("Not Found");
                
            }
            else
            {
                return Ok(Result);
            }

        }

        [HttpDelete]

        public async Task<ActionResult> DeleteRegistration(int id)
        {

            var result = await _iregistrationservice.DeleteRegistration(id);

            if(result == null)
            {
                return BadRequest("Issue Occur");
            }
            else
            {
                return Ok(result);  
            }

        }
    }

}