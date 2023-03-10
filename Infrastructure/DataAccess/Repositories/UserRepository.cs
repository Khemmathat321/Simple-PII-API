using Core;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        var result = await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public Task Update()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(string id)
    {
        var user = await _context.User.Where(q => q.Id == id).Select(q => q).SingleOrDefaultAsync().ConfigureAwait(false);

        return user;
    }
}
