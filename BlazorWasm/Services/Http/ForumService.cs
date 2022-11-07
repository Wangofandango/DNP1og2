using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Shared.Dtos;
using Shared.Dtos.RedditPost;
using Shared.Models;

namespace BlazorWasm.Services.Http;

public class ForumService : IForumService
{
    private readonly HttpClient client = new();
    public async Task<ICollection<RedditPostBasicDto>> getAsync()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7130/post");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<RedditPostBasicDto> posts = JsonSerializer.Deserialize<ICollection<RedditPostBasicDto>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return posts;

    }
    
    
    public async Task CreatePost(string title, string body, UserBasicDto author)
    {
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
       //Dette skal udføres hver gang du ville kalde en metode som kræver authorization. Lav en generel metode

       RedditPostCreateDto redditPostCreateDto = new()
        {
            Title = title,
            Body = body,
            Author = author.Username!
        };

        string postAsJson = JsonSerializer.Serialize(redditPostCreateDto);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7130/post/create", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<RedditPost> getSpecificAsync(int id)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);

        HttpResponseMessage response = await client.GetAsync($"https://localhost:7130/post/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        RedditPost post = JsonSerializer.Deserialize<RedditPost>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
     
     
     return post;
    }
}