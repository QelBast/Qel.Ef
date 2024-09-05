namespace Qel.Api.Transport.RabbitMq.Client.Models;

public class SenderOptions
{
    public required string ExchangeName { get; set; } = string.Empty;
    public required string RoutingKey { get; set; } = string.Empty;
    public bool IsMandatory { get; set; } = false;
    public required ClientOptions ClientOptions { get; set; }
}
