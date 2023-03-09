using Core.Entities;

namespace Core;

public interface IUserRepository
{
    public void Create(User user);
    public IEnumerable<User> GetUsers();
    public User GetUser();
    public User Update();
}
