using Domain.Entities;

namespace Domain;

public interface IUserFactory
{
    public User NewUser(string name, string email, string? phoneNumber, string? address);
    public User NewUser(Guid id, string name, string email, string? phoneNumber, string? address);
}
