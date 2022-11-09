using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace EfcDataAccess.Dao;

public class PostEfcDao : IPostDAO
{
    private readonly DataContext _context;

    public PostEfcDao(DataContext context)
    {
        _context = context;
    }
    
    public async Task<RedditPost> CreateAsync(RedditPost postToCreate)
    {
        int postId = 1;

        if (_context.RedditPosts.Any())
        {
            postId = _context.RedditPosts.Max(u => postId);
            postId++;
        }

        postToCreate.PostID = postId;

        EntityEntry<RedditPost> postToReturn = await _context.RedditPosts.AddAsync(postToCreate);
        await _context.SaveChangesAsync();
        return postToReturn.Entity;
    }

    public async Task<IEnumerable<RedditPostBasicDto>> GetAsync()
    {
        IEnumerable<RedditPostBasicDto> redditPostBasicDtos = _context.RedditPosts
            .Include(redditPost => redditPost.Author)
            .Select(c =>
                new RedditPostBasicDto()
                {
                    title = c.Title,
                    author = c.Author.Username,
                    created = c.Created,
                    postId = c.PostID
                }
            ).ToList();


        foreach (var postBasicDto in redditPostBasicDtos)
        {
            Console.WriteLine(postBasicDto.author + postBasicDto.title + postBasicDto.created);
        }
        return await Task.FromResult(redditPostBasicDtos.AsEnumerable());

    }

    public async Task<RedditPost> getById(int id)
    {
        RedditPost result = await _context.RedditPosts.FirstAsync(p => p.PostID == id)!;

        return result;
    }
    
    
}