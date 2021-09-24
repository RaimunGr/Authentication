using App.Api.ApiResponse;
using App.Api.Swagger.Examples;
using Infra.ApplicationServices.Commands.UserAggregate;
using Infra.ApplicationServices.Queries.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace App.Api.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Search for users.
        /// </summary>
        /// <param name="search">Substring of user name, id, phone number, role, username or email</param>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            var query = new SearchUsersQuery(search);
            var usersDto = await _mediator.Send(query);
            return usersDto.ToActionResult();
        }

        /// <summary>
        /// Gets user using his/her id.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var userDto = await _mediator.Send(query);
            return userDto.ToActionResult();
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateUserCommand), typeof(CreateUserCommandExample))]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var userDto = await _mediator.Send(command);
            return userDto.ToActionResult(HttpStatusCode.Created);
        }
    }
}
