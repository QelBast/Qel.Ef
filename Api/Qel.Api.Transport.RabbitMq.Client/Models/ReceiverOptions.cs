namespace Qel.Api.Transport.RabbitMq.Client.Models;

public class ReceiverOptions
{
    public required string QueueName { get; set; }
    public required bool IsAutoAck { get; set; }
    public required string ConsumerTag { get; set; }
    public required ClientOptions ClientOptions { get; set; }
}
