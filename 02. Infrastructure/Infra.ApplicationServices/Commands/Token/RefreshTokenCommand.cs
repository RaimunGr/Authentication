using Infra.ApplicationServices.Dtos;
using MediatR;
using System;

namespace Infra.ApplicationServices.Commands.Token
{
    public sealed class RefreshTokenCommand : IRequest<TokenDto>
    {
        private RefreshTokenCommand()
        { }

        public RefreshTokenCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
