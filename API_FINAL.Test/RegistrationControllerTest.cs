using API_FINAL.Controllers;
using API_FINAL.Models;
using API_FINAL.Repository;
using API_FINAL.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;


public class RegistrationControllerTest
{

    [Fact]

    // if badrequest occur so how can it occur this is for it
    public async Task GetRegistration_Returns_BadRequest_TestPassed()
    {
        // Arrange
        int userId = 1; // it is mocked user id we can give anything  here

        List<Registration> expectedResult = null; // it Initializes that result will be null when this userid is fetched like its not matter you pass any id we mention it as null

        var mockRegistrationService = new Mock<IRegistrationService>(); // we have created a mock object of the IRS. it simulate the behaviour   

        // this is setup  for mock object to return ER when we call method.

        mockRegistrationService.Setup(x => x.GetRegistration(userId)).ReturnsAsync(expectedResult);

        // var controller = new RegistrationController creat instence of RC
        //Passed the mock RS as dependency
        // "null"  represent context dependency  
        // hear  we have passed actually controller constructor that took context as null and service object as normal Controller
        var controller = new RegistrationController(null, mockRegistrationService.Object);


        // Act
        // this line call getRegis.. on the controller instance with userid . it it push controller to retrive registration data. 
        var result = await controller.GetRegistration(userId);


        // Assert

        // this line showes the result returned by controller is of bad request means error occur 
        Assert.IsType<BadRequestObjectResult>(result);

        // 
        var badRequestResult = result as BadRequestObjectResult;

        // hear we check that actual result of badRequestResult Is matched with error message "not exist"
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


        var mockRegistrationService = new Mock<IRegistrationService>();

        mockRegistrationService.Setup(x => x.AddRegistration(registration)).ReturnsAsync((Registration)null);

        var controller = new RegistrationController(null, mockRegistrationService.Object);

        // Act
        var result = await controller.AddRegistration(registration);

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
        var mockRegistrationService = new Mock<IRegistrationService>();
        mockRegistrationService.Setup(x => x.AddRegistration(It.IsAny<Registration>())).ReturnsAsync(expectedResult);

        // hear  we have passed actually controller constructor that took context as null and service object as normal Controller
        var controller = new RegistrationController(null, mockRegistrationService.Object);

        // Act
        var result = await controller.AddRegistration(registration);

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

        var mockRegistrationService = new Mock<IRegistrationService>();

        mockRegistrationService.Setup(x => x.UpdateRegistration(registration)).ReturnsAsync(expectedResult);

        var controller = new RegistrationController(null, mockRegistrationService.Object);

        var result = await controller.UpdateRegistration(registration);

        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]

    public async Task UpdateRegistration_Returns_BadResult_TestPassed()
    {
        var registration = new Registration();

        var mockRegistrationService = new Mock<IRegistrationService>();

        mockRegistrationService.Setup(x => x.UpdateRegistration(It.IsAny<Registration>())).ReturnsAsync((Registration)null);


        var controller = new RegistrationController(null, mockRegistrationService.Object);

        var result = await controller.UpdateRegistration(registration);

        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.Equal("Not Found", badRequestResult.Value);
    }






[Fact]

    public async Task DeleteRegistration_Returns_OkResult_TestPassed()
    {
        var id = 1;

        string expectedResult = "User Deleted";

        var mockRegistrationService = new Mock<IRegistrationService>();

        mockRegistrationService.Setup(x => x.DeleteRegistration(id)).ReturnsAsync(expectedResult);


        var controller = new RegistrationController(null, mockRegistrationService.Object);

        var result = await controller.DeleteRegistration(id);

        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expectedResult, okResult.Value);

    }

    [Fact]

    public async Task DeleteRegistration_Returns_BadResult_TestPassed()
    {
        var id = 1;


        var mockRegistrationService = new Mock<IRegistrationService>();

        mockRegistrationService.Setup(x => x.DeleteRegistration(id)).ReturnsAsync((string)null);

        var controller = new RegistrationController(null, mockRegistrationService.Object);

        var result = await controller.DeleteRegistration(id);

        Assert.IsType<BadRequestObjectResult>(result);
        var badResult = result as BadRequestObjectResult;
        Assert.Equal("Issue Occur", badResult.Value);
    }




}


