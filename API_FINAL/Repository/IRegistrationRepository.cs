using API_FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_FINAL.Repository
{
    public interface IRegistrationRepository
    {
         Task<List<Registration>> GetRegistration(int userid);

        Task<Registration> AddRegistration(Registration registration);

        Task<Registration> UpdateRegistration(Registration registration);

        Task<string> DeleteRegistration(int id);
    }
}
