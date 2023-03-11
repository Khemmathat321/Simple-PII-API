using System.Net.Mail;
using Domain;
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

    public async Task<User?> Update(User user)
    {
        var record = await _context.User.Where(q => q.Id == user.Id).SingleOrDefaultAsync();
        if (record == null) return null;

        record.Email = user.Email;
        record.Name = user.Name;
        record.PhoneNumber = user.PhoneNumber;
        record.Address = user.Address;

        await _context.SaveChangesAsync();
        return record;
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsers(MailAddress mailAddress)
    {
        return await _context.User.Where(q => q.Email == mailAddress).ToListAsync();
    }

    public async Task<User?> GetUser(Guid id)
    {
        return await _context.User.Where(q => q.Id == id).SingleOrDefaultAsync();
    }
}
