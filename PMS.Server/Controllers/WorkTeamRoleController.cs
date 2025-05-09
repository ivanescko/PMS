using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Model.Entities;
using PMS.Server.DTOs.WorkTeamRoleDTO.Commands;
using PMS.Server.DTOs.WorkTeamRoleDTO.Queries;
using PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.CreateWorkTeamRole;
using PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.DeleteWorkTeamRole;
using PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Commands.UpdateWorkTeamRole;
using PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRole;
using PMS.Server.Repositories.WorkTeamRoleRepository.Handlers.Queries.GetWorkTeamRoles;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными ролей в командах.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/workTeamRoles")]
    [ApiController]
    [Tags("Роли в команде")]
    public class WorkTeamRoleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных ролей команд по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /workTeamRoles/1
        /// </remarks>
        /// <param name="id">Идентификатор ролей команд.</param>
        /// <returns>Данные категории команд.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetWorkTeamRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetWorkTeamRoleResponse>> GetWorkTeamRole([FromRoute] int id)
        {
            var query = new GetWorkTeamRoleQuery(id);
            var workTeamRoles = await _mediator.Send(query);
            return Ok(workTeamRoles);
        }

        /// <summary>
        /// Получение списка ролей команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /workTeamRoles
        /// </remarks>
        /// <returns>Список ролей команд.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetWorkTeamRoleItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetWorkTeamRoleItemResponse[]>> GetWorkTeamRolees()
        {
            var query = new GetWorkTeamRolesQuery();
            var workTeamRoles = await _mediator.Send(query);
            return Ok(workTeamRoles);
        }

        /// <summary>
        /// Создание ролей команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /workTeamRoles
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateWorkTeamRole([FromBody] CreateWorkTeamRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление ролей команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /workTeamRoles/1
        /// </remarks>
        /// <param name="id">Идентификатор ролей команд.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateWorkTeamRole([FromRoute] int id, [FromBody] UpdateWorkTeamRoleRequest request)
        {
            var command = new UpdateWorkTeamRoleCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление ролей команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /workTeamRoles/1
        /// </remarks>
        /// <param name="id">Идентификатор ролей команд.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWorkTeamRole([FromRoute] int id)
        {
            var command = new DeleteWorkTeamRoleCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
