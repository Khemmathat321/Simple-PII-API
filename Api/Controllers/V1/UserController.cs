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
        var user = await _userRepository.GetUser(id.ToString());

        return await Task.FromResult<IActionResult>(Ok(new UserDto(user)));
    }
}
