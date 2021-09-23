using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Infra.ApplicationServices.Queries.UserAggregate
{
    public sealed class SearchUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public SearchUsersQuery()
        {}

        public SearchUsersQuery(string searchQuery)
        {
            SearchQuery = searchQuery;
        }

        public string SearchQuery { get; private set; }
    }
}
