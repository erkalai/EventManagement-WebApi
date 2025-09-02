using EventManagement.Entities;

namespace EventManagement.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetResourcesAsync();
        Task<Resource?> GetResourceByIdAsync(Guid id);
        Task<Resource> CreateResourceAsync(Resource resource);
        Task<Resource?> UpdateResourceAsync(Resource resource);
        Task<bool> DeleteResourceAsync(Guid id);
    }
}
