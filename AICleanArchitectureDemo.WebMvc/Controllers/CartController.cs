using MediatR;
using Microsoft.AspNetCore.Mvc;
using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Cart.Queries;
using AICleanArchitectureDemo.Application.Features.Orders.Commands;
using AICleanArchitectureDemo.WebMvc.Models;

namespace AICleanArchitectureDemo.WebMvc.Controllers;

public class CartController : Controller
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var sessionId = HttpContext.Session.GetString("SessionId");
        if (string.IsNullOrEmpty(sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("SessionId", sessionId);
        }

        var cartItems = await _mediator.Send(new GetCartQuery(sessionId));

        var viewModel = new CartViewModel
        {
            CartItems = cartItems,
            Total = cartItems.Sum(item => item.Quantity * item.ProductPrice)
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Checkout()
    {
        var sessionId = HttpContext.Session.GetString("SessionId");
        if (string.IsNullOrEmpty(sessionId))
        {
            return RedirectToAction("Index");
        }

        var cartItems = await _mediator.Send(new GetCartQuery(sessionId));
        if (!cartItems.Any())
        {
            TempData["Error"] = "Your cart is empty.";
            return RedirectToAction("Index");
        }

        // Create order from cart
        var createOrderCommand = new CreateOrderCommand(sessionId, "customer@example.com");

        var orderId = await _mediator.Send(createOrderCommand);

        // Clear session after successful order
        HttpContext.Session.Remove("SessionId");

        TempData["Message"] = $"Order #{orderId} placed successfully!";
        return RedirectToAction("Details", "Orders", new { id = orderId });
    }
}
