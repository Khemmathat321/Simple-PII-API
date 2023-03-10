using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class UserDbContext : DbContext
{
    public UserDbContext()
    {
        
    }
    
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;port=3308;uid=root;pwd=root;database=pii;allowzerodatetime=true;convert zero datetime=True;ssl mode=None",
            ServerVersion.Parse("5.7.38-mysql"));    }


    public DbSet<User> User { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
    }
}
