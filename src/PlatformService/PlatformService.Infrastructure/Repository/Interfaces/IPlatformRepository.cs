using PlatformService.Domain.Models;

namespace PlatformService.Infrastructure.Repository.Interfaces;

public interface IPlatformRepository
{
    Task SaveChangesAsync();
    Task<IEnumerable<Platform>> GetAllPlatforms();
    Task<Platform> GetPlatformById(int id);
    Task CreatePlatform(Platform platform);
}