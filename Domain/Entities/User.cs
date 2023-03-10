namespace Domain.Entities;

public class User
{
    public User(string id, string name, string email, string? phoneNumber, string? address)
    {
        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
