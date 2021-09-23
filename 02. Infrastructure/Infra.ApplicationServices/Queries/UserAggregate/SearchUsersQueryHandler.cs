using AutoMapper;
using Core.DomainModel.UserAggregate.Data;
using Core.DomainModel.UserAggregate.Entities;
using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class SearchUsersQueryHandler : IRequestHandler<SearchUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SearchUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserDto>> Handle(SearchUsersQuery rq, CancellationToken cancellationToken)
        {
            var users = _userRepository.Search(rq.SearchQuery);
            var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            return Task.FromResult(usersDto);
        }
    }
}
