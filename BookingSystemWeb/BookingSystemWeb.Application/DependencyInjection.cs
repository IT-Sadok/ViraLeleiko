using Microsoft.Extensions.DependencyInjection;
using BookingSystemWeb.Application.Interfaces;
using BookingSystemWeb.Application.Services;
namespace BookingSystemWeb.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}