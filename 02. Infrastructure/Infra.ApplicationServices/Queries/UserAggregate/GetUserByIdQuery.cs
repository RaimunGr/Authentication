using Infra.ApplicationServices.Dtos;
using MediatR;
using System;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class GetUserByIdQuery : IRequest<UserDto>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
