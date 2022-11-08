using Application.DaoInterfaces;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace EfcDataAccess.Dao;

public class PostEfcDao : IPostDAO
{
    public Task<RedditPost> CreateAsync(RedditPost postToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RedditPostBasicDto>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RedditPost> getById(int id)
    {
        throw new NotImplementedException();
    }
    
    
}