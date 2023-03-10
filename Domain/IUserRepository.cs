using Domain.Entities;

namespace Core;

public interface IUserRepository
{
    public Task<User> Create(User user);
    public Task Update();
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser(Guid id);
}
