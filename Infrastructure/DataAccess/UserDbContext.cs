using System.Net.Mail;
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
            "server=localhost;Port=3308;UserID=root;pwd=root;Database=pii",
            ServerVersion.Parse("5.7.38-mysql"));
    }


    public DbSet<User> User { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>()
            .Property(b => b.Email)
            .HasConversion(v => v.Address, v => new MailAddress(v)).IsRequired();
    }
}
