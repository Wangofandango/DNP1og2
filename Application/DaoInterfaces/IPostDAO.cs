using Shared.Dtos.RedditPost;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDAO
{
    Task<RedditPost> CreateAsync(RedditPost postToCreate);
    Task<IEnumerable<RedditPostBasicDto>> GetAsync();
    Task<RedditPost> getById(int id);
}