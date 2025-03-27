using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanOrigination.Controllers;
using LoanOrigination.Models.CustomerSearch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LoanTestPrj
{
    public class FindCustomerTest
    {
        [Fact]
        public void GetCustomer_ReturnsOkResult_WhenCustomersExist()
        {
            // Arrange
            var mockDal = new Mock<ICustomerDataAccess>();
            var customers = new List<Customer>
        {
            new Customer {
                Id = 1,
                FirstName = "ac",
                LastName = "abc",
                Date_of_Birth = new DateOnly(2002, 10, 09),
                Phone = "1234567890",
                Email = "abc@123",
                Address = "abc",
                Company_Name = "abc",
                Salary = 123,
                Net_Income = 123,
                Last_salary_date = new DateOnly(1990, 01, 02)
            },
            new Customer {
                Id = 3,
                FirstName = "abc",
                LastName = "abc",
                Date_of_Birth = new DateOnly(2002, 10, 09),
                Phone = "string",
                Email = "string",
                Address = "string",
                Company_Name = "string",
                Salary = 0,
                Net_Income = 0,
                Last_salary_date = new DateOnly(2025, 03, 26)
            }
        };

            mockDal.Setup(d => d.GetCustomer("abc", "abc", new DateOnly(2002, 10, 09))).Returns(customers);
            var controller = new FindCustomerController(mockDal.Object);

            // Act
            var result = controller.GetCustomer("abc", "abc", new DateOnly(2002, 10, 09));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCustomers = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal(2, returnedCustomers.Count);
            Assert.Equal("ac", returnedCustomers[0].FirstName);
        }
    }
    
}
