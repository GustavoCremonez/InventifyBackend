namespace InventifyBackend.Application.Dtos
{
    public sealed record UserUpdateResource(Guid id, string name, string email, string password);
}
