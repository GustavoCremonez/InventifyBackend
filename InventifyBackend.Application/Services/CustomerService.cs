using AutoMapper;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Customers;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IGeneralRepository _generalRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IGeneralRepository generalRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _generalRepository = generalRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CustomerDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Customer? customer = await _customerRepository.Get(id, cancellationToken);

                if (customer == null)
                {
                    return ResponseDto<CustomerDto>.Failure(400, "There is no customer with this id.");
                }

                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

                return ResponseDto<CustomerDto>.Success(customerDto);
            }
            catch
            {
                return ResponseDto<CustomerDto>.Failure(500, "Error while getting customer.");
            }
        }

        public async Task<ResponseDto<IEnumerable<CustomerDto>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Customer> customers = await _customerRepository.GetAll(cancellationToken);
                IEnumerable<CustomerDto> customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                return ResponseDto<IEnumerable<CustomerDto>>.Success(customersDto);
            }
            catch
            {
                return ResponseDto<IEnumerable<CustomerDto>>.Failure(500, "Error while getting customers.");
            }
        }

        public async Task<ResponseDto<Guid>> Add(CustomerCreateResource customerCreateResource, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = _mapper.Map<Customer>(customerCreateResource);

                customer.ValidateCustomer();

                await _generalRepository.Add(customer, cancellationToken);

                return ResponseDto<Guid>.Success(customer.Id);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering customer: " + e.Message);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering customer.");
            }
        }

        public async Task<ResponseDto<CustomerDto>> Update(CustomerUpdateResource customerUpdateResource, CancellationToken cancellationToken)
        {
            try
            {
                if (customerUpdateResource == null)
                {
                    return ResponseDto<CustomerDto>.Failure(400, "The customer information must contain a value.");
                }

                Customer? customer = await _customerRepository.Get(customerUpdateResource.Id, cancellationToken);

                if (customer == null)
                {
                    return ResponseDto<CustomerDto>.Failure(400, "There is no customer with this id.");
                }

                customer.UpdateCustomer(
                    customerUpdateResource.Name,
                    customerUpdateResource.Email,
                    customerUpdateResource.Phone,
                    customerUpdateResource.Street,
                    customerUpdateResource.City,
                    customerUpdateResource.State,
                    customerUpdateResource.PostalCode,
                    customerUpdateResource.AddressNumber
                    );

                await _generalRepository.SaveAsync();

                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

                return ResponseDto<CustomerDto>.Success(customerDto);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<CustomerDto>.Failure(500, "Error while updating customer: " + e.Message);
            }
            catch
            {
                return ResponseDto<CustomerDto>.Failure(500, "Error while updating customer.");
            }
        }


        public async Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Customer? customer = await _customerRepository.Get(id, cancellationToken);

                if (customer == null)
                {
                    return ResponseDto<Guid>.Failure(400, "There is no customer with this id.");
                }

                await _generalRepository.Delete(customer);

                return ResponseDto<Guid>.Success(id);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when deleting customer.");
            }
        }
    }
}

