using AutoMapper;
using Core.DomainModel.UserAggregate.Data;
using Core.DomainModel.UserAggregate.Entities;
using Infra.ApplicationServices.Dtos;
using Infra.Dal;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.UserAggregate
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand rq, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<CreateUserCommand, User>(rq); ;
            var dbUser = _userRepository.Create(user);
            await _unitOfWork.CommitAsync();
            var userDto = _mapper.Map<User, UserDto>(dbUser);
            return userDto;
        }
    }
}
