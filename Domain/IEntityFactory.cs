using Domain.Entities;

namespace Domain;

public interface IEntityFactory
{
    public User NewUser(string name, string email, string? phoneNumber, string? address);
    public User NewUser(Guid id, string name, string email, string? phoneNumber, string? address);
}
