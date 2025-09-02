using EventManagement.Entities;
using EventManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService staffService;
        public StaffController(IStaffService staffService)
        {
            this.staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await staffService.GetStaffAsync();
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            var staff = await staffService.GetStaffByIdAsync(id);
            if (staff == null) return NotFound();
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdStaff = await staffService.CreateStaffAsync(staff);
            return CreatedAtAction(nameof(GetAllStaff), new { id = createdStaff.StaffId }, createdStaff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(Guid id, Staff staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != staff.StaffId)
                return BadRequest("Staff Id Mismatch");

            var existingStaff = await staffService.GetStaffByIdAsync(id);
            if (existingStaff == null)
                return NotFound("User Not Found");

            var updated = await staffService.UpdateStaffAsync(staff);

            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var existingStaff = await staffService.GetStaffByIdAsync(id);
            if (existingStaff == null)
                return NotFound();
            var deleted = await staffService.DeleteStaffAsync(id);

            return deleted ? NoContent() : BadRequest("Failed To Delete");
        }
    }
}
