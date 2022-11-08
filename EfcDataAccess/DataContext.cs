using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EfcDataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RedditPost> RedditPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Data.db");
    }
    
    
}   