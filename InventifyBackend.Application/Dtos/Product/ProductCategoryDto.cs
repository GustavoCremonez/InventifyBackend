using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Application.Dtos.Product
{
    public record ProductCategoryDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }

        public ProductDto? Product { get; set; }

        public CategoryDto? Category { get; set; }
    }
}
