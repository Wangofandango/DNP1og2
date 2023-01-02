using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos;

public class TestAnnotation
{  
    [Display(Name = "navn")]
    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, MinimumLength = 5,ErrorMessage = "{0} must be between {2} and {1} characters long")]
    public string name { get; set; }
    
    [Range(1,99)]
    public int age { get; set; }
    
    [EmailAddress]
    public string? email { get; set; }
    
    [Required]
    public string dogsName { get; set; }
}