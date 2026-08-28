using Microsoft.Extensions.Configuration;
using Pulse.Application.DTO;
using Pulse.Application.Interfaces.Repository;
using Pulse.Application.Interfaces.Security;
using Pulse.Application.Interfaces.Service;
using Pulse.Domain.Entities;
using Pulse.Domain.Enums;

namespace Pulse.Application.Service;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _jwt;
    private readonly IConfiguration _config;

    public AuthService(
        IAuthRepository repo,
        IPasswordHasher hasher,
        IJwtTokenGenerator jwt,
        IConfiguration config)
    {
        _repo = repo;
        _hasher = hasher;
        _jwt = jwt;
        _config = config;
    }

    public async Task<AuthResponseDto> Register(RegisterDto dto, CancellationToken ct)
    {
        if (await _repo.ExistsByEmailAsync(dto.Email, ct))
            throw new InvalidOperationException("Email already in use");
        if (await _repo.ExistsByUserNameAsync(dto.UserName, ct))
            throw new InvalidOperationException("Username already taken");

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = _hasher.Hash(dto.Password),
            Status = UserStatus.Offline,
            LastSeenAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddUserAsync(user, ct);
        await _repo.SaveChangesAsync(ct);

        return await BuildAuthResponse(user, ct);
    }

    public async Task<AuthResponseDto> Login(LoginDto dto, CancellationToken ct)
    {
        var user = await _repo.GetByEmailAsync(dto.Email, ct);
        if (user == null || !_hasher.Verify(dto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        return await BuildAuthResponse(user, ct);
    }

    public async Task<AuthResponseDto> Refresh(string refreshToken, CancellationToken ct)
    {
        var existing = await _repo.GetRefreshTokenAsync(refreshToken, ct);
        if (existing == null || !existing.IsActive)
            throw new UnauthorizedAccessException("Invalid refresh token");

        existing.IsRevoked = true;
        await _repo.SaveChangesAsync(ct);

        return await BuildAuthResponse(existing.User, ct);
    }

    public async Task Logout(string refreshToken, CancellationToken ct)
    {
        var existing = await _repo.GetRefreshTokenAsync(refreshToken, ct);
        if (existing != null && !existing.IsRevoked)
        {
            existing.IsRevoked = true;
            await _repo.SaveChangesAsync(ct);
        }
    }

    private async Task<AuthResponseDto> BuildAuthResponse(User user, CancellationToken ct)
    {
        var accessToken = _jwt.GenerateAccessToken(user);
        var refreshToken = _jwt.GenerateRefreshToken();

        var days = int.Parse(_config["Jwt:RefreshTokenDays"]!);
        await _repo.AddRefreshTokenAsync(new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(days),
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false
        }, ct);
        await _repo.SaveChangesAsync(ct);

        return new AuthResponseDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}