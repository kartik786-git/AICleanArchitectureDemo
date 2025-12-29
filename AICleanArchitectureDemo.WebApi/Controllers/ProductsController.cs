using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Products.Commands;
using AICleanArchitectureDemo.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AICleanArchitectureDemo.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetProductsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProductsQuery(); // In real app, add GetProductByIdQuery
        var result = await _mediator.Send(query);
        var product = result.FirstOrDefault(p => p.Id == id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    // Add other endpoints like Update, Delete, Search, etc.
}
