using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;
using Shared.Dtos;
using Shared.Models;
using WebApi.Logic;
using WebApi.LogicInterfaces;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private IUserLogic UserLogic;

    public AuthService(IUserLogic userLogic)
    {
        UserLogic = userLogic;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await UserLogic.GetByUsernameAsync(username);
        if (existingUser == null)
        {           
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        { throw new Exception("Password mismatch");
        }

        return await Task.FromResult(existingUser);
    }

    public async Task<Task> RegisterUser(UserCreateDto user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ValidationException("Email cannot be null");
        }  
        if (string.IsNullOrEmpty(user.Name))
        {
            throw new ValidationException("Name cannot be null");
        }  
        
        
        await UserLogic.CreateAsync(user);
        
        return Task.CompletedTask;
    }
}