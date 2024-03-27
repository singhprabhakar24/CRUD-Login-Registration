using API_FINAL.Models;

namespace API_FINAL.Service
{
    public interface IRegistrationService
    {
      Task<List<Registration>> GetRegistration(int userid);

        Task<Registration> AddRegistration(Registration registration);

        Task<Registration> UpdateRegistration(Registration registration);

        Task<string> DeleteRegistration(int id);
    }
}
