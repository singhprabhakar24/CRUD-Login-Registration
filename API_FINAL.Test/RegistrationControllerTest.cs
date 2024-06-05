using API_FINAL.Controllers;
using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;


public class RegistrationControllerTest
{


    private readonly Mock<IRegistrationService> mockRegistrationService;
    private readonly RegistrationController registrationController;

    public RegistrationControllerTest()
    {
        mockRegistrationService = new Mock<IRegistrationService>();
        registrationController = new RegistrationController(null, mockRegistrationService.Object);
    }



    [Fact]

    // if badrequest occur so how can it occur this is for it
    public async Task GetRegistration_Returns_BadRequest_TestPassed()
    {
        // Arrange
        int userId = 1; 

        List<Registration> expectedResult = null; 
        mockRegistrationService.Setup(x => x.GetRegistration(userId)).ReturnsAsync(expectedResult); 
       

        // Act    
        var result = await registrationController.GetRegistration(userId);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

       
        var badRequestResult = result as BadRequestObjectResult;
        Assert.Equal("Not exist", badRequestResult.Value);
    }



    [Fact]

    // same but when all thing ok

    public async Task GetRegistration_Returns_Ok_TestPassed()
    {
        // Arrange
        int userId = 103;
        var expectedResult = new List<Registration>(); // we expect that returns of registartion 
       
        var mockRegistrationService = new Mock<IRegistrationService>();
        mockRegistrationService.Setup(x => x.GetRegistration(userId)).ReturnsAsync(expectedResult);


        var controller = new RegistrationController(null, mockRegistrationService.Object);

        // Act
        var result = await controller.GetRegistration(userId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);
    }




    [Fact]
    public async Task AddRegistration_Returns_BadRequest_TestPassed()
    {
        // Arrange
        var registration = new Registration();



        mockRegistrationService.Setup(x => x.AddRegistration(registration)).ReturnsAsync((Registration)null);



        // Act
        var result = await registrationController.AddRegistration(registration);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.Equal("Not Exist", badRequestResult.Value);
    }



    [Fact]

    public async Task AddRegistration_Returns_Ok_TestPassed()
    {
        // Arrange
        var registration = new Registration(); // Create a mock registration object
        var expectedResult = new Registration(); 

        // Mock IRegistrationService
      
        mockRegistrationService.Setup(x => x.AddRegistration(It.IsAny<Registration>())).ReturnsAsync(expectedResult);    

        // Act
        var result = await registrationController.AddRegistration(registration);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);
    }





    [Fact]

    public async Task UpdateRegistration_Returns_OkResult_TestPassed()
    {
        var registration = new Registration();
        var expectedResult = new Registration();


        mockRegistrationService.Setup(x => x.UpdateRegistration(registration)).ReturnsAsync(expectedResult);



        var result = await registrationController.UpdateRegistration(registration);

        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]

    public async Task UpdateRegistration_Returns_BadResult_TestPassed()
    {
        var registration = new Registration();


        mockRegistrationService.Setup(x => x.UpdateRegistration(It.IsAny<Registration>())).ReturnsAsync((Registration)null);


        var result = await registrationController.UpdateRegistration(registration);

        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.Equal("Not Found", badRequestResult.Value);
    }






[Fact]

    public async Task DeleteRegistration_Returns_OkResult_TestPassed()
    {
        var id = 1;

        string expectedResult = "User Deleted";

        mockRegistrationService.Setup(x => x.DeleteRegistration(id)).ReturnsAsync(expectedResult);


        var result = await registrationController.DeleteRegistration(id);

        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);

    }

    [Fact]

    public async Task DeleteRegistration_Returns_BadResult_TestPassed()
    {
        var id = 1;


        mockRegistrationService.Setup(x => x.DeleteRegistration(id)).ReturnsAsync((string)null);

        var result = await registrationController.DeleteRegistration(id);

        Assert.IsType<BadRequestObjectResult>(result);
        var badResult = result as BadRequestObjectResult;
        Assert.Equal("Issue Occur", badResult.Value);
    }




}


