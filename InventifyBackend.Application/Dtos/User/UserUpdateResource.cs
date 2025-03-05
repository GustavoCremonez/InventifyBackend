namespace InventifyBackend.Application.Dtos.User
{
    public sealed record UserUpdateResource(Guid id, string name, string email, string password);
}
