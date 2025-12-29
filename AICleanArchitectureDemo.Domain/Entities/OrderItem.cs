namespace AICleanArchitectureDemo.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtTime { get; set; } // Store price at order time

    // Business rule
    public decimal GetTotalPrice() => PriceAtTime * Quantity;
}
