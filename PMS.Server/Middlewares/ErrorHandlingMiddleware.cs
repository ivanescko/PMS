using PMS.Server.Exceptions;
using PMS.Server.Responses;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace PMS.Server.Middlewares
{
    /// <summary>
    /// Middleware для глобальной обработки исключений в HTTP-конвейере.
    /// </summary>
    /// <remarks>
    /// <para>Перехватывает все необработанные исключения и преобразует их в структурированные HTTP-ответы.</para>
    /// </remarks>
    /// <param name="next">Следующий делегат в конвейере запросов.</param>
    /// <param name="logger">Логгер для записи исключений.</param>
    public class ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

        /// <summary>
        /// Обрабатывает HTTP-запрос.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса.</param>
        /// <remarks>
        /// Перехватывает исключения на уровне всего конвейера и обрабатывает их через <see cref="HandleExceptionAsync"/>.
        /// </remarks>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Метод обработки исключений API.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса.</param>
        /// <param name="exception">Исключение для обработки.</param>
        /// <returns>Задача, представляющая асинхронную операцию записи ответа.</returns>
        /// <remarks>
        /// Обрабатывает исключение и формирует HTTP-ответ.
        /// <para><b>Логика обработки:</b></para>
        /// <list type="number">
        /// <item><description>Определяет HTTP-статус по типу исключения</description></item>
        /// <item><description>Для <see cref="BadRequestException"/> включает дополнительные ошибки валидации</description></item>
        /// <item><description>Формирует ответ в формате JSON (<see cref="ErrorResponse"/>)</description></item>
        /// </list>
        /// <para>Соответствие исключений и статусов:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Исключение</term>
        /// <description>HTTP-статус</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="NotFoundException"/></term>
        /// <description>404 Not Found</description>
        /// </item>
        /// <item>
        /// <term><see cref="BadRequestException"/></term>
        /// <description>400 Bad Request</description>
        /// </item>
        /// <item>
        /// <term><see cref="ConflictException"/></term>
        /// <description>409 Conflict</description>
        /// </item>
        /// <item>
        /// <term>Прочие исключения</term>
        /// <description>500 Internal Server Error</description>
        /// </item>
        /// </list>
        /// </remarks>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Оработка кода ошибки
            var statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                ConflictException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            ErrorResponse response;

            if (exception is BadRequestException validationException)
            {
                response = new ErrorResponse(statusCode, exception.Message, validationException.Errors);
            } 
            else
            {
                response = new ErrorResponse(statusCode, exception.Message);
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
