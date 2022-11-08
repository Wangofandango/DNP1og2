using Shared.Dtos;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace BlazorWasm.Services;

public interface IForumService
{
    public Task<ICollection<RedditPostBasicDto>> getAsync();
    public Task CreatePost(RedditPostCreateDto dto);
    public Task<RedditPost> getSpecificAsync(int id);
}