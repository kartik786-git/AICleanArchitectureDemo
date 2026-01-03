using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Products.Queries;
using AICleanArchitectureDemo.Application.Features.Categories.Queries;
using AICleanArchitectureDemo.WebMvc.Models;

namespace AICleanArchitectureDemo.WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        var categories = await _mediator.Send(new GetCategoriesQuery());

        var viewModel = new HomeViewModel
        {
            FeaturedProducts = products.Take(6).ToList(),
            Categories = categories
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
