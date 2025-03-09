using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Domain.Entity
{
    public sealed class Category
    {
        public Category(Guid id, string name, string description, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected Category()
        { 
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public void UpdateCategory(string name, string description)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;

            ValidateCategory();
        }

        public void ValidateCategory()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Description), "The description must not be empty.");
        }
    }
}
