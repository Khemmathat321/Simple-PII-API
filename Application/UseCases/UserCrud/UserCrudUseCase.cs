using System.Net.Mail;
using Application.Exceptions;
using Domain;
using Domain.Entities;

namespace Application.UseCases.UserCrud;

public class UserCrudUseCase : IUserCrudUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;

    public UserCrudUseCase(IUserRepository userRepository, IUserFactory userFactory)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
    }

    public async Task<User> Create(string name, string email, string? phoneNumber, string? address)
    {
        var users = await _userRepository.GetUsers(new MailAddress(email));
        if (users.Any()) throw new EmailAlreadyExistException();

        var user = _userFactory.NewUser(name, email, phoneNumber, address);
        return await _userRepository.Create(user);
    }

    public async Task<User?> Update(Guid id, string name, string email, string? phoneNumber, string? address)
    {
        var users = await _userRepository.GetUsers(new MailAddress(email));
        if (users.Any(q => q.Id != id)) throw new EmailAlreadyExistException();

        var user = _userFactory.NewUser(id, name, email, phoneNumber, address);
        return await _userRepository.Update(user);
    }

    public async Task<User?> GetUser(Guid id)
    {
        return await _userRepository.GetUser(id);
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
