using AutoMapper;
using Pulse.Application.DTO;
using Pulse.Domain.Entities;

namespace Pulse.Application.Mapping;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<User, AuthResponseDto>();
        CreateMap<User, UserDto>();
    }
}