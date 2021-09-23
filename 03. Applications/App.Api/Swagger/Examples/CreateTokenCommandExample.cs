﻿using Infra.ApplicationServices.Commands.Token;
using Swashbuckle.AspNetCore.Filters;

namespace App.Api.Swagger.Examples
{
    public sealed class CreateTokenCommandExample : IExamplesProvider<CreateTokenCommand>
    {
        public CreateTokenCommand GetExamples()
        {
            return new CreateTokenCommand
            {
                Username = "ExampleUser",
                Password = "Pass#123"
            };
        }
    }
}
