namespace PMS.Server.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при конфликте данных (HTTP 409 Conflict).
    /// </summary>
    /// <remarks>
    /// <para>Используется для обработки ошибок конфликта входных и существующих данных.</para>
    /// </remarks>
    /// <param name="message">Общее сообщение об ошибке.</param>
    public class ConflictException(string message) : Exception(message) {}
}
