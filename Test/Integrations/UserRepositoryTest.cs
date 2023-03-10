using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Xunit;

namespace Test.Integrations;

public class UserRepositoryTest
{
    public class Create
    {
        private readonly UserRepository _repo;

        public Create()
        {
            var context = new UserDbContext();
            _repo = new UserRepository(context);
        }

        [Fact]
        public async Task It_ReturnUser_When_UserDataValid()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), "Some Name", new MailAddress("some@mail.com"), "aaaaaa", "address fake");

            // Act
            var actual = await _repo.Create(user);

            // Assert
            actual.Id.Should().Be(user.Id);
        }
    }
}
