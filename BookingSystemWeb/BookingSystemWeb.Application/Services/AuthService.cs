using BookingSystemWeb.Application.Interfaces;
using BookingSystemWeb.Application.Models;
using BookingSystemWeb.Domain.Entities;
using MapsterMapper;

namespace BookingSystemWeb.Application.Services;

public class AuthService: IAuthService
{
    private readonly IUserManager _userManager;
    private readonly IRoleManager _roleManager;
    private readonly IJwtTokenGenerator _jwt;
    private readonly IMapper _mapper;

    public AuthService(
        IUserManager userManager,
        IRoleManager roleManager,
        IJwtTokenGenerator jwt,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwt;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterUserRequest request)
    {
        var roleExists = await _roleManager.RoleExistsAsync(request.Role);
        if (!roleExists)
            throw new Exception("Role does not exist");

        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
            throw new Exception("User already exists");

        var user = _mapper.Map<User>(request);

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result)
            throw new Exception("Failed to create user");

        await _userManager.AddToRoleAsync(user, request.Role);
    }

    public async Task<string> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new Exception("Invalid credentials");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
            throw new Exception("Invalid credentials");

        var roles = await _userManager.GetRolesAsync(user);

        var token = _jwt.GenerateToken(user, roles);

        return token;
    }
}
