using Pulse.Domain.Enums;

namespace Pulse.Application.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public UserStatus Status { get; set; }
    public DateTime LastSeenAt { get; set; }
}