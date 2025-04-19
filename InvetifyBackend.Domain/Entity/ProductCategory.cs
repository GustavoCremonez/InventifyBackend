namespace InventifyBackend.Domain.Entity;

public class ProductCategory
{
    public ProductCategory(Guid productId, Guid categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
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