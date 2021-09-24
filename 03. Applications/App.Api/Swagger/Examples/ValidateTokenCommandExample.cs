using Infra.ApplicationServices.Commands.Token;
using Swashbuckle.AspNetCore.Filters;

namespace App.Api.Swagger.Examples
{
    public sealed class ValidateTokenCommandExample : IExamplesProvider<ValidateTokenCommand>
    {
        public ValidateTokenCommand GetExamples()
        {
            return new ValidateTokenCommand
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjAwNjMwYTEzLWNmODEtNGZhMS04MmU2LWY2NzkwMWExNGY4YSIsInVuaXF1ZV9uYW1lIjoiRmFyc2hhZCBHb29kYXJ6aSIsInVzZXJuYW1lIjoiRXhhbXBsZVVzZXIiLCJuYmYiOjE2MzI0NDE1MTgsImV4cCI6MTYzMjQ0MzMxOCwiaWF0IjoxNjMyNDQxNTE4LCJpc3MiOiJodHRwczovL3JhaW11bi5jb20vIiwiYXVkIjoiaHR0cHM6Ly9yYWltdW4uY29tLyJ9.LvMXz82rIngzbMK4dZOud2MgU6MO_ifH_Gfuud-mOEA"
            };
        }
    }
}
