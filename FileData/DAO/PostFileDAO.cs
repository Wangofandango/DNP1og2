using Application.DaoInterfaces;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace FileData.DAO;

public class PostFileDAO : IPostDAO
{
    private readonly FileContext _context;

    public PostFileDAO(FileContext context)
    {
        _context = context;
    }
    public Task<RedditPost> CreateAsync(RedditPost postToCreate)
    {
        int postId = 1;
        if (_context.Posts.Any())
        {
            postId = _context.Posts.Max(p => p.PostID);
            postId++;
        }

        postToCreate.PostID = postId;
       
        _context.Posts.Add(postToCreate);
        _context.SaveChanges();

        return Task.FromResult(postToCreate);
    }

    public Task<IEnumerable<RedditPostBasicDto>> GetAsync()
    {
        IEnumerable<RedditPost> result = _context.Posts.AsEnumerable();
        ICollection<RedditPostBasicDto> resultBasicDtos = new List<RedditPostBasicDto>();
        foreach (var post in result)
        {
            resultBasicDtos.Add(new RedditPostBasicDto
            {
                title = post.title,
                author = post.Author,
                created = post.Created,
                postId = post.PostID
            });
        }
        
        return Task.FromResult(resultBasicDtos.AsEnumerable());
    }

    public Task<RedditPost> getById(int id)
    {
        RedditPost result = _context.Posts.FirstOrDefault(p => p.PostID == id)!;
        
        Console.WriteLine(result.PostID);
        Console.WriteLine(result.title);
        return Task.FromResult(result);
    }
}