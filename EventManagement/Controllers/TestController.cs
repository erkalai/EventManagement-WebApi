using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var connectionString = "Host=aws-1-ap-south-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.cllsesmkiqwmnejwjjxe;Password=cU3RT31bxRVRwAjt;SSL Mode=Require;Trust Server Certificate=true;";

                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                using var command = new NpgsqlCommand("SELECT 1", connection);
                var result = command.ExecuteScalar();

                return Ok(new { message = "Database connection successful!", result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Database connection failed.", error = ex.Message });
            }
        }
    }
}
