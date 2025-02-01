namespace InventifyBackend.Application.Dtos
{
    public sealed record UserCreateResource(string name, string email, string password);
}
