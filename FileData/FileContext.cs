using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string FilePath = "data.json";
    private DataContainer? _dataContainer;

    public ICollection<RedditPost> Posts
    {
        get
        {
            LoadData();
            return _dataContainer!.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return _dataContainer!.Users;
        }
    }

    private void LoadData()
    {
        if (_dataContainer != null) return;
        
        if (!File.Exists(FilePath))
        {
            _dataContainer = new ()
            {
                Users = new List<User>(),
                Posts = new List<RedditPost>()
            };
            return;
        }
        string content = File.ReadAllText(FilePath);
        
        _dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(_dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(FilePath, serialized);
        _dataContainer = null;
    }
}