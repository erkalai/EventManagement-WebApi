using EventManagement.Entities;
using EventManagement.Models;

namespace EventManagement.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
