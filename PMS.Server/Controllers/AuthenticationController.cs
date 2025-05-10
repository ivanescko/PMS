using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.Repositories.AuthenticationRepository.Handlers.Commands;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    [Route("api/auth")]
    [ApiController]
    [Tags("Аутентификация")]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> LogIn([FromBody] LoginCommand command)
        {
            string token = await _mediator.Send(command);
            return Ok(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LogOut()
        {
            return Ok();
        }        
    }
}
