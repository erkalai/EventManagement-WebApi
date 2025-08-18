namespace EventManagement.Entities
{
    public class Billingt
    {
        public Guid BillId { get; set; }
        public Event EventId { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int DueAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PaymentStatus { get; set; }

    }
}
