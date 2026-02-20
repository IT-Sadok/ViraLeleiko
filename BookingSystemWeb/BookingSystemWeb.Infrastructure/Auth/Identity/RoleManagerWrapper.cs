using BookingSystemWeb.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookingSystemWeb.Infrastructure.Auth.Identity;

public class RoleManagerWrapper: IRoleManager
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagerWrapper(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> RoleExistsAsync(string role)
    {
        return await _roleManager.RoleExistsAsync(role);
    }

    public async Task CreateRoleAsync(string role)
    {
        var result =  await _roleManager.CreateAsync(new IdentityRole(role));
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception(errors);
        }
    }
}