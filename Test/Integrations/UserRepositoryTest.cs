using System;
using System.Threading.Tasks;
using Core;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Test.Integrations;

public class UserRepositoryTest
{
    public class Create
    {
        private readonly IUserRepository _repo;

        public Create()
        {
        }

        [Fact]
        public async Task It_Success_When_UserDataValid()
        {
            // Arrange
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "someEmail@mail.com",
                Name = "Some Name"
            };

            // Act
            var exception = await Record.ExceptionAsync(async () => await _repo.Create(user));

            // Assert
            exception.Should().BeNull();
        }
    }
}
