using AutoMapper;
using Pulse.Application.DTO;
using Pulse.Domain.Entities;

namespace Pulse.Application.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, MessageResponseDto>()
            .ForMember(d => d.SenderName, o => o.MapFrom(s => s.Sender.UserName))
            .ForMember(d => d.SenderAvatarUrl, o => o.MapFrom(s => s.Sender.AvatarUrl));

        CreateMap<MessageReaction, ReactionDto>()
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.UserName));

        CreateMap<Attachment, AttachmentDto>();
    }
}