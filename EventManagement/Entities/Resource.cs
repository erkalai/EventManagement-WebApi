namespace EventManagement.Entities
{
    public class Resource
    {
        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
