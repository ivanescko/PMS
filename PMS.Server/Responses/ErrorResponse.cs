namespace PMS.Server.Responses
{

    /// <summary>
    /// Модель ответа с информацией об ошибке.
    /// </summary>
    /// <param name="Status">HTTP-статус код ошибки.</param>
    /// <param name="Title">Общее описание ошибки.</param>
    /// <param name="Errors">Словарь, содержащий детализацию ошибкок, где ключ - имя поля, а значение - массив сообщений об ошибках для этого поля.</param>
    /// <remarks>
    /// Используется для стандартизованного возврата ошибок по API.
    /// </remarks>
    public sealed record ErrorResponse(
        int Status,
        string Title,
        IDictionary<string, string[]> Errors
    )
    {
        /// <summary>
        /// Конструктор класса <see cref="ErrorResponse"/> без детализированных ошибок.
        /// </summary>
        /// <param name="status">HTTP-статус код ошибки.</param>
        /// <param name="title">Общее описание ошибки.</param>
        public ErrorResponse(int status, string title)
        : this(status, title, new Dictionary<string, string[]>())
        {
        }
    }
}
