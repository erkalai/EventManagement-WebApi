using EventManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Entities
{
    public class Billing
    {
        [Key]
        public Guid BillId { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int DueAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public PaymentStatus PaymentStatus { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}
