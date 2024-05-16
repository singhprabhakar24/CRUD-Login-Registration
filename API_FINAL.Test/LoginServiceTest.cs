using API_FINAL.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API_FINAL.Models;
using API_FINAL.Service;

namespace API_FINAL.Test
{
    public class LoginServiceTest
    {
        [Fact]

        public async Task UserLogin_return_login()
        {
            var login = new Login();
            var repositoryMock = new Mock<ILoginRepository>();
            repositoryMock.Setup(x => x.UserLogin(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(login);

            var service = new LoginService(repositoryMock.Object);

            var result = await service.UserLogin("a", "a");

            Assert.NotNull(result);
            Assert.Equal(login, result);

        }

        [Fact]

        public async Task UserLogout_return_logout()
        {
            var login = new Login();
            int id = 123;
            var repositoryMock = new Mock<ILoginRepository>();
            repositoryMock.Setup(x => x.UserLogout(id)).ReturnsAsync(id.ToString);

            var service = new LoginService(repositoryMock.Object);

            var result = await service.UserLogout(id);

            Assert.NotNull(result);
            Assert.Equal(id.ToString(), result);

        }
    }
}
