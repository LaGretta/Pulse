using Pulse.Domain.Enums;

namespace Pulse.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public UserStatus Status { get; set; }
    public DateTime LastSeenAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Message> Messages { get; set; } = new();
    public List<ChatRoomMember> Memberships { get; set; } = new();
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}