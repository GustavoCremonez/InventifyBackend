namespace InventifyBackend.Application.Dtos
{
    public sealed record UserChangePasswordResource(Guid id, string previousPassword, string newPassword);
}
