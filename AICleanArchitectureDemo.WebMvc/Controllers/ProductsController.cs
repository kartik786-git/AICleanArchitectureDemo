using MediatR;
using Microsoft.AspNetCore.Mvc;
using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Products.Queries;
using AICleanArchitectureDemo.Application.Features.Categories.Queries;
using AICleanArchitectureDemo.Application.Features.Cart.Commands;
using AICleanArchitectureDemo.WebMvc.Models;

namespace AICleanArchitectureDemo.WebMvc.Controllers;

public class ProductsController : Controller
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var products = await _mediator.Send(new GetProductsQuery());
        var categories = await _mediator.Send(new GetCategoriesQuery());

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
        }

        var viewModel = new ProductsViewModel
        {
            Products = products,
            Categories = categories,
            SelectedCategoryId = categoryId
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var products = await _mediator.Send(new GetProductsQuery());
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        var sessionId = HttpContext.Session.GetString("SessionId");
        if (string.IsNullOrEmpty(sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("SessionId", sessionId);
        }

        var command = new AddToCartCommand(sessionId, productId, quantity);

        await _mediator.Send(command);

        TempData["Message"] = "Product added to cart successfully!";
        return RedirectToAction("Index", "Cart");
    }
}
