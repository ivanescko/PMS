using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Model.Entities;
using PMS.Server.DTOs.WorkTeamStatusDTO.Commands;
using PMS.Server.DTOs.WorkTeamStatusDTO.Queries;
using PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.CreateWorkTeamStatus;
using PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.DeleteWorkTeamStatus;
using PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Commands.UpdateWorkTeamStatus;
using PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatus;
using PMS.Server.Repositories.WorkTeamStatusRepository.Handlers.Queries.GetWorkTeamStatuses;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными статусов команд.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/workTeamStatuses")]
    [ApiController]
    [Tags("Статус команды")]
    public class WorkTeamStatusController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных статуса команд по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /workTeamStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <returns>Данные категории команд.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetWorkTeamStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetWorkTeamStatusResponse>> GetWorkTeamStatus([FromRoute] int id)
        {
            var query = new GetWorkTeamStatusQuery(id);
            var workTeamStatuses = await _mediator.Send(query);
            return Ok(workTeamStatuses);
        }

        /// <summary>
        /// Получение списка статуса команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /workTeamStatuses
        /// </remarks>
        /// <returns>Список статуса команд.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetWorkTeamStatusItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetWorkTeamStatusItemResponse[]>> GetWorkTeamStatuses()
        {
            var query = new GetWorkTeamStatusesQuery();
            var workTeamStatuses = await _mediator.Send(query);
            return Ok(workTeamStatuses);
        }

        /// <summary>
        /// Создание статуса команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /workTeamStatuses
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateWorkTeamStatus([FromBody] CreateWorkTeamStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление статуса команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /workTeamStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateWorkTeamStatus([FromRoute] int id, [FromBody] UpdateWorkTeamStatusRequest request)
        {
            var command = new UpdateWorkTeamStatusCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление статуса команд.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /workTeamStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса команд.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWorkTeamStatus([FromRoute] int id)
        {
            var command = new DeleteWorkTeamStatusCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
