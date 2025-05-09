using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.SprintTaskStatusDTO.Commands;
using PMS.Server.DTOs.SprintTaskStatusDTO.Queries;
using PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.CreateSprintTaskStatus;
using PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.DeleteSprintTaskStatus;
using PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Commands.UpdateSprintTaskStatus;
using PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatus;
using PMS.Server.Repositories.SprintTaskStatusRepository.Handlers.Queries.GetSprintTaskStatuses;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными статусов задач спринта.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/sprintTaskStatuses")]
    [ApiController]
    [Tags("Статусы задач спринта")]
    public class SprintTaskStatusController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных статуса задач спринта по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /sprintTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <returns>Данные категории задач спринта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetSprintTaskStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSprintTaskStatusResponse>> GetSprintTaskStatus([FromRoute] int id)
        {
            var query = new GetSprintTaskStatusQuery(id);
            var projectTaskStatus = await _mediator.Send(query);
            return Ok(projectTaskStatus);
        }

        /// <summary>
        /// Получение списка статуса задач спринта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /sprintTaskStatuses
        /// </remarks>
        /// <returns>Список статуса задач спринта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetSprintTaskStatusItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetSprintTaskStatusItemResponse[]>> GetSprintTaskStatuses()
        {
            var query = new GetSprintTaskStatusesQuery();
            var projectTaskStatuses = await _mediator.Send(query);
            return Ok(projectTaskStatuses);
        }

        /// <summary>
        /// Создание статуса задач спринта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /sprintTaskStatuses
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateSprintTaskStatus([FromBody] CreateSprintTaskStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление статуса задач спринта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /sprintTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateSprintTaskStatus([FromRoute] int id, [FromBody] UpdateSprintTaskStatusRequest request)
        {
            var command = new UpdateSprintTaskStatusCommand(
                Id: id,
                Title: request.Title
                //Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление статуса задач спринта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /sprintTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса задач спринта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSprintTaskStatus([FromRoute] int id)
        {
            var command = new DeleteSprintTaskStatusCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
