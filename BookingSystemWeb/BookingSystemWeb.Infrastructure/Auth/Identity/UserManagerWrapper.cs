using BookingSystemWeb.Application.Interfaces;
using BookingSystemWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookingSystemWeb.Infrastructure.Auth.Identity;

public class UserManagerWrapper: IUserManager
{
    private readonly UserManager<User> _userManager;

    public UserManagerWrapper(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<bool> CreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception(errors);
        }

        return true;
    }

    public async Task AddToRoleAsync(User user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetRolesAsync(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}