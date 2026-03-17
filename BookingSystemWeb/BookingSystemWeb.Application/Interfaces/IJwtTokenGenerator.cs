using BookingSystemWeb.Domain.Entities;

namespace BookingSystemWeb.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user, IEnumerable<string> roles);
}