using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;


        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Customer?> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Customer? customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                return customer;
            }
            catch
            {
                throw new Exception("An error occurred when trying to get customer.");
            }
        }

        public async Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                List<Customer> customers = await _applicationDbContext.Customers.ToListAsync();

                return customers;
            }
            catch
            {
                throw new Exception("An error occurred when trying to get customers.");
            }
        }
    }
}
