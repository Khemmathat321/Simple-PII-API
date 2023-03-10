using System;
using System.Threading.Tasks;
using Core;
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
        public async Task It_Success_When_UserDataValid()
        {
            // Arrange
            var user = new User(Guid.NewGuid().ToString(), "Some Name", "some@mail.com", "0987654321", "address fake");

            // Act
            await _repo.Create(user);

            // Assert
            Console.WriteLine("test");
        }
    }
}
