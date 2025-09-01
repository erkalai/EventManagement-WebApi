
using EventManagement.Enums;

namespace EventManagement.Entities
{
    public class Staff
    {
        public Guid StaffId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }
        public ICollection<EventStaff> EventStaffs { get; set; } = new List<EventStaff>();
    }
}
