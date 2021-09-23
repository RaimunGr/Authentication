using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Commands.Token
{
    public sealed class ValidateTokenCommand : IRequest<TokenValidationDto>
    {
        public string Token { get; set; }
    }
}
