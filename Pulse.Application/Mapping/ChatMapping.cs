using AutoMapper;
using Pulse.Application.DTO;
using Pulse.Domain.Entities;

namespace Pulse.Application.Mapping;

public class ChatMapping : Profile
{
    public ChatMapping()
    {
        CreateMap<CreateRoomDto, ChatRoom>();
        CreateMap<ChatRoom, RoomResponseDto>();

        CreateMap<ChatRoomMember, RoomMemberDto>()
            .ForMember(d => d.UserName, o 
                => o.MapFrom(s => s.User.UserName))
           
            .ForMember(d 
                => d.AvatarUrl, o => o.MapFrom(s => s.User.AvatarUrl))
          
            .ForMember(d 
                => d.Status, o => o.MapFrom(s => s.User.Status));
    }
}