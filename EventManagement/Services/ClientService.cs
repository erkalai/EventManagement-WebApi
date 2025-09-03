using EventManagement.Entities;
using EventManagement.Repositories;

namespace EventManagement.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        public async Task<Client> CreateClientAsync(Client client)
        {
            await clientRepository.AddAsync(client);
            return client;
        }

        public async Task<bool> DeleteClientAsync(Guid id)
        {
            await clientRepository.DeleteAsync(id);
            return true;
        }

        public async Task<Client?> GetClientByIdAsync(Guid id) => await clientRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Client>> GetClientsAsync() => await clientRepository.GetAllAsync();

        public async Task<Client?> UpdateClientAsync(Client client)
        {
            var existingClient = await clientRepository.GetByIdAsync(client.ClientId);
            if (existingClient == null) return null;

            existingClient.ClientId = client.ClientId;
            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.PhoneNumber = client.PhoneNumber;
            existingClient.Address = client.Address;
            existingClient.Company = client.Company;

            await clientRepository.UpdateAsync(existingClient);
            return existingClient;
        }
    }
}
