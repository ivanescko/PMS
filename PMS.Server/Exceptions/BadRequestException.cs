namespace PMS.Server.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при некорректных входных данных (HTTP 400 Bad Request).
    /// </summary>
    /// <remarks>
    /// <para>Используется для обработки ошибок валидации.</para>
    /// </remarks>
    /// <param name="message">Общее сообщение об ошибке.</param>
    /// <param name="errors">
    /// Словарь ошибок валидации.
    /// <para>Ключ: имя поля.</para>
    /// <para>Значение: массив сообщений об ошибках.</para>
    /// </param>
    public class BadRequestException(string message, IDictionary<string, string[]> errors) : Exception(message)
    {
        /// <summary>
        /// Коллекция ошибок валидации, сгруппированных по именам полей.
        /// </summary>
        /// <value>
        /// Словарь, где ключ - имя поля, а значение - массив сообщений об ошибках для этого поля.
        /// </value>
        public IDictionary<string, string[]> Errors { get; } = errors;

        /// <summary>
        /// Конструктор класса <see cref="BadRequestException"/> без детализированных ошибок.
        /// </summary>
        /// <remarks>
        /// Инициализирует новый экземпляр исключения на ошибки валидации.
        /// </remarks>
        /// <param name="message">Сообщение об ошибке.</param>
        public BadRequestException(string message)
            : this(message, new Dictionary<string, string[]>()) {}
    }
}
