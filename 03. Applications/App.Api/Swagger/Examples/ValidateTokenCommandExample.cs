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
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
            };
        }
    }
}
