using MediatR;
using Microsoft.AspNetCore.Mvc;
using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Orders.Queries;

namespace AICleanArchitectureDemo.WebMvc.Controllers;

public class OrdersController : Controller
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _mediator.Send(new GetOrdersQuery());
        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }
}
