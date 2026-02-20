using System;
using System.Threading.Tasks;
using BookingSystemWeb.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystemWeb.Infrastructure.Data;

public class RoleSeeder
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<IRoleManager>();

        string[] roles = { "Client", "Host" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateRoleAsync(role);
            }
        }
    }
}