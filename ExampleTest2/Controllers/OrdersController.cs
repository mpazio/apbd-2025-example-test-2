using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var order = await _dbService.GetOrderById(id);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpPut("{orderId}/fulfill")]
    public async Task<IActionResult> FulfillOrder(int orderId, FulfillOrderDto dto)
    {
        try
        {
            await _dbService.FulfillOrder(orderId, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
    
}