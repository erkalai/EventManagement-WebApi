using EventManagement.Entities;
using EventManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;
        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources()
        {
            var resource = await resourceService.GetResourcesAsync();
            return Ok(resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(Guid id)
        {
            var resource = await resourceService.GetResourceByIdAsync(id);
            if (resource == null) return NotFound();
            return Ok(resource);
        }
        [HttpPost]
        public async Task<IActionResult> CreateResource(Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdResource = await resourceService.CreateResourceAsync(resource);
            return CreatedAtAction(nameof(GetResourceById), new { id = createdResource.ResourceId }, createdResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource(Guid id, Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != resource.ResourceId)
                return BadRequest("Resource Id Mismatch");

            var existingResource = await resourceService.GetResourceByIdAsync(id);

            if (existingResource == null)
                return NotFound("Resource Not Found");

            var updated = await resourceService.UpdateResourceAsync(resource);
            return updated == null ? NotFound() : Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(Guid id)
        {
            var existingResource = await resourceService.GetResourceByIdAsync(id);

            if (existingResource == null)
                return NotFound("Resource Not Found");

            var deleted = await resourceService.DeleteResourceAsync(id);
            return deleted ? NoContent() : BadRequest("Failed To Delete");
        }
    }

}
