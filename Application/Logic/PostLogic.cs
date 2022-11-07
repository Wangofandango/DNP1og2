using Application.DaoInterfaces;
using Shared.Dtos.RedditPost;
using Shared.Models;
using WebApi.LogicInterfaces;

namespace WebApi.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO _postDao;

    public PostLogic(IPostDAO postDao)
    {
        _postDao = postDao;
    }

    public async Task<RedditPost> CreateAsync(RedditPostCreateDto dto)
    {
        ValidateData(dto);
        
        RedditPost PostToCreate = new RedditPost
        {
            title = dto.Title,
            body = dto.Body,
            Author = dto.Author,
            Created = DateTime.Now.ToShortDateString()
        };
        RedditPost created = await _postDao.CreateAsync(PostToCreate);
        return created;
    }

    public Task<IEnumerable<RedditPostBasicDto>> GetAsync()
    {
        return _postDao.GetAsync();
    }

    public Task<RedditPost?> GetById(int id)
    {
        return _postDao.getById(id);
    }

    private void ValidateData(RedditPostCreateDto dto)
    {
        //Validation stuff
        //Title/Body mp kun være så lang?
    }
}