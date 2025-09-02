using EventManagement.Entities;

namespace EventManagement.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event?> GetEventByIdAsync(Guid id);
        Task<Event> CreateEventAsync(Event ev);
        Task<Event?> UpdateEventAsync(Event ev);
        Task<bool> DeleteEventAsync(Guid id);
    }
}
