using Domain.Entities;

namespace Domain;

public interface IUserRepository
{
    public Task<User> Create(User user);
    public Task<User> Update(User user);
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser(Guid id);
}
