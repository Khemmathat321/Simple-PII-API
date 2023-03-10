using Domain.Entities;

namespace Core;

public interface IUserRepository
{
    public Task Create(User user);
    public Task Update();
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser();
}
