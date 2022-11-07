using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace FileData.DAO;

public class UserFileDao : IUserDao
{
    private readonly FileContext _context;

    public UserFileDao(FileContext context)
    {
        _context = context;
    }
    
    public Task<User> CreateAsync(User user)
    {
        
        _context.Users.Add(user);
        _context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = _context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
           
        );
        return Task.FromResult(existing);
    }

  

    
}