using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Service;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FINAL.Test
{
   public class RegistrationServiceTest
    {

       



        [Fact]
        public async Task GetRegistration_ReturnsRegistrations()
        {
            // Arrange
            var userId = 1;
            var expectedRegistrations = new List<Registration>(); 
            var repositoryMock = new Mock<IRegistrationRepository>();
            repositoryMock.Setup(x => x.GetRegistration(userId)).ReturnsAsync(expectedRegistrations);
            var service = new RegistrationService(repositoryMock.Object);

            // Act
            var result = await service.GetRegistration(userId);

            // Assert
            Assert.Equal(expectedRegistrations, result);
        }


      
        // this test like showing that it returns some values nothing else above method return count 0
        //Confuse with either this is wright or upper one.
        [Fact]
        public async Task GetRegistration_ReturnsRegistrations1()
        {
            // Arrange
            int userId = 1;
            var mockRepository = new Mock<IRegistrationRepository>();
            var expectedRegistrations = new List

           <Registration>
            {
                new Registration { id = 1, userid = userId,  },
                new Registration { id = 2, userid = userId,  }
                // Add more registrations as needed for testing different scenarios
            };
            mockRepository.Setup(repo => repo.GetRegistration(userId)).ReturnsAsync(expectedRegistrations);
            var service = new RegistrationService(mockRepository.Object);

            // Act
            var result = await service.GetRegistration(userId);

            // Assert
            Assert.Equal(expectedRegistrations, result);
        }




        [Fact]
        public async Task AddRegistration_ValidRegistration_ReturnsAddedRegistration()
        {
            // Arrange
            var registration = new Registration { };
            var expectedAddedRegistration = new Registration {  };

            var mockRepository = new Mock<IRegistrationRepository>();
            mockRepository.Setup(x => x.AddRegistration(registration)).ReturnsAsync(expectedAddedRegistration);

            var service = new RegistrationService(mockRepository.Object);

            // Act
            var result = await service.AddRegistration(registration);

            // Assert
            Assert.Equal(expectedAddedRegistration, result);
        }



        

        [Fact]
        public async Task UpdateRegistration_ReturnsUpdatedRegistration()
        
        {
            // Arrange
            var registrationToUpdate = new Registration(); 
            var repositoryMock = new Mock<IRegistrationRepository>();
            repositoryMock.Setup(x => x.UpdateRegistration(registrationToUpdate)).ReturnsAsync(registrationToUpdate);
            var service = new RegistrationService(repositoryMock.Object);

            // Act
            var result = await service.UpdateRegistration(registrationToUpdate);

            // Assert
            Assert.Equal(registrationToUpdate, result);
        }

        [Fact]
        public async Task DeleteRegistration_ReturnsDeletedId()
        {
            // Arrange
            var registrationIdToDelete = 1; 
            var repositoryMock = new Mock<IRegistrationRepository>();
            repositoryMock.Setup(x => x.DeleteRegistration(registrationIdToDelete)).ReturnsAsync(registrationIdToDelete.ToString());
            var service = new RegistrationService(repositoryMock.Object);

            // Act
            var result = await service.DeleteRegistration(registrationIdToDelete);

            // Assert
            Assert.Equal(registrationIdToDelete.ToString(), result);
        }
    }

}

