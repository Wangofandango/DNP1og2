using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;
using WebApi.LogicInterfaces;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;


    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreateDto dto)
    {
        User? existing = await _userDao.GetByUsernameAsync(dto.Username);
        
        if (existing != null)
            throw new ValidationException("Username already taken!");

        ValidateData(dto);
        
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Email = dto.Email,
            Name = dto.Name,
            Age = dto.Age
        };
        
        User created = await _userDao.CreateAsync(toCreate);
        
        return created;
    }
    

    public async Task<User?> GetByUsernameAsync(string Username)
    {
        return await _userDao.GetByUsernameAsync(Username);
    }

    
    private void ValidateData(UserCreateDto userToCreate)
    {
        string userName = userToCreate.Username;
        
        Console.WriteLine(userName.Length);
        if (userName.Length < 3)
        {
            throw new ValidationException("Username must be at least 3 characters!");
        }

        if (userName.Length > 15)
            throw new ValidationException("Username must be less than 16 characters!");
        
        if (!userToCreate.Email.Contains("@"))
            throw new ValidationException("Email must contain '@'");
        
        if (userToCreate.Age < 18)
            throw new ValidationException("Age must be above 18!");
    }
}