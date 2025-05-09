using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Server.DTOs.SpecialityDTO.Commands;
using PMS.Server.DTOs.SpecialityDTO.Queries;
using PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.CreateSpeciality;
using PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.DeleteSpeciality;
using PMS.Server.Repositories.SpecialityRepository.Handlers.Commands.UpdateSpeciality;
using PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpecialities;
using PMS.Server.Repositories.SpecialityRepository.Handlers.Queries.GetSpeciality;
using PMS.Server.Responses;

namespace PMS.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными специальностей.
    /// </summary>
    /// <param name="mediator">Медиатор для обработки CQRS запросов.</param>
    [Route("api/specialities")]
    [ApiController]
    [Tags("Специальности")]
    public class SpecialityController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получение данных специальности по ID.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /specialities/1
        /// </remarks>
        /// <param name="id">Идентификатор специальности.</param>
        /// <returns>Данные специальности.</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetSpecialityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSpecialityResponse>> GetSpeciality([FromRoute] int id)
        {
            var query = new GetSpecialityQuery(id);
            var speciality = await _mediator.Send(query);
            return Ok(speciality);
        }

        /// <summary>
        /// Получение списка специальностей.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET /specialities
        /// </remarks>
        /// <returns>Список специальностей.</returns>
        /// <response code="200">Успешное выполнение.</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetSpecialityItemResponse[]), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetSpecialityItemResponse[]>> GetSpecialities()
        {
            var query = new GetSpecialitiesQuery();
            var specialities = await _mediator.Send(query);
            return Ok(specialities);
        }

        /// <summary>
        /// Создание специальности.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /specialities
        /// </remarks>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="409">Конфликт данных.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateSpeciality([FromBody] CreateSpecialityCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Обновление специальности.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// PATCH /specialities/1
        /// </remarks>
        /// <param name="id">Идентификатор специальности.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        /// <response code="409">Конфликт данных.</response>       
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateSpeciality([FromRoute] int id, [FromBody] UpdateSpecialityRequest request)
        {
            var command = new UpdateSpecialityCommand(
                Id: id,
                Title: request.Title,
                Description: request.Description
            );

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удаление специальности.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// DELETE /specialities/1
        /// </remarks>
        /// <param name="id">Идентификатор специальности.</param>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="404">Ресурс не найден.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSpeciality([FromRoute] int id)
        {
            var command = new DeleteSpecialityCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
