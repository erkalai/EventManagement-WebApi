namespace EventManagement.Entities
{
    public class Staff
    {
        public Guid StaffId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvailabilityStatus { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();

        
    }
}
