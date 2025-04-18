using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Domain.Entity;

public class Product : StandardEntity
{
    public Product(string name, decimal price, decimal quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ProductCategories = [];
    }

    protected Product()
    {
        
    }

    public Guid UserId { get; set; }
    
    public User User { get; set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public decimal Quantity { get; private set; }

    public List<ProductCategory> ProductCategories { get; private set; }

    public void UpdateProduct(string name, decimal price, decimal quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        UpdatedAt = DateTime.Now;
        ValidateProduct();
    }

    public void ValidateProduct()
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
        DomainExceptionValidation.When(Price <= 0, "The price must be greater than zero.");
        DomainExceptionValidation.When(Quantity < 0, "The quantity must be greater than or equal to zero.");
    }

    public void AddProductCategory(ProductCategory productCategory)
    {
        ProductCategories.Add(productCategory);
    }
}