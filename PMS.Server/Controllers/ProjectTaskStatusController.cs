using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Commands;
using PMS.Server.DTOs.ProjectTaskStatusDTO.Queries;
using PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.CreateProjectTaskStatus;
using PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.DeleteProjectTaskStatus;
using PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Commands.UpdateProjectTaskStatus;
using PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatus;
using PMS.Server.Repositories.ProjectTaskStatusRepository.Handlers.Queries.GetProjectTaskStatuses;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными статусов проектов.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/projectTaskStatuses")]
    [ApiController]
    [Tags("ProjectTaskStatuses")]
    public class ProjectTaskStatusController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных статуса проекта по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <returns>Данные категории проекта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProjectTaskStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProjectTaskStatusResponse>> GetProjectTaskStatus([FromRoute] int id)
        {
            var query = new GetProjectTaskStatusQuery(id);
            var projectTaskStatus = await _mediator.Send(query);
            return Ok(projectTaskStatus);
        }

        /// <summary>
        /// Получение списка статуса проектов.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectTaskStatuses
        /// </remarks>
        /// <returns>Список статуса проектов.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectTaskStatusItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProjectTaskStatusItemResponse[]>> GetProjectTaskStatuses()
        {
            var query = new GetProjectTaskStatusesQuery();
            var projectTaskStatuses = await _mediator.Send(query);
            return Ok(projectTaskStatuses);
        }

        /// <summary>
        /// Создание статуса проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /projectTaskStatuses
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateProjectTaskStatus([FromBody] CreateProjectTaskStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление статуса проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /projectTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateProjectTaskStatus([FromRoute] int id, [FromBody] UpdateProjectTaskStatusRequest request)
        {
            var command = new UpdateProjectTaskStatusCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление статуса проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /projectTaskStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProjectTaskStatus([FromRoute] int id)
        {
            var command = new DeleteProjectTaskStatusCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
