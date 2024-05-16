using API_FINAL.Controllers;
using API_FINAL.Models;
using API_FINAL.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace API_FINAL.Test
{
    public class LoginControllerTest
    {

        [Fact]
        public async Task UserLogin_Returns_BadRequest_When_User_Not_Exist()
        {
            // Arrange
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(x => x.UserLogin(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((Login)null); 
            var controller = new LoginController(null, mockLoginService.Object);

            // Act
            var result = await controller.UserLogin("User", "Password");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result); // in result the controller has bad request and whats inside that bad request it fetched that thing.
            Assert.Equal("User Not Exist", badRequestResult.Value);
        }

        [Fact]
        public async Task UserLogin_Returns_Ok_With_Login_When_Successful()
        {
            // Arrange
            var login = new Login { Id = 1, username = "User", password = "Password" };
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(x => x.UserLogin("User", "Password")).ReturnsAsync(login); 
            var controller = new LoginController(null, mockLoginService.Object);

            // Act
            var result = await controller.UserLogin("User", "Password");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
     
            Assert.Equal(login, okResult.Value);
        }
        [Fact]
        public async Task UserLogout_Returns_BadRequest()
        {
            //Arrange
            var id = 1;
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(x => x.UserLogout(id)).ReturnsAsync("");

            var controller = new LoginController(null, mockLoginService.Object);

            //Act
            var result = await controller.UserLogout(id);

            //Assert

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("not exist", badRequestResult.Value); // it also necessary that write proper expected result
        }


        [Fact]

        public async Task UserLogout_Returns_Ok()
        {
            var id = 1;

            var mockloginservice = new Mock<ILoginService>();

            mockloginservice.Setup(x => x.UserLogout(id)).ReturnsAsync("Logout");

            var controller = new LoginController(null, mockloginservice.Object);

            var result = await controller.UserLogout(id);


            var OkRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User loged out", OkRequestResult.Value);
        }
    }
}
