using System;
using Core.Entities;
using FluentAssertions;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Configurations;
using Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Options;
using Xunit;

namespace Test.Integrations;

public class UserRepositoryTest
{
    public class Create
    {
        private readonly UserRepository _repo;

        public Create()
        {
            MongoConfiguration appSettings = new MongoConfiguration()
            {
                ConnectionString = "mongodb://root:example@localhost:27019/",
                DatabaseName = "PII"
            };
            IOptions<MongoConfiguration> options = Options.Create(appSettings);
            var dbContext = new MongoDbContext(options);
            _repo = new UserRepository(dbContext);
        }

        [Fact]
        public void It_Success_When_UserDataValid()
        {
            // Arrange
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "someEmail@mail.com",
                Name = "Some Name"
            };

            // Act
            var exception = Record.Exception(() => _repo.Create(user));

            // Assert
            exception.Should().BeNull();
        }
    }
}
