using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> Get(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken);
    }
}
