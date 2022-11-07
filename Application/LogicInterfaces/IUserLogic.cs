using Shared.Dtos;
using Shared.Models;

namespace WebApi.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreateDto dto);
    public Task<User?> GetByUsernameAsync(string Username);
}

