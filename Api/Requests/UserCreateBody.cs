using System.ComponentModel.DataAnnotations;

namespace Api.Requests;

public class UserCreateBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
