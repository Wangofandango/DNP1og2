using Shared.Dtos.RedditPost;
using Shared.Models;

namespace WebApi.Services;

public interface IPostService
{
    public Task CreatePost(RedditPostCreateDto dto);
    public Task<IEnumerable<RedditPostBasicDto>> GetAsync();
    public Task<RedditPost?> GetById(int id);
}