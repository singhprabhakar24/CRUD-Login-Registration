using API_FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_FINAL.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly Context _context;

        public RegistrationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Registration>> GetRegistration(int userid)
        {

            var FindLogin = await _context.Login.Where(u => u.Id == userid && u.IsActive == true).FirstOrDefaultAsync();

            if (FindLogin != null)
            {
                var FindRegistration = await _context.Registration.Where(u => u.userid == userid).ToListAsync();

                if (FindRegistration.Count == 0)
                {
                    return null;
                }
                else
                {
                    return FindRegistration;
                }
            }
            else
            {
                return null;
            }
           

        }

        public async Task<Registration> AddRegistration(Registration registration)
        {
            var FindLogin = await _context.Login.Where(x => x.Id == registration.userid && x.IsActive == true).FirstOrDefaultAsync();

            if (FindLogin == null)
            {
                throw new Exception("User Not Login yet");
            }
            else
            {
                _context.Registration.Add(registration);
                await _context.SaveChangesAsync();
                return registration;
            }
        }

        public async Task<Registration> UpdateRegistration(Registration registration)
        {

            var Find = await _context.Registration.Where(x => x.id == registration.id).FirstOrDefaultAsync();

            if (Find == null)
            {
                throw new Exception("User Not Register yet");
            }
            else
            {
                var FindLogin = await _context.Login.Where(x => x.Id == Find.userid && x.IsActive == true).FirstOrDefaultAsync(); ;

                if (FindLogin == null)
                {
                    throw new Exception("User Not Login yet");
                }
                else
                {
                    Find.lname = registration.lname;
                    Find.fname = registration.fname;
                    Find.email = registration.email;
                    Find.city = registration.city;
                    await _context.SaveChangesAsync();
                    return Find;
                }
               
            }
        }


        public async Task<string> DeleteRegistration(int id)
        {

            var Check = await _context.Registration.Where(x => x.id == id).FirstOrDefaultAsync();
            if (Check == null)
            {
                return "Not exist";

            }

            Registration registration = new Registration();

            var Check2 = await _context.Login.Where(x => x.Id == Check.userid && x.IsActive == true).FirstOrDefaultAsync();

            if (Check2 == null)
            {
                return "user not login";
            }

            else
            {
                _context.Registration.Remove(Check);
                await _context.SaveChangesAsync();
                return "User Deleted";
            }

        }
    }

    
}
