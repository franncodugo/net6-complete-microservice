using Microsoft.EntityFrameworkCore;
using PlatformService.Domain.Models;
using PlatformService.Infrastructure.Data;
using PlatformService.Infrastructure.Repository.Interfaces;

namespace PlatformService.Infrastructure.Repository;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _dbContext;

    public PlatformRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Platform>> GetAllPlatforms()
    {
        return await _dbContext.Set<Platform>()
            .ToListAsync();
    }

    public async Task<Platform> GetPlatformById(int id)
    {
        return await _dbContext.Set<Platform>()
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task CreatePlatform(Platform platform)
    {
        if (platform is null) throw new ArgumentNullException(nameof(platform));
        
        await _dbContext.AddAsync(platform);
        await this.SaveChangesAsync();
    }
}