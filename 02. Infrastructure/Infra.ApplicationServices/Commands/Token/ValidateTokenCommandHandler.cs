using Infra.ApplicationServices.Dtos;
using Infra.ApplicationServices.Utility;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.Token
{
    public sealed class ValidateTokenCommandHandler : IRequestHandler<ValidateTokenCommand, TokenValidationDto>
    {
        private readonly IConfiguration _configuration;

        public ValidateTokenCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<TokenValidationDto> Handle(ValidateTokenCommand rq, CancellationToken cancellationToken)
        {
            var secret = TokenSecretExtractor.Extract(_configuration);
            var isValid = TokenHandler.Validate(secret, rq.Token);

            return Task.FromResult(new TokenValidationDto
            {
                IsValid = isValid
            });
        }
    }
}
