using Pulse.Domain.Entities;

namespace Pulse.Application.Interfaces.Repository;

public interface IAuthRepository
{
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
    Task<bool> ExistsByUserNameAsync(string userName, CancellationToken ct);
    Task AddUserAsync(User user, CancellationToken ct);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);

    Task AddRefreshTokenAsync(RefreshToken token, CancellationToken ct);
    Task<RefreshToken?> GetRefreshTokenAsync(string token, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}