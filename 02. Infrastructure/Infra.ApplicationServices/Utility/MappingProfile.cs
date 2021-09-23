using AutoMapper;
using Core.DomainModel.UserAggregate.Entities;
using Infra.ApplicationServices.Commands.UserAggregate;
using Infra.ApplicationServices.Dtos;

namespace Infra.ApplicationServices.Utility
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
