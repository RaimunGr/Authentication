using Core.DomainModel.UserAggregate.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class UserExistsQueryHandler : IRequestHandler<UserExistsQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserExistsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> Handle(UserExistsQuery rq, CancellationToken cancellationToken)
        {
            var userExists = _userRepository.Exists(rq.UserId);
            return Task.FromResult(userExists);
        }
    }
}
