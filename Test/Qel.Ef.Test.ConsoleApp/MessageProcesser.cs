using Microsoft.Extensions.Logging;
using Qel.Api.Transport;
using Qel.Ef.Contexts.Main;

namespace Qel.Ef.Test.ConsoleApp;

public class MessageProcesser(
    ILogger<MessageProcesser> logger,
    DbContextMain db) : IMessageProcesser<string>
{
    readonly ILogger<MessageProcesser> _logger = logger;
    public Task Process(ref BaseMessage<string> message)
    {
        message ??= new(string.Empty);
        _logger.LogInformation("::Сообщение равняется {message}", message);

        var task = Task () => 
        {
            _logger.LogCritical("!!!ЗАРАБОТАЛО!!!");
            return Task.CompletedTask;
        };
        if (task.Invoke().IsCompletedSuccessfully)
        {
            _logger.LogInformation("Обработка сообщения завершена УСПЕШНО");
            return Task.CompletedTask;
        }
        else
        {
            _logger.LogError("Обработка сообщения завершена ОШИБОЧНО");
            return Task.CompletedTask;
        }
    }
}
