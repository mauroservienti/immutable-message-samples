using System;
using NServiceBus;

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