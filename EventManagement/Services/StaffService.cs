using EventManagement.Entities;
using EventManagement.Repositories;

namespace EventManagement.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> staffRepository;

        public StaffService(IRepository<Staff> staffRepository)
        {
            this.staffRepository = staffRepository;
        }
        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            await staffRepository.AddAsync(staff);
            return staff;
        }

        public async Task<bool> DeleteStaffAsync(Guid id)
        {
            await staffRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Staff>> GetStaffAsync() => await staffRepository.GetAllAsync();

        public async Task<Staff?> GetStaffByIdAsync(Guid id) => await staffRepository.GetByIdAsync(id);

        public async Task<Staff?> UpdateStaffAsync(Staff staff)
        {
            var existingStaff = await staffRepository.GetByIdAsync(staff.StaffId);

            existingStaff.StaffId = staff.StaffId;
            existingStaff.Name = staff.Name;
            existingStaff.Role = staff.Role;
            existingStaff.Email = staff.Email;
            existingStaff.PhoneNumber = staff.PhoneNumber;
            existingStaff.AvailabilityStatus = staff.AvailabilityStatus;


            await staffRepository.UpdateAsync(existingStaff);
            return existingStaff;
        }
    }
}
