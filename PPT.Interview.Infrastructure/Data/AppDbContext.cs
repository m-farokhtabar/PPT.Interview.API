using Microsoft.EntityFrameworkCore;
using PPT.Interview.Infrastructure.Data.Model;
using System;
namespace PPT.Interview.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
    {
    }
    public DbSet<ImageModel> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        const string url = "https://api.dicebear.com/8.x/pixel-art/png?seed=db1&size=150";
        modelBuilder.Entity<ImageModel>().HasData(
                                                   new ImageModel { Id = 1, Url = url },
                                                   new ImageModel { Id = 2, Url = url },
                                                   new ImageModel { Id = 3, Url = url },
                                                   new ImageModel { Id = 4, Url = url },
                                                   new ImageModel { Id = 5, Url = url }
                                                 );
        base.OnModelCreating(modelBuilder);
    }

}
