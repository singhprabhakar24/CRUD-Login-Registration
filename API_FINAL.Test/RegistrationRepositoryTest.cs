using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Service;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FINAL.Test
{
    public class RegistrationRepositoryTest
    {
        private readonly Context _context;


        //Not working just 

   /*     [Fact]
        public async Task GetRegistration_ValidUserId_ReturnsRegistrations()
        {
            // Arrange
            int userId = 123;
            var expectedRegistrations = new List<Registration>();

            var mockRepository = new Mock<IRegistrationRepository>();
            mockRepository.Setup(repo => repo.GetRegistration(userId))
                          .ReturnsAsync(expectedRegistrations);

            var mockContext = new Mock<Context>();


            var service = new RegistrationRepository(_context);

            // Act
            var result = await service.GetRegistration(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRegistrations, result);
        }
   */
       

        [Fact]
        public async Task GetRegistration_Returns_null_InRepository_WhenNull()
        {

            int userId = 100;
            List<Registration> expectedResult = null;
            var registration = new Registration();
            var mockRepository = new Mock<IRegistrationRepository>();
            mockRepository.Setup(repo => repo.GetRegistration(userId)).ReturnsAsync(expectedResult);
            var service = new RegistrationService(mockRepository.Object);
            var result = await service.GetRegistration(userId);
            Assert.Null(result);

        }

        [Fact]

        public async Task AddRegistration_Returns_Registration_InRepository()
        {
            var registration = new Registration();
            var expectedResult = new Registration(); // you can also say it mock

            var mockRepository = new Mock<IRegistrationRepository>();

            mockRepository.Setup(x => x.AddRegistration(It.IsAny<Registration>())).ReturnsAsync(expectedResult);

            var service = new RegistrationService(mockRepository.Object);

            var result = await service.AddRegistration(registration);

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }


        [Fact]

        public async Task AddRegistration_Returns_null()
        {

            //Arrange
            var registration = new Registration();
            var mockRepository = new Mock<IRegistrationRepository>();
            mockRepository.Setup(x => x.AddRegistration(It.IsAny<Registration>())).ReturnsAsync((Registration)null);


            var service = new RegistrationService(mockRepository.Object);

            //Act
            var result = await service.AddRegistration(registration);

            //Asssert
            Assert.Null(result);
        }

        [Fact]

        public async Task UpdateRegistration_Returns_Registration()
        {
            //Arrange
            var registration = new Registration();


            var mockRepository = new Mock<IRegistrationRepository>();

            mockRepository.Setup(x => x.UpdateRegistration(It.IsAny<Registration>())).ReturnsAsync(registration);

            var service = new RegistrationService(mockRepository.Object);

            //Act
            var result = await service.UpdateRegistration(registration);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(registration, result); // Because expected result is same as registration.

        }

        [Fact]

        public async Task UpdateRegistration_Returns_Null()
        {
            var registration = new Registration();
            var mockRepository = new Mock<IRegistrationRepository>();

            //It.IsAny<T>() is a method provided by Moq && It’s commonly used when you want to mock a method call but don’t care about the specific value of one or more parameters.
            mockRepository.Setup(x => x.UpdateRegistration(It.IsAny<Registration>())).ReturnsAsync((Registration)null);


            var service = new RegistrationService(mockRepository.Object);

            //Act
            var result = await service.UpdateRegistration(registration);

            //Asssert
            Assert.Null(result);

        }


        [Fact]

        public async Task DeleteRegistration_Returns_UserDeleted()
        {

            int id = 24;
            var registration = new Registration();
            var expectedResult = "Us Deleted";


            var mockRepository = new Mock<IRegistrationRepository>();

            mockRepository.Setup(x => x.DeleteRegistration(id)).ReturnsAsync(expectedResult);

            var service = new RegistrationService(mockRepository.Object);

            var result = await service.DeleteRegistration(id);
            Assert.Equal(expectedResult, result);
        }

        


    }
}


















