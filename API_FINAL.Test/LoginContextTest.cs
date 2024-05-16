using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_FINAL.Models;

namespace API_FINAL.Test
{
    public class LoginContextTest
    {
        [Fact]

        public void Login_Validate_ShouldPassValidation()
        {
            var login = new Login
            {
                Id = 1,
                username = "abc",
                password = "aaa",
                IsActive = true
               
            };
            Assert.True(ValidateModel(login));
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]

        public void Login_MissingRequiredUsername_ShouldFailValidation(string username)
        {
            var login = new Login
            {
                Id = 1,
                username = username,
                password = "aaa"

            };
            Assert.False(ValidateModel(login));
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]

        public void Login_MissingRequiredPassword_ShouldFailValidation(string Password)
        {
            var login = new Login
            {
                Id = 1,
                username = "abc",
                password = Password

            };
            Assert.False(ValidateModel(login));
        }


        private bool ValidateModel(object model)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model, serviceProvider: null, items: null);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
        }
    }
}
