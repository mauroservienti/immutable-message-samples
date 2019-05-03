using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class CreateOrderHandler : IHandleMessages<ICreateOrder>
{
    static ILog log = LogManager.GetLogger<CreateOrderHandler>();

    public Task Handle(ICreateOrder message, IMessageHandlerContext context)
    {
        log.Info($"Order received: {message.OrderId}");
        return Task.CompletedTask;
    }
}