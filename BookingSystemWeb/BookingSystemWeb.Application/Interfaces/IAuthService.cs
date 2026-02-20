using BookingSystemWeb.Application.Models;

namespace BookingSystemWeb.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterUserRequest request);
    Task<string> LoginAsync(LoginRequest request);
}