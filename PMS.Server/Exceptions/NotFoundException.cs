namespace PMS.Server.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при отсутствии запрашиваего ресурса (HTTP 404 Not Found).
    /// </summary>
    /// <remarks>
    /// <para>Используется для обработки ошибок отсутствия запрашиваемых данных.</para>
    /// </remarks>
    /// <param name="message">Общее сообщение об ошибке.</param>
    public class NotFoundException(string message) : Exception(message) {}
}
