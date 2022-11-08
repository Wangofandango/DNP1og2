using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class User
{
    [Key]
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    
    public string Name { get; set; }
 
    public int Age { get; set; }
 
    
  
}