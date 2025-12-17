using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartTask.UserService.Application.Commands;
using SmartTask.UserService.Application.Queries;

namespace SmartTask.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await mediator.Send(new GetUserQuery(id));

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var result = mediator.Send(request);
            return Ok(result);
        }
    }
}
