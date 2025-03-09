namespace InventifyBackend.Application.Dtos.Categories
{
    public sealed record CategoryUpdateResource(Guid id, string name, string description);
}
