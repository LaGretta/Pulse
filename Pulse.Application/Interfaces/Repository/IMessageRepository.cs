using Pulse.Domain.Entities;

namespace Pulse.Application.Interfaces.Repository;

public interface IMessageRepository
{
    Task AddMessageAsync(Message message, CancellationToken ct);
    Task<Message?> GetMessageByIdAsync(int messageId, CancellationToken ct);
    Task<List<Message>> GetRoomMessagesAsync(int roomId, int skip, int take, CancellationToken ct);

    Task SaveChangesAsync(CancellationToken ct);
}