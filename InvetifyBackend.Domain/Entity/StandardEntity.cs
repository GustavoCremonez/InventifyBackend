namespace InventifyBackend.Domain.Entity;

public class StandardEntity
{
    public Guid Id { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}