using Pulse.Application.DTO;

namespace Pulse.Application.Interfaces.Service;

public interface IMessageService
{
    Task<MessageResponseDto> SendMessage(int userId, SendMessageDto dto, CancellationToken ct);
    Task<List<MessageResponseDto>> GetRoomMessages(int userId, int roomId, int skip, int take, CancellationToken ct);
}