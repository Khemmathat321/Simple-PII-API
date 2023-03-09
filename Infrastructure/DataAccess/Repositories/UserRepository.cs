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

    public void Create(User user)
    {
        _context.User.InsertOne(user);
    }

    public IEnumerable<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUser()
    {
        throw new NotImplementedException();
    }

    public User Update()
    {
        throw new NotImplementedException();
    }
}
