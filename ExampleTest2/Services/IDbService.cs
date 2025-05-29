using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<OrderDto> GetOrderById(int orderId);
    Task FulfillOrder(int orderId, FulfillOrderDto dto);
}