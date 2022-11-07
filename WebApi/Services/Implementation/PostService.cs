using System.ComponentModel.DataAnnotations;
using FileData.DAO;
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
    public Task CreatePost(RedditPostCreateDto dto)
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

        _postLogic.CreateAsync(dto);
        
        return Task.CompletedTask;
    }

    public Task<IEnumerable<RedditPostBasicDto>> getAsync()
    {
        return _postLogic.GetAsync();
    }

    public Task<RedditPost> getById(int id)
    {
        return _postLogic.GetById(id);
    }
}