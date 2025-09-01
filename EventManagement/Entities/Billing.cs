using EventManagement.Enums;

namespace EventManagement.Entities
{
    public class Billing
    {
        public Guid BillId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public PaymentStatus PaymentStatus { get; set; }
    }
}
