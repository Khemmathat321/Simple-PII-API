using Core;
using Domain.Entities;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        _context.User.Add(user);
        // await _context.User.AddAsync(user).ConfigureAwait(false);
    }

    public Task Update()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(string id)
    {
        throw new NotImplementedException();
    }
}
