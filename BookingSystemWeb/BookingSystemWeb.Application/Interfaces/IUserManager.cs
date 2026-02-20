using BookingSystemWeb.Domain.Entities;

namespace BookingSystemWeb.Application.Interfaces;

public interface IUserManager
{
    Task<bool> CreateAsync(User user, string password);
    Task AddToRoleAsync(User user, string role);
    Task<User?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<IList<string>> GetRolesAsync(User user);
}