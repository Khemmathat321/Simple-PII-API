using System.Net.Mail;

namespace Domain.Entities;

public class User
{
    public User(Guid id, string name, MailAddress email, string? phoneNumber, string? address)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public MailAddress Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
