using EventManagement.Entities;
using EventManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await clientService.GetClientByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdClient = await clientService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.ClientId }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != client.ClientId)
                return BadRequest("Client Id Mismatched");

            var exisitingClient = await clientService.GetClientByIdAsync(id);
            if (exisitingClient == null)
                return NotFound();

            var updated = await clientService.UpdateClientAsync(client);

            return updated == null ? NotFound() : Ok(updated); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var existingClient = await clientService.GetClientByIdAsync(id);
            if (existingClient == null)
                return NotFound();
            var deleted = await clientService.DeleteClientAsync(id);
            return deleted ? NoContent() : BadRequest("Failed to Delete");
        }
    }
}
