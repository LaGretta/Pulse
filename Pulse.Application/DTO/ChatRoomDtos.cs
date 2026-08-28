using Pulse.Domain.Enums;

namespace Pulse.Application.DTO;

public class CreateRoomDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ChatRoomType Type { get; set; }
}
public class RoomResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? AvatarUrl { get; set; }
    public ChatRoomType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public int MembersCount { get; set; }
    public MessageResponseDto? LastMessage { get; set; }   
    public int UnreadCount { get; set; }                
}     
public class RoomMemberDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public MemberRole Role { get; set; }
    public UserStatus Status { get; set; }
}