using Microsoft.EntityFrameworkCore;
using Pulse.Application.Interfaces.Repository;
using Pulse.Domain.Entities;
using Pulse.Infrastructure.Data;

namespace Pulse.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly PulseDbContext _context;

    public AuthRepository(PulseDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct) =>
        await _context.Users.AnyAsync(u => u.Email == email, ct);

    public async Task<bool> ExistsByUserNameAsync(string userName, CancellationToken ct) =>
        await _context.Users.AnyAsync(u => u.UserName == userName, ct);

    public async Task AddUserAsync(User user, CancellationToken ct) =>
        await _context.Users.AddAsync(user, ct);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);

    public async Task AddRefreshTokenAsync(RefreshToken token, CancellationToken ct) =>
        await _context.RefreshTokens.AddAsync(token, ct);

    public async Task<RefreshToken?> GetRefreshTokenAsync(string token, CancellationToken ct) =>
        await _context.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == token, ct);

    public async Task SaveChangesAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);
}