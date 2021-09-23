using AutoMapper;
using Core.DomainModel.UserAggregate.Data;
using Core.DomainModel.UserAggregate.Entities;
using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserDto> Handle(GetUserByIdQuery rq, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(rq.Id);
            var userDto = _mapper.Map<User, UserDto>(user);

            return Task.FromResult(userDto);
        }
    }
}
