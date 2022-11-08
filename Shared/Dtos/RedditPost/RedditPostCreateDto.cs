using Shared.Models;

namespace Shared.Dtos.RedditPost;

public class RedditPostCreateDto
{
    public string Title { get; init; }
    public string Body { get; init; }
    public string Author { get; init; }

   
}