namespace InventifyBackend.Application.Dtos.Customers
{
    public sealed record CustomerCreateResource(string Name, string Email, string Phone, string Street, string City, string State, string PostalCode, string AddressNumber, Guid userId);
}
