using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Commands.UserAggregate
{
    public sealed class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
