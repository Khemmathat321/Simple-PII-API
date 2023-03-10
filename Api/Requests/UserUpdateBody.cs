using System.ComponentModel.DataAnnotations;

namespace Api.Requests;

public class UserUpdateBody
{
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
