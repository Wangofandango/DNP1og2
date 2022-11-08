using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.RedditPost;
using Shared.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }
    
    [HttpPost, Route("create")]
    public async Task<ActionResult> Register([FromBody] RedditPostCreateDto dto)
    {   
        try
        {
            await postService.CreatePost(dto);
             return Ok(dto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
       
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RedditPostBasicDto>>> GetAsync()
    {
        try
        {
            var posts = await postService.GetAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RedditPost>> GetById([FromRoute] int id)
    {
        Console.WriteLine(id);
        try
        {
            var result = await postService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}