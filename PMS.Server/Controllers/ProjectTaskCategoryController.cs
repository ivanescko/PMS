using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectTaskCategoryDTO.Queries;
using PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.CreateProjectTaskCategory;
using PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.DeleteProjectTaskCategory;
using PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Commands.UpdateProjectTaskCategory;
using PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategories;
using PMS.Server.Repositories.ProjectTaskCategoryRepository.Handlers.Queries.GetProjectTaskCategory;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными категорий задач проектов.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/projectTaskCategories")]
    [ApiController]
    [Tags("ProjectTaskCategories")]
    public class ProjectTaskCategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных категории задачи проекта по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectTaskCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <returns>Данные категории проекта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProjectTaskCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProjectTaskCategoryResponse>> GetProjectTaskCategory([FromRoute] int id)
        {
            var query = new GetProjectTaskCategoryQuery(id);
            var projectTaskCategory = await _mediator.Send(query);
            return Ok(projectTaskCategory);
        }

        /// <summary>
        /// Получение списка категорий задач проектов.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectTaskCategories
        /// </remarks>
        /// <returns>Список категорий задач проектов.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectTaskCategoryItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProjectTaskCategoryItemResponse[]>> GetProjectTaskCategories()
        {
            var query = new GetProjectTaskCategoriesQuery();
            var projectTaskCategories = await _mediator.Send(query);
            return Ok(projectTaskCategories);
        }

        /// <summary>
        /// Создание категории задач проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /projectTaskCategories
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateProjectTaskCategory([FromBody] CreateProjectTaskCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление категории задач проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /projectTaskCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateProjectTaskCategory([FromRoute] int id, [FromBody] UpdateProjectTaskCategoryRequest request)
        {
            var command = new UpdateProjectTaskCategoryCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление категории задач проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /projectTaskCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории задач проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProjectTaskCategory([FromRoute] int id)
        {
            var command = new DeleteProjectTaskCategoryCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
