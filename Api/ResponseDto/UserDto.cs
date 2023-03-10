using Domain.Entities;

namespace Api.ResponseDto;

public class UserDto
{
    public UserDto(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Address = user.Address;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
