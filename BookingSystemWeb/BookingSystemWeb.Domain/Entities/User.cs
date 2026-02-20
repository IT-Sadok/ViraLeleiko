using Microsoft.AspNetCore.Identity;
namespace BookingSystemWeb.Domain.Entities;

public class User: IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}