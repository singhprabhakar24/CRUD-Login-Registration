using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API_FINAL.Models;
using API_FINAL.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class RegistrationRepositoryTests
{
    [Fact]
    public async Task GetRegistration_ReturnsNull_WhenUserNotFound()
    {
        // Arrange
        var mockContext = new Mock<Context>();
        var mockDbSetLogin = new Mock<DbSet<Login>>();
        mockContext.Setup(c => c.Login).Returns(mockDbSetLogin.Object);
        var repository = new RegistrationRepository(mockContext.Object);

        // Act
        var result = await repository.GetRegistration(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetRegistration_ReturnsNull_WhenNoRegistrationsFound()
    {
        // Arrange
        var userId = 1;
        var mockContext = new Mock<Context>();
        var mockDbSetLogin = new Mock<DbSet<Login>>();
        var mockDbSetRegistration = new Mock<DbSet<Registration>>();
        mockContext.Setup(c => c.Login).Returns(mockDbSetLogin.Object);
        mockContext.Setup(c => c.Registration).Returns(mockDbSetRegistration.Object);
        mockDbSetLogin.Setup(d => d.FindAsync(It.IsAny<int>())).ReturnsAsync(new Login { Id = userId, IsActive = true });
        mockDbSetRegistration.Setup(d => d.Where(It.IsAny<Expression<Func<Registration, bool>>>())).Returns(registrations);
        var repository = new RegistrationRepository(mockContext.Object);

        // Act
        var result = await repository.GetRegistration(userId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetRegistration_ReturnsRegistrations_WhenUserAndRegistrationsFound()
    {
        // Arrange
        var userId = 1;
        var registrations = new List<Registration>
        {
            new Registration { id = 1, userid = userId },
            new Registration { id = 2, userid = userId }
        }.AsQueryable();

        var mockContext = new Mock<Context>();
        var mockDbSetLogin = new Mock<DbSet<Login>>();
        var mockDbSetRegistration = new Mock<DbSet<Registration>>();
        mockContext.Setup(c => c.Login).Returns(mockDbSetLogin.Object);
        mockContext.Setup(c => c.Registration).Returns(mockDbSetRegistration.Object);
        mockDbSetLogin.Setup(d => d.FindAsync(It.IsAny<int>())).ReturnsAsync(new Login { Id = userId, IsActive = true });
        mockDbSetRegistration.Setup(d => d.Where(It.IsAny<Expression<Func<Registration, bool>>>())).Returns(registrations);
        var repository = new RegistrationRepository(mockContext.Object);

        // Act
        var result = await repository.GetRegistration(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(registrations.Count(), result.Count);
    }
}
