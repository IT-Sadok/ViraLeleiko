using BookingSystemWeb.Application.Models;
using BookingSystemWeb.Domain.Entities;
using Mapster;

namespace BookingSystemWeb.Application.Common.Mappings;

public class UserMappings
{
    public static void Register()
    {
        TypeAdapterConfig<RegisterUserRequest, User>
            .NewConfig()
            .Map(dest => dest.UserName, src => src.Email);
    }
    
}