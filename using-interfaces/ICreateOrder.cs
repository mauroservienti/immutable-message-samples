using System;
using NServiceBus;

public interface ICreateOrder : IMessage
{
    int OrderId { get; }
    DateTime Date { get; }
    int CustomerId { get; }
}