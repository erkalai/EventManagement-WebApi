using EventManagement.Entities;

namespace EventManagement.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client?> GetClientByIdAsync(Guid id);
        Task<Client> CreateClientAsync(Client client);
        Task<Client?> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(Guid id);
    }
}
