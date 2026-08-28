namespace Pulse.Application.DTO;

public class AddReactionDto
{
    public int MessageId { get; set; }
    public string Emoji { get; set; } = string.Empty;
}

public class ReactionDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Emoji { get; set; } = string.Empty;
}