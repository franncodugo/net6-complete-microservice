using Microsoft.EntityFrameworkCore;
using PlatformService.Domain.Models;

namespace PlatformService.Infrastructure.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<Platform> Platforms { get; set; }
}