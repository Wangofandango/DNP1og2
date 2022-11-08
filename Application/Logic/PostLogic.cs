using Application.DaoInterfaces;
using Shared.Dtos.RedditPost;
using Shared.Models;
using WebApi.LogicInterfaces;

namespace WebApi.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO _postDao;
    private readonly IUserDao _userDao;
    public PostLogic(IPostDAO postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }

    public async Task<RedditPost> CreateAsync(RedditPostCreateDto dto)
    {
        ValidateData(dto);

        User? author = await _userDao.GetByUsernameAsync(dto.Author);
        
        if (author == null)
        {
            throw new NullReferenceException("Author name for post creation is null");
        }
        
        RedditPost postToCreate = new RedditPost
        {
            Title = dto.Title,
            Body = dto.Body,
            Author = author,
            Created = DateTime.Now.ToShortDateString()
        };
        
        RedditPost created = await _postDao.CreateAsync(postToCreate);
        
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