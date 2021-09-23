using MediatR;
using System;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class UserExistsQuery : IRequest<bool>
    {
        public UserExistsQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
