using System;
using System.Threading.Tasks;
using Api.Controllers.V1;
using Api.ResponseDto;
using Application.UseCases.UserCrud;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.DataAccess.Factories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests.Api.Controllers.V1;

public class UserControllerTest
{
    private readonly Mock<IUserCrudUseCase> _useCase;
    private readonly UserController _controller;
    private readonly UserFactory _factory;

    public UserControllerTest()
    {
        _useCase = new Mock<IUserCrudUseCase>();
        _controller = new UserController(_useCase.Object);
        _factory = new UserFactory();
    }

    [Fact]
    public async Task GetUser_Return_Ok()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(id, "name", "some@mail.com", "0987654321", "some address");
        _useCase.Setup(r => r.GetUser(It.IsAny<Guid>())).ReturnsAsync(user);

        // Act
        var actual = await _controller.Get(id);

        // Assert
        actual.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetUser_Return_NotFound_When_UserNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _useCase.Setup(r => r.GetUser(It.IsAny<Guid>())).ReturnsAsync((User?)null);

        // Act
        var actual = await _controller.Get(id);

        // Assert
        actual.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetUser_Return_UserDto()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(id, "name", "some@mail.com", "0987654321", "some address");
        _useCase.Setup(r => r.GetUser(It.IsAny<Guid>())).ReturnsAsync(user);

        // Act
        var actual = (OkObjectResult) await _controller.Get(id);

        // Assert
        actual.Value.Should().BeOfType<UserDto>();
    }
}
