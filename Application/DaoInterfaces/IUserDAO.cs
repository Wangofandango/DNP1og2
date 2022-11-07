using Shared.Dtos;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
}