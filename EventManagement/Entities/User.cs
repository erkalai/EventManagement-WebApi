namespace EventManagement.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string PhoneNumber { get; set; } = string.Empty;
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public bool IsActive { get; set; } = true;
        //public DateTime? LastLogin { get; set; }
        //public string? ProfilePictureUrl { get; set; }
        //public string? PostalCode { get; set; }
        //public DateTime? DateOfBirth { get; set; }
    }
}
