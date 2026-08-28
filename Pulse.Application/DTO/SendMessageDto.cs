using Pulse.Domain.Enums;

namespace Pulse.Application.DTO;

public class SendMessageDto
{
    public int ChatRoomId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? ReplyToMessageId { get; set; }
}

public class EditMessageDto
{
    public int MessageId { get; set; }
    public string Content { get; set; } = string.Empty;
}

public class MessageResponseDto
{
    public int Id { get; set; }
    public int ChatRoomId { get; set; }
    public int SenderId { get; set; }
    public string SenderName { get; set; } = string.Empty;
    public string? SenderAvatarUrl { get; set; }
    public string Content { get; set; } = string.Empty;
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public int? ReplyToMessageId { get; set; }
    public bool IsEdited { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime SentAt { get; set; }
    public List<ReactionDto> Reactions { get; set; } = new();
    public List<AttachmentDto> Attachments { get; set; } = new();
}