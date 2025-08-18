namespace EventManagement.Entities
{
    public class EventStaff
    {
        public Guid EventStaffId { get; set; }
        public int EventId { get; set; }
        public int StaffId { get; set; }
    }
}
