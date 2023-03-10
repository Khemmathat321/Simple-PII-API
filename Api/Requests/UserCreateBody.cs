using System.ComponentModel.DataAnnotations;

namespace Api.Requests;

public class UserCreateBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
