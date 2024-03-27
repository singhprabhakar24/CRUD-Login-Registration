using API_FINAL.Models;
using API_FINAL.Repository;

namespace API_FINAL.Service
{
    public class RegistrationService : IRegistrationService
    {
        public IRegistrationRepository _iregistrationRepository;

        public RegistrationService(IRegistrationRepository iregistrationRepository)
        {
            _iregistrationRepository = iregistrationRepository;

        }
        public async Task<List<Registration>> GetRegistration(int userid)
        {
            return await _iregistrationRepository.GetRegistration(userid);
        }


        public async Task<Registration> AddRegistration(Registration registration)
        {
            return await _iregistrationRepository.AddRegistration(registration);
        }

        public async Task<Registration> UpdateRegistration(Registration registration)
        {
            return await _iregistrationRepository.UpdateRegistration(registration);
        }

        public async Task<string> DeleteRegistration(int id)
        {
            return await _iregistrationRepository.DeleteRegistration(id);
        }
    }
}
