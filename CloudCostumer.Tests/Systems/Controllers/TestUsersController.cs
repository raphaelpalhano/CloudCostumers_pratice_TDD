using CloudCostumer.API.Controllers;
using CloudCostumer.API.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace CloudCostumer.Tests.Systems.Controllers;


public class TestUsersController
{
    
    [Fact(DisplayName = "Sucesso na requisição - Statuscode 200")]
    public async Task Get_Retornar_StatusCode200()
    {
        // Arrange: system under test, sistema que está sendo testado
        var mockUsersService = new Mock<IUsersService>();
       
        mockUsersService.Setup(service => service.GetAllUsers())
           .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact(DisplayName = "Invocando o UserService apenas uma vez")]
    public async Task Get_Sucesso_Em_Invocar_O_UserService_Extamente_Uma_vez()
    {
        // Arrange: system under test, sistema que está sendo testado
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService.Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);


        //Act
        var result = await sut.Get();


        //Assert
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }


   

}



