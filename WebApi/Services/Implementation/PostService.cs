using System.ComponentModel.DataAnnotations;
using Shared.Dtos.RedditPost;
using Shared.Models;
using WebApi.Logic;
using WebApi.LogicInterfaces;

namespace WebApi.Services;

public class PostService : IPostService
{
    private IPostLogic _postLogic;

    public PostService(IPostLogic postlogic)
    {
        _postLogic = postlogic;
    }
    public async Task CreatePost(RedditPostCreateDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new ValidationException("Title cannot be null");
        }
        if (string.IsNullOrEmpty(dto.Body))
        {
            throw new ValidationException("Body cannot be null");
        }
        if (string.IsNullOrEmpty(dto.Author))
        {
            throw new ValidationException("Author Name cannot be null");
        }

        await _postLogic.CreateAsync(dto);
    }

    public async Task<IEnumerable<RedditPostBasicDto>> GetAsync()
    {
        return await _postLogic.GetAsync();
    }

    public async Task<RedditPost?> GetById(int id)
    {
        return await _postLogic.GetById(id);
    }
}