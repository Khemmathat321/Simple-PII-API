using System.Net.Mail;
using Api.Requests;
using Api.ResponseDto;
using Core;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    ///    Endpoint for get user by id
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userRepository.GetUser(id);

        return await Task.FromResult<IActionResult>(Ok(new UserDto(user)));
    }

    /// <summary>
    ///    Endpoint for create user
    /// </summary>
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] UserCreateBody userCreateBody)
    {
        var user = new User(new Guid(), userCreateBody.Name, new MailAddress(userCreateBody.Email), userCreateBody.PhoneNumber, userCreateBody.Address);
        var userCreated = await _userRepository.Create(user);

        return await Task.FromResult<IActionResult>(Ok(new UserDto(userCreated)));
    }

    /// <summary>
    ///    Endpoint for update user
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateBody userUpdateBody)
    {
        var user = new User(id, userUpdateBody.Name, new MailAddress(userUpdateBody.Email), userUpdateBody.PhoneNumber, userUpdateBody.Address);

        var userUpdated = await _userRepository.Update(user);

        return await Task.FromResult<IActionResult>(Ok(new UserDto(userUpdated)));
    }
}
