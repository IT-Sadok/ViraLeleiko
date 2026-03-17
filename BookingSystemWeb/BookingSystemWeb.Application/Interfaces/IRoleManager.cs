namespace BookingSystemWeb.Application.Interfaces;

public interface IRoleManager
{
    Task<bool> RoleExistsAsync(string role);
    Task CreateRoleAsync(string role);
}