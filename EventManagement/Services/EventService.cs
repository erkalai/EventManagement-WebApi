using EventManagement.Entities;
using EventManagement.Repositories;

namespace EventManagement.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public Task<IEnumerable<Event>> GetEventsAsync() => eventRepository.GetAllAsync();
        public Task<Event?> GetEventByIdAsync(Guid id) => eventRepository.GetByIdAsync(id);

        public async Task<Event> CreateEventAsync(Event ev)
        {
            await eventRepository.AddAsync(ev);
            return ev;
        }
        public async Task<Event?> UpdateEventAsync(Event ev)
        {
            await eventRepository.UpdateAsync(ev);
            return ev;
        }

        public async Task<bool> DeleteEventAsync(Guid id)
        {
            await eventRepository.DeleteAsync(id);
            return true;
        }  
    }
}
