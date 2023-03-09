using Core.Entities;

namespace Core;

public interface IUserRepository
{
    public Task Create(User user);
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser();
    public Task Update();
}
