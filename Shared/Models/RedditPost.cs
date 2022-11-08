using System.ComponentModel.DataAnnotations;
using Shared.Dtos;
using Shared.Dtos.RedditPost;

namespace Shared.Models;

public class RedditPost
{
    [Key]
    public int PostID { get; set; }
    public User Author { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Created { get; set; }
    
    // private RedditPost() {}
}