using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.ProjectStatusDTO.Commands;
using PMS.Server.DTOs.ProjectStatusDTO.Queries;
using PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.CreateProjectStatus;
using PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.DeleteProjectStatus;
using PMS.Server.Repositories.ProjectStatusRepository.Handlers.Commands.UpdateProjectStatus;
using PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatus;
using PMS.Server.Repositories.ProjectStatusRepository.Handlers.Queries.GetProjectStatuses;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными статусов проектов.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/projectStatuses")]
    [ApiController]
    [Tags("ProjectStatuses")]
    public class ProjectStatusController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных статуса проекта по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <returns>Данные категории проекта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProjectStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProjectStatusResponse>> GetProjectStatus([FromRoute] int id)
        {
            var query = new GetProjectStatusQuery(id);
            var projectStatus = await _mediator.Send(query);
            return Ok(projectStatus);
        }

        /// <summary>
        /// Получение списка статуса проектов.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectStatuses
        /// </remarks>
        /// <returns>Список статуса проектов.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectStatusItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProjectStatusItemResponse[]>> GetProjectStatuses()
        {
            var query = new GetProjectStatusesQuery();
            var projectStatuses = await _mediator.Send(query);
            return Ok(projectStatuses);
        }

        /// <summary>
        /// Создание статуса проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /projectStatuses
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateProjectStatus([FromBody] CreateProjectStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление статуса проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /projectStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateProjectStatus([FromRoute] int id, [FromBody] UpdateProjectStatusRequest request)
        {
            var command = new UpdateProjectStatusCommand(
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
        /// DELETE /projectStatuses/1
        /// </remarks>
        /// <param name="id">Идентификатор статуса проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProjectStatus([FromRoute] int id)
        {
            var command = new DeleteProjectStatusCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
