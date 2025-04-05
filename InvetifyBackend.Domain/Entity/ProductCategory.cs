namespace InventifyBackend.Domain.Entity;

public class ProductCategory
{
    public ProductCategory(Guid id, Guid productId, Guid categoryId, Product product, Category category)
    {
        Id = id;
        ProductId = productId;
        CategoryId = categoryId;
        Product = product;
        Category = category;
    }
    
    protected ProductCategory()
    {
        
    } 
    
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public Product Product { get; set; }    
    
    public Category Category { get; set; }
}