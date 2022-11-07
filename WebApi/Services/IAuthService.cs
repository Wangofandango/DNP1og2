using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task<Task> RegisterUser(UserCreateDto user);
}