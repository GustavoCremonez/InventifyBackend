using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Domain.Entity
{
    public sealed class Categorie
    {
        public Categorie(Guid id, string name, string description, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected Categorie()
        { 
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public void UpdateCategorie(string name, string description)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;

            ValidateCategorie();
        }

        public void ValidateCategorie()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Description), "The description must not be empty.");
        }
    }
}
