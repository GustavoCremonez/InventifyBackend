using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Domain.Entity
{
    public sealed class Customer
    {
        public Customer(Guid id, string name, string email, string phone, string street, string city, string state, string postalCode, string addressNumber, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            AddressNumber = addressNumber;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected Customer()
        {

        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string PostalCode { get; private set; }

        public string AddressNumber { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }


        public void UpdateCustomer(string name, string email, string phone, string street, string city, string state, string postalCode, string addressNumber)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            AddressNumber = addressNumber;
            UpdatedAt = DateTime.Now;

            ValidateCustomer();
        }

        public void ValidateCustomer()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
        }
    }


}
