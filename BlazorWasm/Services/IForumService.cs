using Shared.Dtos;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace BlazorWasm.Services;

public interface IForumService
{
    public Task<ICollection<RedditPostBasicDto>> getAsync();
    public Task CreatePost(string title, string body, UserBasicDto author);
    public Task<RedditPost> getSpecificAsync(int id);
}