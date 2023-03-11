using Api.Requests;
using Api.ResponseDto;
using Application.Exceptions;
using Application.UseCases.UserCrud;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : Controller
{
    private readonly IUserCrudUseCase _userCrudUseCase;

    public UserController(IUserCrudUseCase userCrudUseCase)
    {
        _userCrudUseCase = userCrudUseCase;
    }

    /// <summary>
    ///    Endpoint for get user by id
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userCrudUseCase.GetUser(id);

        if (user == null) return await Task.FromResult<IActionResult>(NotFound());

        return await Task.FromResult<IActionResult>(Ok(new UserDto(user)));
    }

    /// <summary>
    ///    Endpoint for create user
    /// </summary>
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] UserBody userBody)
    {
        try
        {
            var userCreated = await _userCrudUseCase.Create(userBody.Name, userBody.Email, userBody.PhoneNumber, userBody.Address);
            return await Task.FromResult<IActionResult>(Ok(new UserDto(userCreated)));
        }
        catch (EmailAlreadyExist e)
        {
            return await Task.FromResult<IActionResult>(BadRequest());
        }
    }

    /// <summary>
    ///    Endpoint for update user
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserBody userBody)
    {
        try
        {
            var userUpdated = await _userCrudUseCase.Update(id, userBody.Name, userBody.Email, userBody.PhoneNumber, userBody.Address);
            if (userUpdated == null) return await Task.FromResult<IActionResult>(NotFound());

            return await Task.FromResult<IActionResult>(Ok(new UserDto(userUpdated)));
        }
        catch (EmailAlreadyExist e)
        {
            return await Task.FromResult<IActionResult>(BadRequest());
        }
    }
}
