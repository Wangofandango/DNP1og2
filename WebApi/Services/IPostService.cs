using Shared.Dtos.RedditPost;
using Shared.Models;

namespace WebApi.Services;

public interface IPostService
{
    public Task CreatePost(RedditPostCreateDto dto);
    public Task<IEnumerable<RedditPostBasicDto>> getAsync();
    public Task<RedditPost> getById(int id);
}