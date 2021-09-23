using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Commands.Token
{
    public sealed class CreateTokenCommand : IRequest<TokenDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
