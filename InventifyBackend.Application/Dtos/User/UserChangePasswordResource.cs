namespace InventifyBackend.Application.Dtos.User
{
    public sealed record UserChangePasswordResource(Guid id, string previousPassword, string newPassword);
}
