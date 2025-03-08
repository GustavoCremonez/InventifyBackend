namespace InventifyBackend.Application.Dtos.Customers
{
    public sealed record CustomerUpdateResource(Guid Id, string Name, string Email, string Phone, string Street, string City, string State, string PostalCode, string AddressNumber);
}

