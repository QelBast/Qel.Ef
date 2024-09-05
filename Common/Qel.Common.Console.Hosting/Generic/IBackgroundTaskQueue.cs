namespace Qel.Common.Console.Hosting.Generic;

public interface IBackgroundTaskQueue
{
    /// <summary>
    /// Предоставляет функциональные возможности очереди
    /// </summary>
    /// <param name="workItem"></param>
    /// <returns></returns>
    ValueTask QueueBackgroundWorkItemAsync(
        Func<CancellationToken, ValueTask> workItem);

    /// <summary>
    /// Выводит из очереди рабочие элементы, которые были добавлены в нее ранее
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(
        CancellationToken cancellationToken);
}
