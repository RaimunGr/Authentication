using Infra.ApplicationServices.Commands.UserAggregate;
using Swashbuckle.AspNetCore.Filters;

namespace App.Shared.Swagger.Examples
{
    public sealed class CreateUserCommandExample : IExamplesProvider<CreateUserCommand>
    {
        public CreateUserCommand GetExamples()
        {
            return new CreateUserCommand
            {
                FirstName = "Farshad",
                LastName = "Goodarzi",
                Username = "ExampleUser",
                Password = "Pass#123",
            };
        }
    }
}
