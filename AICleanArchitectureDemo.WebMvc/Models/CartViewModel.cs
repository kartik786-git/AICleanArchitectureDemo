using AICleanArchitectureDemo.Application.DTOs;

namespace AICleanArchitectureDemo.WebMvc.Models;

public class CartViewModel
{
    public List<CartItemDto> CartItems { get; set; } = new();
    public decimal Total { get; set; }
}
