using Core.Entities;

namespace Core;

public interface IUserRepository
{
    public User Create();
    public IEnumerable<User> GetUsers();
    public User GetUser();
    public User Update();
}
