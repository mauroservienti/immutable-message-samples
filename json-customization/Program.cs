using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NServiceBus;

static class Program
{
    static async Task Main()
    {
        Console.Title = "Samples.Serialization";

        var endpointConfiguration = new EndpointConfiguration("Samples.Serialization");
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new NonPublicPropertiesResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

        var serialization = endpointConfiguration.UseSerialization<NewtonsoftSerializer>();
        serialization.Settings(settings);

        endpointConfiguration.UsePersistence<LearningPersistence>();
        endpointConfiguration.UseTransport<LearningTransport>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        var message = new CreateOrder(orderId: 9, date: DateTime.Now, customerId: 12);
        await endpointInstance.SendLocal(message)
            .ConfigureAwait(false);


        Console.WriteLine("Order Sent");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}