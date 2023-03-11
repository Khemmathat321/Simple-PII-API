using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.UseCases.UserCrud;
using Domain;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.DataAccess.Factories;
using Moq;
using Xunit;

namespace UnitTests.Application.UseCase;

public class UserCrudUseCaseTest
{
    private readonly UserCrudUseCase _userCrudUseCase;
    private readonly UserFactory _factory;
    private readonly Mock<IUserRepository> _repo;

    public UserCrudUseCaseTest()
    {
        _repo = new Mock<IUserRepository>();
        _factory = new UserFactory();
        _userCrudUseCase = new UserCrudUseCase(_repo.Object, _factory);
    }

    [Theory]
    [InlineData("First Name", "first@mail.com", "123233333", "address1")]
    [InlineData("Second Name", "second@mail.com", "0987654321", "address2")]
    public async Task Create_Return_User(string name, string email, string number, string address)
    {
        // Arrange
        var user = _factory.NewUser(name, email, number, address);
        _repo.Setup(r => r.Create(It.IsAny<User>())).ReturnsAsync(user);

        // Act
        var actual = await _userCrudUseCase.Create(name, email, number, address);

        // Assert
        actual.Should().Be(user);
    }

    [Theory]
    [InlineData("First Name", "first@mail.com", "123233333", "address1")]
    [InlineData("Second Name", "second@mail", "0987654321", "address2")]
    public async Task Create_Throw_Error_When_EmailAlreadyExist(string name, string email, string number, string address)
    {
        // Arrange
        var user = _factory.NewUser(name, email, number, address);
        _repo.Setup(r => r.GetUsers(It.IsAny<MailAddress>())).ReturnsAsync(new [] {user});

        // Act
        var exception= await Record.ExceptionAsync(async () => await _userCrudUseCase.Create(name, email, number, address));

        // Assert
        exception.Should().BeOfType<EmailAlreadyExistException>();
    }

    [Theory]
    [InlineData("First Name", "first", "123233333", "address1")]
    [InlineData("Second Name", "mail.com", "0987654321", "address2")]
    public async Task Create_Throw_Error_When_Create_With_InvalidEmail(string name, string email, string number, string address)
    {
        // Act
        var exception= await Record.ExceptionAsync(async () => await _userCrudUseCase.Create(name, email, number, address));

        // Assert
        exception.Should().NotBeNull();
    }

    [Theory]
    [InlineData("First Name", "first@mail.com", "123233333", "address1")]
    [InlineData("Second Name", "second@mail.com", "0987654321", "address2")]
    public async Task Update_Return_User(string name, string email, string number, string address)
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(id, name, email, number, address);
        _repo.Setup(r => r.Update(It.IsAny<User>())).ReturnsAsync(user);

        // Act
        var actual = await _userCrudUseCase.Update(id, name, email, number, address);

        // Assert
        actual.Should().Be(user);
    }

    [Theory]
    [InlineData("First Name", "first@mail.com", "123233333", "address1")]
    [InlineData("Second Name", "second@mail", "0987654321", "address2")]
    public async Task Update_Return_User_When_Update_With_OwnEmail(string name, string email, string number, string address)
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(id, name, email, number, address);
        _repo.Setup(r => r.GetUsers(It.IsAny<MailAddress>())).ReturnsAsync(new [] {user});
        _repo.Setup(r => r.Update(It.IsAny<User>())).ReturnsAsync(user);

        // Act
        var actual = await _userCrudUseCase.Update(id, name, email, number, address);

        // Assert
        actual.Should().Be(user);
    }

    [Theory]
    [InlineData("First Name", "first@mail.com", "123233333", "address1")]
    [InlineData("Second Name", "second@mail", "0987654321", "address2")]
    public async Task Update_Throw_Error_When_EmailAlreadyExist(string name, string email, string number, string address)
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(name, "existing@mail.com", number, address);
        _repo.Setup(r => r.GetUsers(It.IsAny<MailAddress>())).ReturnsAsync(new [] {user});

        // Act
        var exception= await Record.ExceptionAsync(async () => await _userCrudUseCase.Update(id, name, email, number, address));

        // Assert
        exception.Should().BeOfType<EmailAlreadyExistException>();
    }

    [Theory]
    [InlineData("First Name", "first", "123233333", "address1")]
    [InlineData("Second Name", "mail.com", "0987654321", "address2")]
    public async Task Update_Throw_Error_When_Create_With_InvalidEmail(string name, string email, string number, string address)
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var exception= await Record.ExceptionAsync(async () => await _userCrudUseCase.Update(id, name, email, number, address));

        // Assert
        exception.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUser_Return_User()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = _factory.NewUser(id, "name", "some@mail.com", "0987654321", "some address");
        _repo.Setup(r => r.GetUser(It.IsAny<Guid>())).ReturnsAsync(user);

        // Act
        var actual = await _userCrudUseCase.GetUser(id);

        // Assert
        actual.Should().Be(user);
    }
    [Fact]
    public async Task Delete_Throw_NotImplementedError()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var exception= await Record.ExceptionAsync(async () => await _userCrudUseCase.Delete(id));

        // Assert
        exception.Should().BeOfType<NotImplementedException>();
    }

}
