using AICleanArchitectureDemo.Domain.Entities;

namespace AICleanArchitectureDemo.Application.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PriceAtTime { get; set; }
    public decimal TotalPrice => PriceAtTime * Quantity;
}
