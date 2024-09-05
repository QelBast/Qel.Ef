namespace Qel.Api.Transport;

public interface IMessageProcesser<T>
{
    /// <summary>
    /// Обработка полученного сообщения с получением сообщения для последующей отправки
    /// </summary>
    /// <param name="message">Обработанное сообщение, готовое к отправке</param>
    /// <returns></returns>
    public abstract Task Process(out BaseMessage<T> message);

    /// <summary>
    /// Обработка полученного сообщения
    /// </summary>
    /// <returns></returns>
    public abstract Task Process();
}