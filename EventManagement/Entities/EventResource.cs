namespace EventManagement.Entities
{
    public class EventResource
    {
        public Guid EventResourceId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; } = null!;
        public int QuantityUsed { get; set; }
    }
}
