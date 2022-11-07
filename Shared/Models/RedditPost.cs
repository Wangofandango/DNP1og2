using Shared.Dtos;

namespace Shared.Models;

public class RedditPost
{
    public int PostID { get; set; }
    public string Author { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public string Created { get; set; }
}