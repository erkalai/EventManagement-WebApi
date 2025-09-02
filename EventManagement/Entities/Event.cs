
using EventManagement.Enums;

namespace EventManagement.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Venue { get; set; }
        public EventStatus Status { get; set; }

        public Guid ClientId { get; set; }
        public Guid StaffId { get; set; }
        public ICollection<EventResource> EventResources { get; set; } = new List<EventResource>();
        public Billing? Billing { get; set; }
    }
}
