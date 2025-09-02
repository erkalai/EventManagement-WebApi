using EventManagement.Entities;
using EventManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventManagement.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IRepository<Resource> resourceRepository;

        public ResourceService(IRepository<Resource> resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public async Task<Resource> CreateResourceAsync(Resource resource)
        {
            await resourceRepository.AddAsync(resource);
            return resource;
        }

        public async Task<bool> DeleteResourceAsync(Guid id)
        {
            await resourceRepository.DeleteAsync(id);
            return true;
        }

        public async Task<Resource?> GetResourceByIdAsync(Guid id) => await resourceRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Resource>> GetResourcesAsync() => await resourceRepository.GetAllAsync();

        public async Task<Resource?> UpdateResourceAsync(Resource resource)
        {
            var existingResource = await resourceRepository.GetByIdAsync(resource.ResourceId);
            if (existingResource == null)
                return null;

            existingResource.ResourceId = resource.ResourceId;
            existingResource.Name = resource.Name;
            existingResource.Description = resource.Description;
            existingResource.Type = resource.Type;
            existingResource.QuantityAvailable = resource.QuantityAvailable;

            await resourceRepository.UpdateAsync(existingResource);
            return existingResource;

        }
    }
}
