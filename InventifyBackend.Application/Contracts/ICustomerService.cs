using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Customers;

namespace InventifyBackend.Application.Contracts
{
    public interface ICustomerService
    {
        Task<ResponseDto<Guid>> Add(CustomerCreateResource customerCreateResource, CancellationToken cancellationToken);

        Task<ResponseDto<CustomerDto>> Get(Guid id, CancellationToken cancellationToken);

        Task<ResponseDto<IEnumerable<CustomerDto>>> GetAll(CancellationToken cancellationToken);

        Task<ResponseDto<CustomerDto>> Update(CustomerUpdateResource customerUpdateResource, CancellationToken cancellationToken);

        Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken);
    }
}
