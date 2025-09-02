using EventManagement.Entities;

namespace EventManagement.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetStaffAsync();
        Task<Staff?> GetStaffByIdAsync(Guid id);
        Task<Staff> CreateStaffAsync(Staff staff);
        Task<Staff?> UpdateStaffAsync(Staff staff);
        Task<bool> DeleteStaffAsync(Guid id);
    }
}
