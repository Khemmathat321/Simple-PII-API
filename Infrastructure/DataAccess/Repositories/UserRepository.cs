using Core;
using Core.Entities;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private MongoDbContext _context;

    public UserRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        await _context.User.InsertOneAsync(user);
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser()
    {
        throw new NotImplementedException();
    }

    public Task Update()
    {
        throw new NotImplementedException();
    }
}
