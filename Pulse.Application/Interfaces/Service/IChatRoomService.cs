using Pulse.Application.DTO;

namespace Pulse.Application.Interfaces.Service;

public interface IChatRoomService
{
    Task<RoomResponseDto> CreateRoom(int userId, CreateRoomDto dto, CancellationToken ct);
    Task<List<RoomResponseDto>> GetMyRooms(int userId, CancellationToken ct);
    Task<RoomResponseDto> GetRoomById(int userId, int roomId, CancellationToken ct);
    Task JoinRoom(int userId, int roomId, CancellationToken ct);
    Task<List<RoomMemberDto>> GetRoomMembers(int userId, int roomId, CancellationToken ct);
}