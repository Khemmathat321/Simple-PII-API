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

    public string Id { get; }
    public string Name { get; }
    public string? Email { get; }
    public string? Address { get; }
    public string? PhoneNumber { get; }
}
