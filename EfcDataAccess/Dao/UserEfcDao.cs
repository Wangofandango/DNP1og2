using Application.DaoInterfaces;
using Shared.Models;

namespace EfcDataAccess.Dao;

public class UserEfcDao : IUserDao
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}