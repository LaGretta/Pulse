using Pulse.Domain.Enums;

namespace Pulse.Application.DTO;

public class AttachmentDto
{
    public int Id { get; set; }
    public AttachmentType Type { get; set; }
    public string Url { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
}