using System.Net.Mail;
using Domain;
using Domain.Entities;
using Infrastructure.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

public class UserRawSqlRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRawSqlRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        FormattableString sql = @$"
            INSERT INTO users (Id, Name, Email, PhoneNumber, Address)
            VALUES ({user.Id.ToString()}, {user.Name}, {user.Email.Address}, {user.PhoneNumber}, {user.Address})
        ";
        var affectedRows = await _context.Database.ExecuteSqlAsync(sql);

        if (affectedRows == 0) throw new SqlActionException("create", "user");

        return user;
    }

    public async Task<User> Update(User user)
    {
        FormattableString sql = @$"
            UPDATE users t
            SET t.Name = {user.Name}, t.Email = {user.Email.Address}, t.PhoneNumber = {user.PhoneNumber}, t.Address = {user.Address}
            WHERE t.Id = {user.Id.ToString()}
        ";
        var affectedRows = await _context.Database.ExecuteSqlAsync(sql);

        if (affectedRows == 0) throw new SqlActionException("update", "user");

        return user;
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsers(MailAddress mailAddress)
    {
        return await _context.User.FromSql($"SELECT * FROM users WHERE Email = {mailAddress.Address}")
            .ToListAsync();
    }

    public async Task<User?> GetUser(Guid id)
    {
        return await _context.User.FromSql($"SELECT * FROM users WHERE Id = {id.ToString()}")
            .SingleOrDefaultAsync();
    }
}
