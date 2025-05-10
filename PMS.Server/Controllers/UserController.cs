using Microsoft.AspNetCore.Mvc;
using MediatR;
using PMS.Server.DTOs.UserDTO.Queries;
using PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUser;
using PMS.Server.Responses;
using PMS.Server.Repositories.UserRepository.Handlers.Queries.GetUsers;
using PMS.Server.Repositories.UserRepository.Handlers.Commands.CreateUser;
using PMS.Server.Repositories.UserRepository.Handlers.Commands.UpdateUser;
using PMS.Server.Repositories.UserRepository.Handlers.Commands.DeleteUser;
using PMS.Server.DTOs.UserDTO.Commands;
using Microsoft.AspNetCore.Authorization;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными пользователей.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/users")]
    [ApiController]
    [Tags("Пользователи")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных пользователя по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /users/1
        /// </remarks>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Данные пользователя.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /users
        /// </remarks>
        /// <returns>Список пользователей.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(GetUserItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserItemResponse[]>> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /users
        /// </remarks>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /users/1
        /// </remarks>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequest request)
        {
            var command = new UpdateUserCommand(
                Id: id,
                Login: request.Login,
                Password: request.Password,
                Name: request.Name,
                IsActive: request.IsActive
            );

            await _mediator.Send(command);
            return Ok();                
        }

        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /users/1
        /// </remarks>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
