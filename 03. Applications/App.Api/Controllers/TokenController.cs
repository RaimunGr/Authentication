using App.Api.Swagger.Examples;
using App.Api.ApiResponse;
using Infra.ApplicationServices.Commands.Token;
using Infra.ApplicationServices.Utility;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Refreshes tokens. User should be authorized to be able to refresh the token.
        /// </summary>
        /// <returns>Token</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            var id = Guid.Parse(User.Claims.First(c => c.Type == RaimunClaimTypes.Id).Value);
            var command = new RefreshTokenCommand(id);
            var tokenDto = await _mediator.Send(command);
            return tokenDto.ToActionResult();
        }

        /// <summary>
        /// Creates token.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Token</returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateTokenCommand), typeof(CreateTokenCommandExample))]
        public async Task<IActionResult> CreateToken(CreateTokenCommand command)
        {
            var tokenDto = await _mediator.Send(command);
            return tokenDto.ToActionResult();
        }

        /// <summary>
        /// Checks if the specified token is valid or not.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("validate")]
        [SwaggerRequestExample(typeof(ValidateTokenCommand), typeof(ValidateTokenCommandExample))]
        public async Task<IActionResult> Validate(ValidateTokenCommand command)
        {
            var tokenValidationDto = await _mediator.Send(command);
            return tokenValidationDto.ToActionResult();
        }
    }
}
