using System.Net.Mail;
using Domain;
using Domain.Entities;

namespace Infrastructure.DataAccess.Factories;

public class UserFactory : IUserFactory
{
    public User NewUser(string name, string email, string? phoneNumber, string? address)
    {
        return new User(Guid.NewGuid(), name, new MailAddress(email), phoneNumber, address);
    }

    public User NewUser(Guid id, string name, string email, string? phoneNumber, string? address)
    {
        return new User(id, name, new MailAddress(email), phoneNumber, address);
    }
}
