using Pulse.Domain.Entities;

namespace Pulse.Application.Interfaces.Repository;

public interface IChatRoomRepository
{
    Task AddRoomAsync(ChatRoom room, CancellationToken ct);
    Task<ChatRoom?> GetRoomByIdAsync(int roomId, CancellationToken ct);
    Task<List<ChatRoom>> GetUserRoomsAsync(int userId, CancellationToken ct);

    Task AddMemberAsync(ChatRoomMember member, CancellationToken ct);
    Task<ChatRoomMember?> GetMemberAsync(int roomId, int userId, CancellationToken ct);
    Task<bool> IsMemberAsync(int roomId, int userId, CancellationToken ct);
    Task<List<ChatRoomMember>> GetRoomMembersAsync(int roomId, CancellationToken ct);

    Task SaveChangesAsync(CancellationToken ct);
}