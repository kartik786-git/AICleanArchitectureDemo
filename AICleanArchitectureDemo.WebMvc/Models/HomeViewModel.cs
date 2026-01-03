using AICleanArchitectureDemo.Application.DTOs;

namespace AICleanArchitectureDemo.WebMvc.Models;

public class HomeViewModel
{
    public List<ProductDto> FeaturedProducts { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
}
