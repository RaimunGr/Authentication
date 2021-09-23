using Core.DomainModel.UserAggregate.Data;
using Infra.ApplicationServices.Dtos;
using Infra.ApplicationServices.Utility;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.Token
{
    public sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public RefreshTokenCommandHandler(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public Task<TokenDto> Handle(RefreshTokenCommand rq, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(rq.Id);

            var secret = TokenSecretExtractor.Extract(_configuration);
            var tokenDto = TokenHandler.CreateFromUser(secret, user);

            return Task.FromResult(tokenDto);
        }
    }
}
