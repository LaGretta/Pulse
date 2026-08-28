using Microsoft.EntityFrameworkCore.Storage;
using Pulse.Application.Interfaces;
using Pulse.Infrastructure.Data;

namespace Pulse.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly PulseDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(PulseDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);

    public async Task BeginTransactionAsync(CancellationToken ct) =>
        _transaction = await _context.Database.BeginTransactionAsync(ct);

    public async Task CommitTransactionAsync(CancellationToken ct)
    {
        if (_transaction != null)
            await _transaction.CommitAsync(ct);
    }

    public async Task RollbackTransactionAsync(CancellationToken ct)
    {
        if (_transaction != null)
            await _transaction.RollbackAsync(ct);
    }
}