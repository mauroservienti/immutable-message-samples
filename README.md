# immutable-message-samples

Demos how to mimic immutable messages using NServiceBus.

## json-customization

The `json-customization` project uses Json.NET features to enable deserializing classes with private getters and private constructor so allow messages to be defined as:

```csharp
public class CreateOrder : IMessage
{
    public CreateOrder(int orderId, DateTime date, int customerId)
    {
        OrderId = orderId;
        Date = date;
        CustomerId = customerId;
    }

    public int OrderId { get; private set; }
    public DateTime Date { get; private set; }
    public int CustomerId { get; private set; }
}
```

## using-interfaces

The `using-interfaces` project instead defines at the sender a regular class with a public  constructor and public setter, such as:

```csharp
public class CreateOrder : ICreateOrder
{
    public CreateOrder(int orderId, DateTime date, int customerId)
    {
        OrderId = orderId;
        Date = date;
        CustomerId = customerId;
    }

    public int OrderId { get; private set; }
    public DateTime Date { get; private set; }
    public int CustomerId { get; private set; }
}
```

Such a message is then defined as an "immutable" interface at the receiver:

```csharp
public interface ICreateOrder : IMessage
{
    int OrderId { get; }
    DateTime Date { get; }
    int CustomerId { get; }
}
```