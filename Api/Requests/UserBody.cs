using System.ComponentModel.DataAnnotations;

namespace Api.Requests;

public class UserBody
{
    public UserBody(string name, string email, string? phoneNumber, string? address)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? Address { get; set; }
}
