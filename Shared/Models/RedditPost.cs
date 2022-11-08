using System.ComponentModel.DataAnnotations;
using Shared.Dtos;

namespace Shared.Models;

public class RedditPost
{
    [Key]
    public int PostID { get; set; }
    public User? Author { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public string Created { get; set; }
}