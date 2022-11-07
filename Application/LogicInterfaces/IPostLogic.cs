using Shared.Dtos.RedditPost;
using Shared.Models;

namespace WebApi.LogicInterfaces;

public interface IPostLogic
{
    public Task<RedditPost> CreateAsync(RedditPostCreateDto dto);

    Task<IEnumerable<RedditPostBasicDto>> GetAsync();
    Task<RedditPost?> GetById(int id);
}