using API_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_FINAL.Test
{
    public class RegistrationContextTest
    {

        
            [Fact]
            public void Registration_ValidProperties_ShouldPassValidation()
            {
                // Arrange
                var registration = new Registration
                {
                    id = 1,
                    userid = 123,
                    fname = "John",
                    lname = "Doe",
                    email = "john.doe@example.com",
                    city = "New York"
                };

            // Act & Assert
        
            Assert.True(ValidateModel(registration));
            }

            [Theory]
            [InlineData(null)] 
            [InlineData("")]   
            public void Registration_MissingRequiredFname_ShouldFailValidation(string fname)
            {
                // Arrange
                var registration = new Registration
                {
                    id = 1,
                    userid = 123,
                    fname = fname, 
                    lname = "Doe",
                    email = "john.doe@example.com",
                    city = "New York"
                };

                // Act & Assert
                // it means if this thig false then the test will pass ( so we got  it it return false )
                Assert.False(ValidateModel(registration));
            }

            [Theory]
            [InlineData(null)] 
            [InlineData("")]   
            public void Registration_MissingRequiredLname_ShouldFailValidation(string lname)
            {
                // Arrange
                var registration = new Registration
                {
                    id = 1,
                    userid = 123,
                    fname = "John",
                    lname = lname, 
                    email = "john.doe@example.com",
                    city = "New York"
                };

                // Act & Assert
                Assert.False(ValidateModel(registration));
            }

            [Theory]
           
            [InlineData("john.doe.com")] 
            [InlineData("@example.com")] 
            public void Registration_InvalidEmailFormat_ShouldFailValidation(string email)
            {
                // Arrange
                var registration = new Registration
                {
                    id = 1,
                    userid = 123,
                    fname = "John",
                    lname = "Doe",
                    email = email, 
                    city = "New York"
                };

                // Act & Assert
                Assert.False(ValidateModel(registration));
            }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Registration_MissingRequiredcity_ShouldFailValidation(string city)
        {
            // Arrange
            var registration = new Registration
            {
                id = 1,
                userid = 123,
                fname = "John",
                lname = "John",
                email = "john.doe@example.com",
                city = city
            };

            // Act & Assert
            Assert.False(ValidateModel(registration));
        }

        // this is method that actually check the model (Google Reference :) )
        private bool ValidateModel(object model)
            {
                var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model, serviceProvider: null, items: null);
                var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

                return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            }
        }
    }


