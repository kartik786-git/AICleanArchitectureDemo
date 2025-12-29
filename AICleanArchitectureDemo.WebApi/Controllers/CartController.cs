using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Cart.Commands;
using AICleanArchitectureDemo.Application.Features.Cart.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AICleanArchitectureDemo.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{sessionId}")]
    public async Task<IActionResult> GetCart(string sessionId)
    {
        var query = new GetCartQuery(sessionId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("{sessionId}")]
    public async Task<IActionResult> AddToCart(string sessionId, [FromBody] AddToCartRequest request)
    {
        var command = new AddToCartCommand(sessionId, request.ProductId, request.Quantity);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCart), new { sessionId }, result);
    }

    // Add other endpoints: UpdateCartItem, RemoveFromCart, ClearCart, GetCartTotal, GetCartCount
}

public class AddToCartRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
