using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : EntityController<User>
    {
        private readonly IAuthService _authService;
        public UserController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Register(string login, string password)
        {
            //ControllerContext.HttpContext.User.Claims
            var result = await _mediator.Send(new CreateCommand<User>(new User() { Login = login, Password = password }));
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Auth(string login, string password)
        {
            //ControllerContext.HttpContext.User.Claims
            var result = await _authService.CreateToken(login, password);
            return Ok(new
            {
                access_token = result
            });
        }
    }
}
