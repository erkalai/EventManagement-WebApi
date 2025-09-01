namespace EventManagement.Entities
{
    public class EventStaff
    {
        public Guid EventStaffId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
    }
}
