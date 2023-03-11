using Domain.Entities;

namespace Application.UseCases.UserCrud;

public interface IUserCrudUseCase
{
    public Task<User> Create(string name, string email, string? phoneNumber, string? address);
    public Task<User?> Update(Guid id, string name, string email, string? phoneNumber, string? address);
    public Task<User?> GetUser(Guid id);
    public Task<bool> Delete(Guid id);
}
