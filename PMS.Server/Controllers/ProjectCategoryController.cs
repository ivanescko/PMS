using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.ProjectCategoryDTO.Commands;
using PMS.Server.DTOs.ProjectCategoryDTO.Queries;
using PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.CreateProjectCategory;
using PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.DeleteProjectCategory;
using PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Commands.UpdateProjectCategory;
using PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategories;
using PMS.Server.Repositories.ProjectCategoryRepository.Handlers.Queries.GetProjectCategory;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными категорий проектов.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/projectCategories")]
    [ApiController]
    [Tags("Категории проекта")]
    public class ProjectCategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных категории проекта по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <returns>Данные категории проекта.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProjectCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProjectCategoryResponse>> GetProjectCategory([FromRoute] int id)
        {
            var query = new GetProjectCategoryQuery(id);
            var projectCategory = await _mediator.Send(query);
            return Ok(projectCategory);
        }

        /// <summary>
        /// Получение списка категорий проектов.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /projectCategories
        /// </remarks>
        /// <returns>Список категорий проектов.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectCategoryItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProjectCategoryItemResponse[]>> GetProjectCategories()
        {
            var query = new GetProjectCategoriesQuery();
            var projectCategories = await _mediator.Send(query);
            return Ok(projectCategories);
        }

        /// <summary>
        /// Создание категории проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /projectCategories
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateProjectCategory([FromBody] CreateProjectCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление категории проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /projectCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateProjectCategory([FromRoute] int id, [FromBody] UpdateProjectCategoryRequest request)
        {
            var command = new UpdateProjectCategoryCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление категории проекта.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /projectCategories/1
        /// </remarks>
        /// <param name="id">Идентификатор категории проекта.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProjectCategory([FromRoute] int id)
        {
            var command = new DeleteProjectCategoryCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
