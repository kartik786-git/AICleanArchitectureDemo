using AICleanArchitectureDemo.Application.DTOs;

namespace AICleanArchitectureDemo.WebMvc.Models;

public class ProductsViewModel
{
    public List<ProductDto> Products { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
    public int? SelectedCategoryId { get; set; }
}
