using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.DepartmentDTO.Commands;
using PMS.Server.DTOs.DepartmentDTO.Queries;
using PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.CreateDepartment;
using PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.DeleteDepartment;
using PMS.Server.Repositories.DepartmentRepository.Handlers.Commands.UpdateDepartment;
using PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartment;
using PMS.Server.Repositories.DepartmentRepository.Handlers.Queries.GetDepartments;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными отдела.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/departments")]
    [ApiController]
    [Tags("Департамент")]
    public class DepartmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных отдела по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /departments/1
        /// </remarks>
        /// <param name="id">Идентификатор отдела.</param>
        /// <returns>Данные отдела.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetDepartmentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDepartmentResponse>> GetDepartment([FromRoute] int id)
        {
            var query = new GetDepartmentQuery(id);
            var department = await _mediator.Send(query);
            return Ok(department);
        }

        /// <summary>
        /// Получение списка отдела.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /departments
        /// </remarks>
        /// <returns>Список отдела.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetDepartmentItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetDepartmentItemResponse[]>> GetDepartments()
        {
            var query = new GetDepartmentsQuery();
            var departments = await _mediator.Send(query);
            return Ok(departments);
        }

        /// <summary>
        /// Создание отдела.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /departments
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление отдела.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /departments/1
        /// </remarks>
        /// <param name="id">Идентификатор отдела.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateDepartment([FromRoute] int id, [FromBody] UpdateDepartmentRequest request)
        {
            var command = new UpdateDepartmentCommand(
                Id: id,
                Code: request.Code,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление отдела.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /departments/1
        /// </remarks>
        /// <param name="id">Идентификатор отдела.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDepartment([FromRoute] int id)
        {
            var command = new DeleteDepartmentCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
