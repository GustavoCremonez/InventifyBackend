namespace InventifyBackend.Application.Dtos.User
{
    public sealed record UserCreateResource(string name, string email, string password);
}
