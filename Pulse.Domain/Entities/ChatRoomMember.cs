using Pulse.Domain.Enums;

namespace Pulse.Domain.Entities;

public class ChatRoomMember
{
    public int Id { get; set; }

    public int ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public MemberRole Role { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime? LastReadAt { get; set; }
    public bool IsMuted { get; set; }
}