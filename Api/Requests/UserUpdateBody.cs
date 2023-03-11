using System.ComponentModel.DataAnnotations;

namespace Api.Requests;

public class UserUpdateBody
{
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
